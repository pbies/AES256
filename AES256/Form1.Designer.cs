namespace AES256
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
            this.EncryptBtn = new System.Windows.Forms.Button();
            this.DecryptBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.InfoBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EncryptBtn
            // 
            this.EncryptBtn.AllowDrop = true;
            this.EncryptBtn.Location = new System.Drawing.Point(13, 13);
            this.EncryptBtn.Name = "EncryptBtn";
            this.EncryptBtn.Size = new System.Drawing.Size(259, 100);
            this.EncryptBtn.TabIndex = 0;
            this.EncryptBtn.Text = "Encrypt";
            this.EncryptBtn.UseVisualStyleBackColor = true;
            this.EncryptBtn.Click += new System.EventHandler(this.EncryptBtn_Click);
            this.EncryptBtn.DragDrop += new System.Windows.Forms.DragEventHandler(this.EncryptBtn_DragDrop);
            this.EncryptBtn.DragEnter += new System.Windows.Forms.DragEventHandler(this.EncryptBtn_DragEnter);
            // 
            // DecryptBtn
            // 
            this.DecryptBtn.AllowDrop = true;
            this.DecryptBtn.Location = new System.Drawing.Point(13, 119);
            this.DecryptBtn.Name = "DecryptBtn";
            this.DecryptBtn.Size = new System.Drawing.Size(259, 100);
            this.DecryptBtn.TabIndex = 1;
            this.DecryptBtn.Text = "Decrypt";
            this.DecryptBtn.UseVisualStyleBackColor = true;
            this.DecryptBtn.Click += new System.EventHandler(this.DecryptBtn_Click);
            this.DecryptBtn.DragDrop += new System.Windows.Forms.DragEventHandler(this.DecryptBtn_DragDrop);
            this.DecryptBtn.DragEnter += new System.Windows.Forms.DragEventHandler(this.DecryptBtn_DragEnter);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 225);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(237, 20);
            this.textBox1.TabIndex = 2;
            // 
            // InfoBtn
            // 
            this.InfoBtn.Location = new System.Drawing.Point(256, 225);
            this.InfoBtn.Name = "InfoBtn";
            this.InfoBtn.Size = new System.Drawing.Size(16, 20);
            this.InfoBtn.TabIndex = 3;
            this.InfoBtn.Text = "i";
            this.InfoBtn.UseVisualStyleBackColor = true;
            this.InfoBtn.Click += new System.EventHandler(this.InfoBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 258);
            this.Controls.Add(this.InfoBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DecryptBtn);
            this.Controls.Add(this.EncryptBtn);
            this.Name = "Form1";
            this.Text = "AES256 v1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EncryptBtn;
        private System.Windows.Forms.Button DecryptBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button InfoBtn;
    }
}

