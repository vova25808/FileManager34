namespace FileManager
{
    partial class Form2
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
            this.actions = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // actions
            // 
            this.actions.BackColor = System.Drawing.SystemColors.Info;
            this.actions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.actions.ForeColor = System.Drawing.Color.Red;
            this.actions.FormattingEnabled = true;
            this.actions.ItemHeight = 25;
            this.actions.Items.AddRange(new object[] {
            "Открыть",
            "Копировать",
            "Переименовать",
            "Переместить",
            "Удалить",
            "Архивировать",
            "Создать",
            "Свойства"});
            this.actions.Location = new System.Drawing.Point(0, 0);
            this.actions.Name = "actions";
            this.actions.Size = new System.Drawing.Size(196, 204);
            this.actions.TabIndex = 0;
            this.actions.SelectedIndexChanged += new System.EventHandler(this.actions_SelectedIndexChanged);
            this.actions.MouseLeave += new System.EventHandler(this.actions_MouseLeave);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 208);
            this.Controls.Add(this.actions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form2";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox actions;
    }
}