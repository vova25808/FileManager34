namespace FileManager
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_rename = new System.Windows.Forms.Button();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_rename
            // 
            this.btn_rename.BackColor = System.Drawing.SystemColors.Info;
            this.btn_rename.ForeColor = System.Drawing.Color.Red;
            this.btn_rename.Location = new System.Drawing.Point(155, 93);
            this.btn_rename.Name = "btn_rename";
            this.btn_rename.Size = new System.Drawing.Size(96, 23);
            this.btn_rename.TabIndex = 0;
            this.btn_rename.Text = "Переименовать";
            this.btn_rename.UseVisualStyleBackColor = false;
            this.btn_rename.Visible = false;
            this.btn_rename.Click += new System.EventHandler(this.btn_rename_Click);
            // 
            // txt_name
            // 
            this.txt_name.BackColor = System.Drawing.SystemColors.Info;
            this.txt_name.ForeColor = System.Drawing.Color.Red;
            this.txt_name.Location = new System.Drawing.Point(12, 45);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(239, 20);
            this.txt_name.TabIndex = 1;
            // 
            // btn_create
            // 
            this.btn_create.BackColor = System.Drawing.SystemColors.Info;
            this.btn_create.ForeColor = System.Drawing.Color.Red;
            this.btn_create.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_create.Location = new System.Drawing.Point(12, 93);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(96, 23);
            this.btn_create.TabIndex = 2;
            this.btn_create.Text = "Создать";
            this.btn_create.UseVisualStyleBackColor = false;
            this.btn_create.Visible = false;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 128);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.btn_rename);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btn_rename;
        public System.Windows.Forms.TextBox txt_name;
        public System.Windows.Forms.Button btn_create;
    }
}