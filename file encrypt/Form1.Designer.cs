namespace file_encrypt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tbPath = new TextBox();
            btBrowse = new Button();
            rdEncrypt = new RadioButton();
            rdDecrypt = new RadioButton();
            label2 = new Label();
            tbPassword = new TextBox();
            btStart = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 0;
            label1.Text = "File Path";
            // 
            // tbPath
            // 
            tbPath.Location = new Point(12, 27);
            tbPath.Multiline = true;
            tbPath.Name = "tbPath";
            tbPath.ReadOnly = true;
            tbPath.Size = new Size(303, 23);
            tbPath.TabIndex = 1;
            // 
            // btBrowse
            // 
            btBrowse.Location = new Point(321, 27);
            btBrowse.Name = "btBrowse";
            btBrowse.Size = new Size(75, 23);
            btBrowse.TabIndex = 2;
            btBrowse.Text = "Browse";
            btBrowse.UseVisualStyleBackColor = true;
            btBrowse.Click += btBrowse_Click;
            // 
            // rdEncrypt
            // 
            rdEncrypt.AutoSize = true;
            rdEncrypt.Location = new Point(12, 67);
            rdEncrypt.Name = "rdEncrypt";
            rdEncrypt.Size = new Size(65, 19);
            rdEncrypt.TabIndex = 3;
            rdEncrypt.TabStop = true;
            rdEncrypt.Text = "Encrypt";
            rdEncrypt.UseVisualStyleBackColor = true;
            rdEncrypt.CheckedChanged += rdEncrypt_CheckedChanged;
            // 
            // rdDecrypt
            // 
            rdDecrypt.AutoSize = true;
            rdDecrypt.Location = new Point(83, 67);
            rdDecrypt.Name = "rdDecrypt";
            rdDecrypt.Size = new Size(66, 19);
            rdDecrypt.TabIndex = 4;
            rdDecrypt.TabStop = true;
            rdDecrypt.Text = "Decrypt";
            rdDecrypt.UseVisualStyleBackColor = true;
            rdDecrypt.CheckedChanged += rdDecrypt_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 101);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 5;
            label2.Text = "Password";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(70, 101);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '.';
            tbPassword.Size = new Size(245, 23);
            tbPassword.TabIndex = 6;
            // 
            // btStart
            // 
            btStart.Location = new Point(23, 154);
            btStart.Name = "btStart";
            btStart.Size = new Size(373, 38);
            btStart.TabIndex = 7;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 219);
            Controls.Add(btStart);
            Controls.Add(tbPassword);
            Controls.Add(label2);
            Controls.Add(rdDecrypt);
            Controls.Add(rdEncrypt);
            Controls.Add(btBrowse);
            Controls.Add(tbPath);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "File Encrypt Decrypt substitution cipher ";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbPath;
        private Button btBrowse;
        private RadioButton rdEncrypt;
        private RadioButton rdDecrypt;
        private Label label2;
        private TextBox tbPassword;
        private Button btStart;
    }
}