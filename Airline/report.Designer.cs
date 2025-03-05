namespace Airline
{
    partial class report
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
            this.btnpassRep = new System.Windows.Forms.Button();
            this.lblclose = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(427, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 54);
            this.button1.TabIndex = 40;
            this.button1.Text = "View Flight Report";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnpassRep
            // 
            this.btnpassRep.BackColor = System.Drawing.Color.Silver;
            this.btnpassRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpassRep.ForeColor = System.Drawing.Color.Black;
            this.btnpassRep.Location = new System.Drawing.Point(104, 115);
            this.btnpassRep.Name = "btnpassRep";
            this.btnpassRep.Size = new System.Drawing.Size(231, 97);
            this.btnpassRep.TabIndex = 39;
            this.btnpassRep.Text = "View Passenger by Nationality";
            this.btnpassRep.UseVisualStyleBackColor = false;
            this.btnpassRep.Click += new System.EventHandler(this.btnpassRep_Click);
            // 
            // lblclose
            // 
            this.lblclose.AutoSize = true;
            this.lblclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclose.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblclose.Location = new System.Drawing.Point(743, 10);
            this.lblclose.Name = "lblclose";
            this.lblclose.Size = new System.Drawing.Size(34, 32);
            this.lblclose.TabIndex = 38;
            this.lblclose.Text = "X";
            this.lblclose.Click += new System.EventHandler(this.lblclose_Click);
            // 
            // report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnpassRep);
            this.Controls.Add(this.lblclose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "report";
            this.Text = "report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnpassRep;
        private System.Windows.Forms.Label lblclose;
    }
}