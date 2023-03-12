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
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Security.AccessControl;

namespace FileManager
{
    public partial class Form2 : Form
    {
        public window mainwindow;
        public Form3 form3;
        public Form2(window window, Form3 helpform)
        {
            InitializeComponent();
            mainwindow = window;
            form3 = helpform;
        }

        private void actions_MouseLeave(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void actions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actions.SelectedItem.ToString() == "Открыть")
                mainwindow.open();
            else if (actions.SelectedItem.ToString() == "Копировать")
                mainwindow.copy();
            else if (actions.SelectedItem.ToString() == "Переименовать")
            {
                try
                {
                    form3.btn_create.Visible = false;
                    form3.btn_rename.Visible = true;
                    form3.txt_name.Text = mainwindow.selectedItem.Remove(mainwindow.selectedItem.LastIndexOf("."));
                }
                catch
                {
                    form3.txt_name.Text = mainwindow.selectedItem;
                }
                form3.Show();
            }
            else if (actions.SelectedItem.ToString() == "Переместить")
                mainwindow.replace();
            else if (actions.SelectedItem.ToString() == "Удалить")
                mainwindow.delete();
            else if (actions.SelectedItem.ToString() == "Архивировать")
                mainwindow.archivate();
            else if (actions.SelectedItem.ToString() == "Создать") 
            {
                form3.txt_name.Text = null;
                form3.btn_create.Visible = true;
                form3.btn_rename.Visible = false;
                form3.Show();
            }
            else
                mainwindow.info();
            this.Hide();
        }
    }
}
