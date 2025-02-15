using System.Windows.Forms;

namespace ConvertP12App
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtFilePath;
        private Button btnBrowse;
        private Button btnConvert;
        private TextBox txtLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txt_pin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(56, 28);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(256, 20);
            this.txtFilePath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(318, 26);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Examinar";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(12, 54);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(381, 23);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Convertir";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtLog.Location = new System.Drawing.Point(12, 83);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(381, 150);
            this.txtLog.TabIndex = 4;
            // 
            // txt_pin
            // 
            this.txt_pin.Location = new System.Drawing.Point(12, 28);
            this.txt_pin.Name = "txt_pin";
            this.txt_pin.PasswordChar = '*';
            this.txt_pin.Size = new System.Drawing.Size(38, 20);
            this.txt_pin.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ruta al archivo .p12";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 245);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_pin);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "P12 Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox txt_pin;
        private Label label1;
        private Label label2;
    }
}