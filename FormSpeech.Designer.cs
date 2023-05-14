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
            this.TxtMP3 = new System.Windows.Forms.TextBox();
            this.BtnOpenMP3 = new System.Windows.Forms.Button();
            this.LblMP3 = new System.Windows.Forms.Label();
            this.BtnReadMP3 = new System.Windows.Forms.Button();
            this.LblMP3File = new System.Windows.Forms.Label();
            this.BtnOpenAI = new System.Windows.Forms.Button();
            this.TxtSystem = new System.Windows.Forms.TextBox();
            this.TxtAzure = new System.Windows.Forms.TextBox();
            this.LblOpanAI = new System.Windows.Forms.Label();
            this.LblSystem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtMP3
            // 
            this.TxtMP3.Location = new System.Drawing.Point(12, 30);
            this.TxtMP3.Multiline = true;
            this.TxtMP3.Name = "TxtMP3";
            this.TxtMP3.Size = new System.Drawing.Size(606, 100);
            this.TxtMP3.TabIndex = 7;
            // 
            // BtnOpenMP3
            // 
            this.BtnOpenMP3.Location = new System.Drawing.Point(12, 207);
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
            this.LblMP3.Location = new System.Drawing.Point(12, 149);
            this.LblMP3.Name = "LblMP3";
            this.LblMP3.Size = new System.Drawing.Size(69, 15);
            this.LblMP3.TabIndex = 9;
            this.LblMP3.Text = "MP3 to Text";
            this.LblMP3.UseMnemonic = false;
            // 
            // BtnReadMP3
            // 
            this.BtnReadMP3.Location = new System.Drawing.Point(12, 263);
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
            this.LblMP3File.Location = new System.Drawing.Point(12, 185);
            this.LblMP3File.Name = "LblMP3File";
            this.LblMP3File.Size = new System.Drawing.Size(55, 15);
            this.LblMP3File.TabIndex = 11;
            this.LblMP3File.Text = "MP3 File:";
            this.LblMP3File.UseMnemonic = false;
            // 
            // BtnOpenAI
            // 
            this.BtnOpenAI.Location = new System.Drawing.Point(318, 369);
            this.BtnOpenAI.Name = "BtnOpenAI";
            this.BtnOpenAI.Size = new System.Drawing.Size(300, 50);
            this.BtnOpenAI.TabIndex = 14;
            this.BtnOpenAI.Text = "Run OpenAI";
            this.BtnOpenAI.UseVisualStyleBackColor = true;
            this.BtnOpenAI.Click += new System.EventHandler(this.BtnOpenAI_Click);
            // 
            // TxtSystem
            // 
            this.TxtSystem.Location = new System.Drawing.Point(318, 193);
            this.TxtSystem.Multiline = true;
            this.TxtSystem.Name = "TxtSystem";
            this.TxtSystem.Size = new System.Drawing.Size(300, 170);
            this.TxtSystem.TabIndex = 15;
            // 
            // TxtAzure
            // 
            this.TxtAzure.Location = new System.Drawing.Point(12, 319);
            this.TxtAzure.Multiline = true;
            this.TxtAzure.Name = "TxtAzure";
            this.TxtAzure.Size = new System.Drawing.Size(300, 100);
            this.TxtAzure.TabIndex = 16;
            // 
            // LblOpanAI
            // 
            this.LblOpanAI.AutoSize = true;
            this.LblOpanAI.Location = new System.Drawing.Point(323, 149);
            this.LblOpanAI.Name = "LblOpanAI";
            this.LblOpanAI.Size = new System.Drawing.Size(50, 15);
            this.LblOpanAI.TabIndex = 17;
            this.LblOpanAI.Text = "Opan AI";
            this.LblOpanAI.UseMnemonic = false;
            // 
            // LblSystem
            // 
            this.LblSystem.AutoSize = true;
            this.LblSystem.Location = new System.Drawing.Point(323, 167);
            this.LblSystem.Name = "LblSystem";
            this.LblSystem.Size = new System.Drawing.Size(94, 15);
            this.LblSystem.TabIndex = 18;
            this.LblSystem.Text = "System Message";
            this.LblSystem.UseMnemonic = false;
            // 
            // FormSpeech
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 431);
            this.Controls.Add(this.LblSystem);
            this.Controls.Add(this.LblOpanAI);
            this.Controls.Add(this.TxtAzure);
            this.Controls.Add(this.TxtSystem);
            this.Controls.Add(this.BtnOpenAI);
            this.Controls.Add(this.LblMP3File);
            this.Controls.Add(this.BtnReadMP3);
            this.Controls.Add(this.LblMP3);
            this.Controls.Add(this.BtnOpenMP3);
            this.Controls.Add(this.TxtMP3);
            this.Name = "FormSpeech";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormSpeech_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox TxtMP3;
        private Button BtnOpenMP3;
        private Label LblMP3;
        private Button BtnReadMP3;
        private Label LblMP3File;
        private Button BtnOpenAI;
        private TextBox TxtSystem;
        private TextBox TxtAzure;
        private Label LblOpanAI;
        private Label LblSystem;
    }
}