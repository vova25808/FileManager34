using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;
using System.IO.Compression;

namespace FileManager
{
    public partial class window : Form
    {
        public string filePath = "C:\\";
        public bool going = false;
        public string selectedItem = "";
        public string prevFilePath = "";
        public string nextFilePath = "";
        public string newName = "";
        public Form2 menu;
        public Form3 helpForm;
        public window()
        {
            InitializeComponent();
            helpForm = new Form3(this);
           menu = new Form2(this,helpForm);
        }

        private void window_Load(object sender, EventArgs e)
        {
            loadFiles();
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            if(filePath != prevFilePath)
            prevFilePath = filePath;
            filePath = text_path.Text;
            loadFiles();
            going = true;
            btn_back.Enabled = true;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            goBack();
        }

        private void btn_forward_Click(object sender, EventArgs e)
        {
            filePath = nextFilePath;
            loadFiles();
            btn_forward.Enabled = false;
            btn_back.Enabled = true;
        }

        private void data_list_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) //Отслеживание выделенного элемента listview
        {
            selectedItem = e.Item.Text;
        }

        private void data_list_MouseClick(object sender, MouseEventArgs e) // Нажатие правой кнопкой мыши
        {
            if (e.Button == MouseButtons.Right)
            {
                menu.Show();
                menu.Location = new Point(Cursor.Position.X-3, Cursor.Position.Y-3);
            }
        }

        public void data_list_MouseDoubleClick(object sender, MouseEventArgs e) // Двойное нажатие кнопки мыши
        {
            if (e.Button == MouseButtons.Left)
                open();
        }

        public void loadFiles() //Загрузка файлов и папок в listView
        {
            try
            {
                ListViewItem lvi = new ListViewItem();
                data_list.Items.Clear();
                string[] files = Directory.GetFiles(filePath);
                string[] folders = Directory.GetDirectories(filePath);
                foreach (string file in files)
                {
                    lvi.Text = file.Remove(0, file.LastIndexOf('\\') + 1);
                    if (lvi.Text.LastIndexOf('.') != -1)
                    switch (lvi.Text.Substring(lvi.Text.LastIndexOf('.')).ToLower())
                    {
                        case ".mp3":
                        case ".mp2":
                            data_list.Items.Add(lvi.Text, 1);  
                            break;

                        case ".exe":
                        case ".com":
                            data_list.Items.Add(lvi.Text, 4);
                            break;
                            case ".mp4":
                            case ".avi":
                            case ".mkv":
                                data_list.Items.Add(lvi.Text, 1);
                                break;

                            case ".pdf":
                            data_list.Items.Add(lvi.Text, 3);
                            break;

                        case ".doc":
                        case ".docx":
                            data_list.Items.Add(lvi.Text, 2);
                            break;

                        case ".png":
                        case ".jpg":
                        case ".jpeg":
                            data_list.Items.Add(lvi.Text, 5);
                            break;

                        default:
                            data_list.Items.Add(lvi.Text, 6);
                            break;
                    }
                    else
                        data_list.Items.Add(lvi.Text, 6);
                }

                foreach (string folder in folders)
                {
                    lvi.Text = folder.Remove(0,folder.LastIndexOf('\\') + 1);
                    data_list.Items.Add(lvi.Text, 0);
                }
                text_path.Text = filePath ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                goBack();
            }
        }

