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
            this.TxtMP3 = new System.Windows.Forms.TextBox();
            this.BtnOpenMP3 = new System.Windows.Forms.Button();
            this.LblMP3 = new System.Windows.Forms.Label();
            this.BtnReadMP3 = new System.Windows.Forms.Button();
            this.LblMP3File = new System.Windows.Forms.Label();
            this.BtnTryFunction = new System.Windows.Forms.Button();
            this.BtnSpeechSDK = new System.Windows.Forms.Button();
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
            this.LblRead.Size = new System.Drawing.Size(83, 15);
            this.LblRead.TabIndex = 4;
            this.LblRead.Text = "Speech to Text";
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
            // TxtMP3
            // 
            this.TxtMP3.Location = new System.Drawing.Point(624, 59);
            this.TxtMP3.Multiline = true;
            this.TxtMP3.Name = "TxtMP3";
            this.TxtMP3.Size = new System.Drawing.Size(300, 100);
            this.TxtMP3.TabIndex = 7;
            // 
            // BtnOpenMP3
            // 
            this.BtnOpenMP3.Location = new System.Drawing.Point(624, 165);
            this.BtnOpenMP3.Name = "BtnOpenMP3";
            this.BtnOpenMP3.Size = new System.Drawing.Size(300, 50);
            this.BtnOpenMP3.TabIndex = 8;
            this.BtnOpenMP3.Text = "Open MP3";
            this.BtnOpenMP3.UseVisualStyleBackColor = true;
            this.BtnOpenMP3.Click += new System.EventHandler(this.BtnOpenMP3_Click);
            // 
            // LblMP3
            // 
            this.LblMP3.AutoSize = true;
            this.LblMP3.Location = new System.Drawing.Point(624, 41);
            this.LblMP3.Name = "LblMP3";
            this.LblMP3.Size = new System.Drawing.Size(69, 15);
            this.LblMP3.TabIndex = 9;
            this.LblMP3.Text = "MP3 to Text";
            this.LblMP3.UseMnemonic = false;
            // 
            // BtnReadMP3
            // 
            this.BtnReadMP3.Location = new System.Drawing.Point(624, 277);
            this.BtnReadMP3.Name = "BtnReadMP3";
            this.BtnReadMP3.Size = new System.Drawing.Size(300, 50);
            this.BtnReadMP3.TabIndex = 10;
            this.BtnReadMP3.Text = "Read MP3";
            this.BtnReadMP3.UseVisualStyleBackColor = true;
            this.BtnReadMP3.Click += new System.EventHandler(this.BtnReadMP3_Click);
            // 
            // LblMP3File
            // 
            this.LblMP3File.AutoSize = true;
            this.LblMP3File.Location = new System.Drawing.Point(624, 218);
            this.LblMP3File.Name = "LblMP3File";
            this.LblMP3File.Size = new System.Drawing.Size(55, 15);
            this.LblMP3File.TabIndex = 11;
            this.LblMP3File.Text = "MP3 File:";
            this.LblMP3File.UseMnemonic = false;
            // 
            // BtnTryFunction
            // 
            this.BtnTryFunction.Location = new System.Drawing.Point(12, 277);
            this.BtnTryFunction.Name = "BtnTryFunction";
            this.BtnTryFunction.Size = new System.Drawing.Size(300, 50);
            this.BtnTryFunction.TabIndex = 12;
            this.BtnTryFunction.Text = "Try Function";
            this.BtnTryFunction.UseVisualStyleBackColor = true;
            this.BtnTryFunction.Click += new System.EventHandler(this.BtnTryFunction_Click);
            // 
            // BtnSpeechSDK
            // 
            this.BtnSpeechSDK.Location = new System.Drawing.Point(318, 277);
            this.BtnSpeechSDK.Name = "BtnSpeechSDK";
            this.BtnSpeechSDK.Size = new System.Drawing.Size(300, 50);
            this.BtnSpeechSDK.TabIndex = 13;
            this.BtnSpeechSDK.Text = "Try Speech SDK";
            this.BtnSpeechSDK.UseVisualStyleBackColor = true;
            this.BtnSpeechSDK.Click += new System.EventHandler(this.BtnSpeechSDK_Click);
            // 
            // FormSpeech
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 339);
            this.Controls.Add(this.BtnSpeechSDK);
            this.Controls.Add(this.BtnTryFunction);
            this.Controls.Add(this.LblMP3File);
            this.Controls.Add(this.BtnReadMP3);
            this.Controls.Add(this.LblMP3);
            this.Controls.Add(this.BtnOpenMP3);
            this.Controls.Add(this.TxtMP3);
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
        private TextBox TxtMP3;
        private Button BtnOpenMP3;
        private Label LblMP3;
        private Button BtnReadMP3;
        private Label LblMP3File;
        private Button BtnTryFunction;
        private Button BtnSpeechSDK;
    }
}