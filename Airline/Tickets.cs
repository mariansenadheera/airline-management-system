using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline
{
    public partial class Tickets : Form
    {
        public Tickets()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h1 = new HomePage();
            h1.Show();  
        }

        private void btnTicketCancellation_Click(object sender, EventArgs e)
        {
            this.Hide();
            TicketCancellation c1 = new TicketCancellation();
            c1.Show();
        }

        private void btnTicketBooking_Click(object sender, EventArgs e)
        {
            this.Hide();
            ticket_booking b1 = new ticket_booking();
            b1.Show();
        }
    }
}
