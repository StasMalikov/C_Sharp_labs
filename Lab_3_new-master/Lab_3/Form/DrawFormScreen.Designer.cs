namespace Lab_2
{
    partial class DrawFormScreen
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
            this.SuspendLayout();
            // 
            // DrawFormScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.DoubleBuffered = true;
            this.Name = "DrawFormScreen";
            this.Text = "DrawFormScreen";
            this.Load += new System.EventHandler(this.DrawFormScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawFormScreen_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawFormScreen_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawFormScreen_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawFormScreen_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}