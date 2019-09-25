namespace ImageFilteringMMS
{
    partial class ColorInput
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.RedColor = new System.Windows.Forms.TextBox();
            this.GreenColor = new System.Windows.Forms.TextBox();
            this.BlueColor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(46, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Blue";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(46, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Green";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(46, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Red";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Enter values between .2 and 5";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(38, 156);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 19;
            this.OK.Text = "OK";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(126, 156);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 18;
            this.Cancel.Text = "Cancel";
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // RedColor
            // 
            this.RedColor.Location = new System.Drawing.Point(101, 49);
            this.RedColor.Name = "RedColor";
            this.RedColor.Size = new System.Drawing.Size(100, 20);
            this.RedColor.TabIndex = 26;
            // 
            // GreenColor
            // 
            this.GreenColor.Location = new System.Drawing.Point(101, 81);
            this.GreenColor.Name = "GreenColor";
            this.GreenColor.Size = new System.Drawing.Size(100, 20);
            this.GreenColor.TabIndex = 27;
            // 
            // BlueColor
            // 
            this.BlueColor.Location = new System.Drawing.Point(101, 116);
            this.BlueColor.Name = "BlueColor";
            this.BlueColor.Size = new System.Drawing.Size(100, 20);
            this.BlueColor.TabIndex = 28;
            // 
            // ColorInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 215);
            this.Controls.Add(this.BlueColor);
            this.Controls.Add(this.GreenColor);
            this.Controls.Add(this.RedColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.Name = "ColorInput";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox RedColor;
        private System.Windows.Forms.TextBox GreenColor;
        private System.Windows.Forms.TextBox BlueColor;
    }
}