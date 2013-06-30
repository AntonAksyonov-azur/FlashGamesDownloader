namespace FlashGamesDownloader
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.tbSource = new System.Windows.Forms.TextBox();
            this.tbReg = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(907, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbSource
            // 
            this.tbSource.Location = new System.Drawing.Point(12, 12);
            this.tbSource.MaxLength = 128000;
            this.tbSource.Multiline = true;
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(250, 187);
            this.tbSource.TabIndex = 1;
            // 
            // tbReg
            // 
            this.tbReg.Location = new System.Drawing.Point(268, 12);
            this.tbReg.Name = "tbReg";
            this.tbReg.Size = new System.Drawing.Size(633, 20);
            this.tbReg.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(268, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(714, 160);
            this.listBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 219);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tbReg);
            this.Controls.Add(this.tbSource);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.TextBox tbReg;
        private System.Windows.Forms.ListBox listBox1;
    }
}