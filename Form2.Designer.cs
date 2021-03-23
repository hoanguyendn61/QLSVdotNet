
namespace qlSVwinform
{
    partial class Form2
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
            this.loginControl11 = new LoginControl.LoginControl1();
            this.SuspendLayout();
            // 
            // loginControl11
            // 
            this.loginControl11.Location = new System.Drawing.Point(201, 132);
            this.loginControl11.Name = "loginControl11";
            this.loginControl11.pass = "";
            this.loginControl11.Size = new System.Drawing.Size(329, 209);
            this.loginControl11.TabIndex = 0;
            this.loginControl11.user = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 473);
            this.Controls.Add(this.loginControl11);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private LoginControl.LoginControl1 loginControl11;
    }
}