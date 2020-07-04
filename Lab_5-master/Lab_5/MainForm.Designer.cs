namespace Lab_5
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
            this.AddToEnd_button = new System.Windows.Forms.Button();
            this.ExternalForce_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FrictionForce_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Up_button = new System.Windows.Forms.Button();
            this.Down_button = new System.Windows.Forms.Button();
            this.Left_button = new System.Windows.Forms.Button();
            this.Right_button = new System.Windows.Forms.Button();
            this.Delete_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ExternalForce_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrictionForce_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // AddToEnd_button
            // 
            this.AddToEnd_button.Location = new System.Drawing.Point(38, 9);
            this.AddToEnd_button.Name = "AddToEnd_button";
            this.AddToEnd_button.Size = new System.Drawing.Size(191, 93);
            this.AddToEnd_button.TabIndex = 1;
            this.AddToEnd_button.Text = "Добавить колесо \r\nв конец";
            this.AddToEnd_button.UseVisualStyleBackColor = true;
            this.AddToEnd_button.Click += new System.EventHandler(this.AddToEnd_button_Click);
            // 
            // ExternalForce_numericUpDown
            // 
            this.ExternalForce_numericUpDown.DecimalPlaces = 3;
            this.ExternalForce_numericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.ExternalForce_numericUpDown.Location = new System.Drawing.Point(651, 46);
            this.ExternalForce_numericUpDown.Name = "ExternalForce_numericUpDown";
            this.ExternalForce_numericUpDown.Size = new System.Drawing.Size(120, 26);
            this.ExternalForce_numericUpDown.TabIndex = 2;
            this.ExternalForce_numericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            196608});
            this.ExternalForce_numericUpDown.ValueChanged += new System.EventHandler(this.ExternalForce_numericUpDown_ValueChanged);
            // 
            // FrictionForce_numericUpDown
            // 
            this.FrictionForce_numericUpDown.DecimalPlaces = 3;
            this.FrictionForce_numericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.FrictionForce_numericUpDown.Location = new System.Drawing.Point(833, 46);
            this.FrictionForce_numericUpDown.Name = "FrictionForce_numericUpDown";
            this.FrictionForce_numericUpDown.Size = new System.Drawing.Size(120, 26);
            this.FrictionForce_numericUpDown.TabIndex = 3;
            this.FrictionForce_numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.FrictionForce_numericUpDown.ValueChanged += new System.EventHandler(this.FrictionForce_numericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(653, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Внешняя сила";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(838, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Сила трения";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1027, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Кнопки для сдвига рисунка";
            // 
            // Up_button
            // 
            this.Up_button.Location = new System.Drawing.Point(1127, 46);
            this.Up_button.Name = "Up_button";
            this.Up_button.Size = new System.Drawing.Size(50, 40);
            this.Up_button.TabIndex = 7;
            this.Up_button.Text = "Up";
            this.Up_button.UseVisualStyleBackColor = true;
            this.Up_button.Click += new System.EventHandler(this.Up_button_Click);
            // 
            // Down_button
            // 
            this.Down_button.Location = new System.Drawing.Point(1127, 138);
            this.Down_button.Name = "Down_button";
            this.Down_button.Size = new System.Drawing.Size(58, 40);
            this.Down_button.TabIndex = 8;
            this.Down_button.Text = "Down";
            this.Down_button.UseVisualStyleBackColor = true;
            this.Down_button.Click += new System.EventHandler(this.Down_button_Click);
            // 
            // Left_button
            // 
            this.Left_button.Location = new System.Drawing.Point(1058, 94);
            this.Left_button.Name = "Left_button";
            this.Left_button.Size = new System.Drawing.Size(50, 40);
            this.Left_button.TabIndex = 9;
            this.Left_button.Text = "Left";
            this.Left_button.UseVisualStyleBackColor = true;
            this.Left_button.Click += new System.EventHandler(this.Left_button_Click);
            // 
            // Right_button
            // 
            this.Right_button.Location = new System.Drawing.Point(1194, 94);
            this.Right_button.Name = "Right_button";
            this.Right_button.Size = new System.Drawing.Size(50, 40);
            this.Right_button.TabIndex = 10;
            this.Right_button.Text = "Right";
            this.Right_button.UseVisualStyleBackColor = true;
            this.Right_button.Click += new System.EventHandler(this.Right_button_Click);
            // 
            // Delete_button
            // 
            this.Delete_button.Location = new System.Drawing.Point(269, 12);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(155, 93);
            this.Delete_button.TabIndex = 11;
            this.Delete_button.Text = "Удалить колесо";
            this.Delete_button.UseVisualStyleBackColor = true;
            this.Delete_button.Click += new System.EventHandler(this.Delete_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 645);
            this.Controls.Add(this.Delete_button);
            this.Controls.Add(this.Right_button);
            this.Controls.Add(this.Left_button);
            this.Controls.Add(this.Down_button);
            this.Controls.Add(this.Up_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FrictionForce_numericUpDown);
            this.Controls.Add(this.ExternalForce_numericUpDown);
            this.Controls.Add(this.AddToEnd_button);
            this.Name = "MainForm";
            this.Text = "Locomotive wheels";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ExternalForce_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrictionForce_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddToEnd_button;
        private System.Windows.Forms.NumericUpDown ExternalForce_numericUpDown;
        private System.Windows.Forms.NumericUpDown FrictionForce_numericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Up_button;
        private System.Windows.Forms.Button Down_button;
        private System.Windows.Forms.Button Left_button;
        private System.Windows.Forms.Button Right_button;
        private System.Windows.Forms.Button Delete_button;
    }
}

