namespace Task_4
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
            this.ChangeLight_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChangeLight_button
            // 
            this.ChangeLight_button.Location = new System.Drawing.Point(50, 13);
            this.ChangeLight_button.Name = "ChangeLight_button";
            this.ChangeLight_button.Size = new System.Drawing.Size(165, 59);
            this.ChangeLight_button.TabIndex = 0;
            this.ChangeLight_button.Text = "ChangeLight";
            this.ChangeLight_button.UseVisualStyleBackColor = true;
            this.ChangeLight_button.Click += new System.EventHandler(this.ChangeLight_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 601);
            this.Controls.Add(this.ChangeLight_button);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Пешеходный переход";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ChangeLight_button;
    }
}

