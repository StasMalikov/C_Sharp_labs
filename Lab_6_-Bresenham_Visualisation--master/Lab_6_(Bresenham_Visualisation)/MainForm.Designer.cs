namespace Lab_6__Bresenham_Visualisation_
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
            this.x1_textBox = new System.Windows.Forms.TextBox();
            this.y1_textBox = new System.Windows.Forms.TextBox();
            this.x2_textBox = new System.Windows.Forms.TextBox();
            this.y2_textBox = new System.Windows.Forms.TextBox();
            this.draw_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // x1_textBox
            // 
            this.x1_textBox.Location = new System.Drawing.Point(22, 23);
            this.x1_textBox.Name = "x1_textBox";
            this.x1_textBox.Size = new System.Drawing.Size(43, 26);
            this.x1_textBox.TabIndex = 0;
            // 
            // y1_textBox
            // 
            this.y1_textBox.Location = new System.Drawing.Point(88, 23);
            this.y1_textBox.Name = "y1_textBox";
            this.y1_textBox.Size = new System.Drawing.Size(43, 26);
            this.y1_textBox.TabIndex = 1;
            // 
            // x2_textBox
            // 
            this.x2_textBox.Location = new System.Drawing.Point(159, 23);
            this.x2_textBox.Name = "x2_textBox";
            this.x2_textBox.Size = new System.Drawing.Size(43, 26);
            this.x2_textBox.TabIndex = 2;
            // 
            // y2_textBox
            // 
            this.y2_textBox.Location = new System.Drawing.Point(227, 23);
            this.y2_textBox.Name = "y2_textBox";
            this.y2_textBox.Size = new System.Drawing.Size(43, 26);
            this.y2_textBox.TabIndex = 3;
            // 
            // draw_button
            // 
            this.draw_button.Location = new System.Drawing.Point(325, 19);
            this.draw_button.Name = "draw_button";
            this.draw_button.Size = new System.Drawing.Size(75, 35);
            this.draw_button.TabIndex = 4;
            this.draw_button.Text = "Draw";
            this.draw_button.UseVisualStyleBackColor = true;
            this.draw_button.Click += new System.EventHandler(this.draw_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 555);
            this.Controls.Add(this.draw_button);
            this.Controls.Add(this.y2_textBox);
            this.Controls.Add(this.x2_textBox);
            this.Controls.Add(this.y1_textBox);
            this.Controls.Add(this.x1_textBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox x1_textBox;
        private System.Windows.Forms.TextBox y1_textBox;
        private System.Windows.Forms.TextBox x2_textBox;
        private System.Windows.Forms.TextBox y2_textBox;
        private System.Windows.Forms.Button draw_button;
    }
}

