namespace OpenAIChatgpt
{
    partial class FormSpeech
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
            this.BtnListen = new System.Windows.Forms.Button();
            this.LblListen = new System.Windows.Forms.Label();
            this.TxtListen = new System.Windows.Forms.TextBox();
            this.LblRead = new System.Windows.Forms.Label();
            this.TxtRead = new System.Windows.Forms.TextBox();
            this.BtnRead = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnListen
            // 
            this.BtnListen.Location = new System.Drawing.Point(12, 165);
            this.BtnListen.Name = "BtnListen";
            this.BtnListen.Size = new System.Drawing.Size(300, 50);
            this.BtnListen.TabIndex = 0;
            this.BtnListen.Text = "Listen";
            this.BtnListen.UseVisualStyleBackColor = true;
            this.BtnListen.Click += new System.EventHandler(this.BtnListen_Click);
            // 
            // LblListen
            // 
            this.LblListen.AutoSize = true;
            this.LblListen.Location = new System.Drawing.Point(12, 41);
            this.LblListen.Name = "LblListen";
            this.LblListen.Size = new System.Drawing.Size(83, 15);
            this.LblListen.TabIndex = 2;
            this.LblListen.Text = "Text to Speech";
            // 
            // TxtListen
            // 
            this.TxtListen.Location = new System.Drawing.Point(12, 59);
            this.TxtListen.Multiline = true;
            this.TxtListen.Name = "TxtListen";
            this.TxtListen.Size = new System.Drawing.Size(300, 100);
            this.TxtListen.TabIndex = 3;
            // 
            // LblRead
            // 
            this.LblRead.AutoSize = true;
            this.LblRead.Location = new System.Drawing.Point(318, 41);
            this.LblRead.Name = "LblRead";
            this.LblRead.Size = new System.Drawing.Size(86, 15);
            this.LblRead.TabIndex = 4;
            this.LblRead.Text = " Speech to Text";
            // 
            // TxtRead
            // 
            this.TxtRead.Location = new System.Drawing.Point(318, 59);
            this.TxtRead.Multiline = true;
            this.TxtRead.Name = "TxtRead";
            this.TxtRead.Size = new System.Drawing.Size(300, 100);
            this.TxtRead.TabIndex = 5;
            // 
            // BtnRead
            // 
            this.BtnRead.Location = new System.Drawing.Point(318, 165);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(300, 50);
            this.BtnRead.TabIndex = 6;
            this.BtnRead.Text = "Read";
            this.BtnRead.UseVisualStyleBackColor = true;
            this.BtnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // FormSpeech
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 238);
            this.Controls.Add(this.BtnRead);
            this.Controls.Add(this.TxtRead);
            this.Controls.Add(this.LblRead);
            this.Controls.Add(this.TxtListen);
            this.Controls.Add(this.LblListen);
            this.Controls.Add(this.BtnListen);
            this.Name = "FormSpeech";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormSpeech_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BtnListen;
        private Label LblListen;
        private TextBox TxtListen;
        private Label LblRead;
        private TextBox TxtRead;
        private Button BtnRead;
    }
}