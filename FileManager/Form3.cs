using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class Form3 : Form
    {
        public window mainwindow;
        public Form3(window window)
        {
            InitializeComponent();
            mainwindow = window;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
       
        }

        private void btn_rename_Click(object sender, EventArgs e)
        {
            if (txt_name == null)
                MessageBox.Show("Пожалуйста введите название", "Внимание");
            else
            {
                mainwindow.newName = txt_name.Text;
                mainwindow.rename();
                this.Hide();
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            if (txt_name == null)
                MessageBox.Show("Пожалуйста введите название", "Внимание");
            else
            {
                mainwindow.newName = txt_name.Text;
                mainwindow.create();
                this.Hide();
            }
        }
    }
}
