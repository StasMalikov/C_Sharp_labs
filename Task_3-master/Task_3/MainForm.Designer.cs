namespace Task_3
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.GetInfoFromList_button = new System.Windows.Forms.Button();
            this.Reconfigure_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(258, 48);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(521, 378);
            this.textBox.TabIndex = 0;
            // 
            // GetInfoFromList_button
            // 
            this.GetInfoFromList_button.Location = new System.Drawing.Point(51, 48);
            this.GetInfoFromList_button.Name = "GetInfoFromList_button";
            this.GetInfoFromList_button.Size = new System.Drawing.Size(180, 95);
            this.GetInfoFromList_button.TabIndex = 1;
            this.GetInfoFromList_button.Text = "GetInfoFromList";
            this.GetInfoFromList_button.UseVisualStyleBackColor = true;
            this.GetInfoFromList_button.Click += new System.EventHandler(this.GetInfoFromList_button_Click);
            // 
            // Reconfigure_button
            // 
            this.Reconfigure_button.Location = new System.Drawing.Point(51, 179);
            this.Reconfigure_button.Name = "Reconfigure_button";
            this.Reconfigure_button.Size = new System.Drawing.Size(180, 95);
            this.Reconfigure_button.TabIndex = 2;
            this.Reconfigure_button.Text = "Reconfigure";
            this.Reconfigure_button.UseVisualStyleBackColor = true;
            this.Reconfigure_button.Click += new System.EventHandler(this.Compare_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Reconfigure_button);
            this.Controls.Add(this.GetInfoFromList_button);
            this.Controls.Add(this.textBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button GetInfoFromList_button;
        private System.Windows.Forms.Button Reconfigure_button;
    }
}