        public void goBack() //Возвращение в предыдущую директорию
        {
            try
            {
                if (going)
                {
                    nextFilePath = filePath;
                    filePath = prevFilePath;
                }
                else
                {
                    if (filePath.LastIndexOf("\\") == 2 || filePath.LastIndexOf("\\") == 3)
                    {
                        btn_back.Enabled = false;
                    }
                    nextFilePath = filePath;
                    if(filePath.LastIndexOf('\\') != 2)
                        filePath = filePath.Substring(0, filePath.LastIndexOf("\\"));
                    else filePath = filePath.Substring(0, filePath.LastIndexOf("\\")+1);
                }
                loadFiles();
                btn_forward.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void open() //Открытие файла или директории
        {
            try
            {
                FileAttributes fileAttributes = File.GetAttributes(filePath + "\\" + selectedItem);
                if (fileAttributes.ToString().IndexOf("Directory") != -1)
                {
                    if (filePath.Substring(filePath.LastIndexOf('\\') + 1) != string.Empty)
                        filePath = filePath + "\\" + selectedItem;
                    else filePath = filePath + selectedItem;
                    loadFiles();
                    btn_back.Enabled = true;
                    going = false;
                }
                else
                {
                    Process.Start(filePath + "\\" + selectedItem);
                }
                btn_forward.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void copy()//Копирование файла или директории
        {
            try
            {
                FolderBrowserDialog browse = new FolderBrowserDialog();
                browse.ShowDialog();
                FileAttributes fileAttributes = File.GetAttributes(filePath + "\\" + selectedItem);
                if (fileAttributes.ToString().IndexOf("Directory") != -1)
                {
                    copyDir(filePath + "\\" + selectedItem, browse.SelectedPath + "\\" + selectedItem, true);
                }
                else
                    File.Copy(filePath + "\\" + selectedItem, browse.SelectedPath + "\\" + selectedItem);
                MessageBox.Show("Копирование прошло успешно!", "Завершено");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void rename()//Переименовать файл или директорию
        {
            try
            {
                FileAttributes fileAttributes = File.GetAttributes(filePath + "\\" + selectedItem);
                if (fileAttributes.ToString().IndexOf("Directory") != -1)
                    Directory.Move(filePath + "\\" + selectedItem, filePath + "\\" + newName);
                else
                {
                    File.Move(filePath + "\\" + selectedItem, filePath + "\\" + newName + selectedItem.Substring(selectedItem.LastIndexOf('.')));
                }
                newName = "";
                loadFiles();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void replace()//Переместить файл или директорию
        {
            try
            {
                FolderBrowserDialog browse = new FolderBrowserDialog();
                FileAttributes fileAttributes = File.GetAttributes(filePath + "\\" + selectedItem);
                browse.ShowDialog();
                if (fileAttributes.ToString().IndexOf("Directory") != -1)
                {
                    copyDir(filePath + "\\" + selectedItem, browse.SelectedPath + "\\" + selectedItem, true);
                    deleteDir(filePath + "\\" + selectedItem);
                }
                else
                {
                    File.Copy(filePath + "\\" + selectedItem, browse.SelectedPath + "\\" + selectedItem);
                    File.Delete(filePath + "\\" + selectedItem);
                }
                loadFiles();
                MessageBox.Show("Перемещение прошло успешно!", "Завершено");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void delete()//Удаление файла или директории
        {
            try
            {
                FileAttributes fileAttributes = File.GetAttributes(filePath + "\\" + selectedItem);
                if (fileAttributes.ToString().IndexOf("Directory") != -1)
                    deleteDir(filePath + "\\" + selectedItem);
                else
                    File.Delete(filePath + "\\" + selectedItem);
                loadFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        
        public void archivate() //Архивация файла или директории
        {
            try
            {
                FileAttributes fileAttributes = File.GetAttributes(filePath + "\\" + selectedItem);
                if (fileAttributes.ToString().IndexOf("Directory") != -1)
                    ZipFile.CreateFromDirectory(filePath + "\\" + selectedItem, filePath + "\\" + selectedItem + ".zip");
                else
                {
                    Directory.CreateDirectory(filePath + "\\" + selectedItem.Remove(selectedItem.LastIndexOf(".")));
                    File.Copy(filePath + "\\" + selectedItem, filePath +"\\"+ selectedItem.Remove(selectedItem.LastIndexOf("."))+"\\"+selectedItem);
                    ZipFile.CreateFromDirectory(filePath + "\\" + selectedItem.Remove(selectedItem.LastIndexOf(".")), filePath + "\\" + selectedItem.Remove(selectedItem.LastIndexOf(".")) + ".zip");
                    Directory.Delete(filePath + "\\" + selectedItem.Remove(selectedItem.LastIndexOf(".")),true);
                }
                loadFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void create() //Создание файла или директории
        {
            try
            {
                if (newName.LastIndexOf(".") != -1)
                    File.Create(filePath+"\\"+newName);
                else
                    Directory.CreateDirectory(filePath + "\\" + newName);
                    loadFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void info()//Получение свойств файла или директории
        {
            try
            {
                FileAttributes fileAttributes = File.GetAttributes(filePath + "\\" + selectedItem);
                if (fileAttributes.ToString().IndexOf("Directory") != -1)
                    MessageBox.Show(fileAttributes.ToString(), "Свойства");
                else
                    MessageBox.Show(FileVersionInfo.GetVersionInfo(filePath + "\\" + selectedItem).ToString(), "Свойства");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка");
            }
        }

        private void copyDir(string copiedFile, string finishedFile, bool recursive)//Копирование папки
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(copiedFile);
                Directory.CreateDirectory(finishedFile);
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (FileInfo file in dir.GetFiles())
                {
                    string targetFilePath = Path.Combine(finishedFile, file.Name);
                    file.CopyTo(targetFilePath);
                }
                if (recursive)
                {
                    foreach (DirectoryInfo subDir in dirs)
                    {
                        string newDestinationDir = Path.Combine(finishedFile, subDir.Name);
                        copyDir(subDir.FullName, newDestinationDir, true);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void deleteDir(string deletedFile)//Удаление Папки
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(deletedFile);
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (FileInfo file in dir.GetFiles())
                {
                    string targetFilePath = Path.Combine(deletedFile, file.Name);
                    file.Delete();
                }
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(deletedFile, subDir.Name);
                    deleteDir(subDir.FullName);
                }
                Directory.Delete(deletedFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

    }

}

