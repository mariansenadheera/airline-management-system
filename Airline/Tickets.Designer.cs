
namespace Airline
{
    partial class Tickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tickets));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTicketBooking = new System.Windows.Forms.Button();
            this.btnTicketCancellation = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(125, 77);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(239, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Ticket";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnTicketBooking
            // 
            this.btnTicketBooking.BackColor = System.Drawing.Color.SteelBlue;
            this.btnTicketBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTicketBooking.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTicketBooking.Location = new System.Drawing.Point(279, 110);
            this.btnTicketBooking.Name = "btnTicketBooking";
            this.btnTicketBooking.Size = new System.Drawing.Size(231, 54);
            this.btnTicketBooking.TabIndex = 17;
            this.btnTicketBooking.Text = "Ticket Booking";
            this.btnTicketBooking.UseVisualStyleBackColor = false;
            this.btnTicketBooking.Click += new System.EventHandler(this.btnTicketBooking_Click);
            // 
            // btnTicketCancellation
            // 
            this.btnTicketCancellation.BackColor = System.Drawing.Color.SteelBlue;
            this.btnTicketCancellation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTicketCancellation.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTicketCancellation.Location = new System.Drawing.Point(27, 110);
            this.btnTicketCancellation.Name = "btnTicketCancellation";
            this.btnTicketCancellation.Size = new System.Drawing.Size(231, 54);
            this.btnTicketCancellation.TabIndex = 16;
            this.btnTicketCancellation.Text = "Ticket Cancellations";
            this.btnTicketCancellation.UseVisualStyleBackColor = false;
            this.btnTicketCancellation.Click += new System.EventHandler(this.btnTicketCancellation_Click);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Silver;
            this.btnback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.Location = new System.Drawing.Point(390, 179);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(120, 49);
            this.btnback.TabIndex = 21;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // Tickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(546, 252);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btnTicketBooking);
            this.Controls.Add(this.btnTicketCancellation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Tickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tickets";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTicketBooking;
        private System.Windows.Forms.Button btnTicketCancellation;
        private System.Windows.Forms.Button btnback;
    }
}