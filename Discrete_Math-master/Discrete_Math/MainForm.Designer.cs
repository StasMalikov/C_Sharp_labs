namespace Discrete_Math
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BinaryInsertionSort_button = new System.Windows.Forms.Button();
            this.InsertionSort_button = new System.Windows.Forms.Button();
            this.BinarySearch_button = new System.Windows.Forms.Button();
            this.SequentialSearch_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.SortArr_button = new System.Windows.Forms.Button();
            this.FindNumber_textBox = new System.Windows.Forms.TextBox();
            this.SetArr_button = new System.Windows.Forms.Button();
            this.CountOfArr_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Result_textBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.SortArr_textBox = new System.Windows.Forms.TextBox();
            this.Arr_textBox = new System.Windows.Forms.TextBox();
            this.Bubble_button = new System.Windows.Forms.Button();
            this.Shell_button = new System.Windows.Forms.Button();
            this.BackSort_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Step_textBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Result_textBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1377, 577);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.45647F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.54353F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 268F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 384F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tableLayoutPanel2.Controls.Add(this.Shell_button, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.BinaryInsertionSort_button, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.InsertionSort_button, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BinarySearch_button, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.SequentialSearch_button, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Bubble_button, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1371, 64);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // BinaryInsertionSort_button
            // 
            this.BinaryInsertionSort_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BinaryInsertionSort_button.Location = new System.Drawing.Point(140, 3);
            this.BinaryInsertionSort_button.Name = "BinaryInsertionSort_button";
            this.BinaryInsertionSort_button.Size = new System.Drawing.Size(244, 58);
            this.BinaryInsertionSort_button.TabIndex = 4;
            this.BinaryInsertionSort_button.Text = "Бинарная \r\nсортировка вставками";
            this.BinaryInsertionSort_button.UseVisualStyleBackColor = true;
            this.BinaryInsertionSort_button.Click += new System.EventHandler(this.BinaryInsertionSort_button_Click);
            // 
            // InsertionSort_button
            // 
            this.InsertionSort_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InsertionSort_button.Location = new System.Drawing.Point(390, 3);
            this.InsertionSort_button.Name = "InsertionSort_button";
            this.InsertionSort_button.Size = new System.Drawing.Size(262, 58);
            this.InsertionSort_button.TabIndex = 3;
            this.InsertionSort_button.Text = "Сортировка \r\nвставками";
            this.InsertionSort_button.UseVisualStyleBackColor = true;
            this.InsertionSort_button.Click += new System.EventHandler(this.InsertionSort_button_Click);
            // 
            // BinarySearch_button
            // 
            this.BinarySearch_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BinarySearch_button.Location = new System.Drawing.Point(658, 3);
            this.BinarySearch_button.Name = "BinarySearch_button";
            this.BinarySearch_button.Size = new System.Drawing.Size(378, 58);
            this.BinarySearch_button.TabIndex = 1;
            this.BinarySearch_button.Text = "Бинарный поиск";
            this.BinarySearch_button.UseVisualStyleBackColor = true;
            this.BinarySearch_button.Click += new System.EventHandler(this.BinarySearch_button_Click);
            // 
            // SequentialSearch_button
            // 
            this.SequentialSearch_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SequentialSearch_button.Location = new System.Drawing.Point(3, 3);
            this.SequentialSearch_button.Name = "SequentialSearch_button";
            this.SequentialSearch_button.Size = new System.Drawing.Size(131, 58);
            this.SequentialSearch_button.TabIndex = 0;
            this.SequentialSearch_button.Text = "Последовательный поиск";
            this.SequentialSearch_button.UseVisualStyleBackColor = true;
            this.SequentialSearch_button.Click += new System.EventHandler(this.SequentialSearch_button_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 8;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.55396F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.44604F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel3.Controls.Add(this.SortArr_button, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.FindNumber_textBox, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.SetArr_button, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.CountOfArr_textBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.BackSort_button, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.Step_textBox, 7, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 73);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1371, 64);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // SortArr_button
            // 
            this.SortArr_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SortArr_button.Location = new System.Drawing.Point(884, 3);
            this.SortArr_button.Name = "SortArr_button";
            this.SortArr_button.Size = new System.Drawing.Size(169, 58);
            this.SortArr_button.TabIndex = 7;
            this.SortArr_button.Text = "Задать упорядоченный\r\nмассив";
            this.SortArr_button.UseVisualStyleBackColor = true;
            this.SortArr_button.Click += new System.EventHandler(this.SortArr_button_Click);
            // 
            // FindNumber_textBox
            // 
            this.FindNumber_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FindNumber_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FindNumber_textBox.Location = new System.Drawing.Point(737, 3);
            this.FindNumber_textBox.Multiline = true;
            this.FindNumber_textBox.Name = "FindNumber_textBox";
            this.FindNumber_textBox.Size = new System.Drawing.Size(141, 58);
            this.FindNumber_textBox.TabIndex = 4;
            // 
            // SetArr_button
            // 
            this.SetArr_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetArr_button.Location = new System.Drawing.Point(3, 3);
            this.SetArr_button.Name = "SetArr_button";
            this.SetArr_button.Size = new System.Drawing.Size(318, 58);
            this.SetArr_button.TabIndex = 1;
            this.SetArr_button.Text = "Задать рандомный массив";
            this.SetArr_button.UseVisualStyleBackColor = true;
            this.SetArr_button.Click += new System.EventHandler(this.SetArr_button_Click);
            // 
            // CountOfArr_textBox
            // 
            this.CountOfArr_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CountOfArr_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountOfArr_textBox.Location = new System.Drawing.Point(327, 3);
            this.CountOfArr_textBox.Multiline = true;
            this.CountOfArr_textBox.Name = "CountOfArr_textBox";
            this.CountOfArr_textBox.Size = new System.Drawing.Size(233, 58);
            this.CountOfArr_textBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(566, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 64);
            this.label1.TabIndex = 3;
            this.label1.Text = "Искомое число:";
            // 
            // Result_textBox
            // 
            this.Result_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Result_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Result_textBox.Location = new System.Drawing.Point(3, 527);
            this.Result_textBox.Multiline = true;
            this.Result_textBox.Name = "Result_textBox";
            this.Result_textBox.Size = new System.Drawing.Size(1371, 47);
            this.Result_textBox.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.97403F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.10386F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.93509F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.987017F));
            this.tableLayoutPanel4.Controls.Add(this.SortArr_textBox, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.Arr_textBox, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 143);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1371, 378);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // SortArr_textBox
            // 
            this.SortArr_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SortArr_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SortArr_textBox.Location = new System.Drawing.Point(276, 3);
            this.SortArr_textBox.Multiline = true;
            this.SortArr_textBox.Name = "SortArr_textBox";
            this.SortArr_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SortArr_textBox.Size = new System.Drawing.Size(269, 372);
            this.SortArr_textBox.TabIndex = 1;
            // 
            // Arr_textBox
            // 
            this.Arr_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Arr_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Arr_textBox.Location = new System.Drawing.Point(3, 3);
            this.Arr_textBox.Multiline = true;
            this.Arr_textBox.Name = "Arr_textBox";
            this.Arr_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Arr_textBox.Size = new System.Drawing.Size(267, 372);
            this.Arr_textBox.TabIndex = 0;
            // 
            // Bubble_button
            // 
            this.Bubble_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bubble_button.Location = new System.Drawing.Point(1042, 3);
            this.Bubble_button.Name = "Bubble_button";
            this.Bubble_button.Size = new System.Drawing.Size(152, 58);
            this.Bubble_button.TabIndex = 5;
            this.Bubble_button.Text = "Bubble";
            this.Bubble_button.UseVisualStyleBackColor = true;
            this.Bubble_button.Click += new System.EventHandler(this.Bubble_button_Click);
            // 
            // Shell_button
            // 
            this.Shell_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Shell_button.Location = new System.Drawing.Point(1200, 3);
            this.Shell_button.Name = "Shell_button";
            this.Shell_button.Size = new System.Drawing.Size(168, 58);
            this.Shell_button.TabIndex = 6;
            this.Shell_button.Text = "Shell";
            this.Shell_button.UseVisualStyleBackColor = true;
            this.Shell_button.Click += new System.EventHandler(this.Shell_button_Click);
            // 
            // BackSort_button
            // 
            this.BackSort_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackSort_button.Location = new System.Drawing.Point(1059, 3);
            this.BackSort_button.Name = "BackSort_button";
            this.BackSort_button.Size = new System.Drawing.Size(122, 58);
            this.BackSort_button.TabIndex = 8;
            this.BackSort_button.Text = "Обратный порядок ";
            this.BackSort_button.UseVisualStyleBackColor = true;
            this.BackSort_button.Click += new System.EventHandler(this.BackSort_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(1187, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 64);
            this.label2.TabIndex = 9;
            this.label2.Text = "Шаг:";
            // 
            // Step_textBox
            // 
            this.Step_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Step_textBox.Location = new System.Drawing.Point(1299, 3);
            this.Step_textBox.Multiline = true;
            this.Step_textBox.Name = "Step_textBox";
            this.Step_textBox.Size = new System.Drawing.Size(69, 58);
            this.Step_textBox.TabIndex = 10;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 577);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BinarySearch_button;
        private System.Windows.Forms.Button SequentialSearch_button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button SetArr_button;
        private System.Windows.Forms.TextBox CountOfArr_textBox;
        private System.Windows.Forms.TextBox Result_textBox;
        private System.Windows.Forms.TextBox FindNumber_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SortArr_button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox Arr_textBox;
        private System.Windows.Forms.TextBox SortArr_textBox;
        private System.Windows.Forms.Button InsertionSort_button;
        private System.Windows.Forms.Button BinaryInsertionSort_button;
        private System.Windows.Forms.Button Shell_button;
        private System.Windows.Forms.Button Bubble_button;
        private System.Windows.Forms.Button BackSort_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Step_textBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

