namespace Task_2
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Student_button = new System.Windows.Forms.Button();
            this.EnglishStudent_button = new System.Windows.Forms.Button();
            this.Main_textBox = new System.Windows.Forms.TextBox();
            this.FalseEnglishStud_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Student_button
            // 
            this.Student_button.Location = new System.Drawing.Point(206, 45);
            this.Student_button.Name = "Student_button";
            this.Student_button.Size = new System.Drawing.Size(226, 99);
            this.Student_button.TabIndex = 0;
            this.Student_button.Text = "Student_Info";
            this.Student_button.UseVisualStyleBackColor = true;
            this.Student_button.Click += new System.EventHandler(this.Student_button_Click);
            // 
            // EnglishStudent_button
            // 
            this.EnglishStudent_button.Location = new System.Drawing.Point(558, 45);
            this.EnglishStudent_button.Name = "EnglishStudent_button";
            this.EnglishStudent_button.Size = new System.Drawing.Size(246, 99);
            this.EnglishStudent_button.TabIndex = 1;
            this.EnglishStudent_button.Text = "EnglishStudent_Info";
            this.EnglishStudent_button.UseVisualStyleBackColor = true;
            this.EnglishStudent_button.Click += new System.EventHandler(this.EnglishStudent_button_Click);
            // 
            // Main_textBox
            // 
            this.Main_textBox.Location = new System.Drawing.Point(44, 203);
            this.Main_textBox.Multiline = true;
            this.Main_textBox.Name = "Main_textBox";
            this.Main_textBox.Size = new System.Drawing.Size(1145, 412);
            this.Main_textBox.TabIndex = 2;
            // 
            // FalseEnglishStud_button
            // 
            this.FalseEnglishStud_button.Location = new System.Drawing.Point(907, 45);
            this.FalseEnglishStud_button.Name = "FalseEnglishStud_button";
            this.FalseEnglishStud_button.Size = new System.Drawing.Size(266, 99);
            this.FalseEnglishStud_button.TabIndex = 3;
            this.FalseEnglishStud_button.Text = "False EnglishStud_Info";
            this.FalseEnglishStud_button.UseVisualStyleBackColor = true;
            this.FalseEnglishStud_button.Click += new System.EventHandler(this.FalseEnglishStud_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 647);
            this.Controls.Add(this.FalseEnglishStud_button);
            this.Controls.Add(this.Main_textBox);
            this.Controls.Add(this.EnglishStudent_button);
            this.Controls.Add(this.Student_button);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Student_button;
        private System.Windows.Forms.Button EnglishStudent_button;
        private System.Windows.Forms.TextBox Main_textBox;
        private System.Windows.Forms.Button FalseEnglishStud_button;
    }
}

