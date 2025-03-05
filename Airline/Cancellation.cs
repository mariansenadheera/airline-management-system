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
    public partial class Cancellation : Form
    {
        public Cancellation()
        {
            InitializeComponent();
        }

        private void Cancellation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TicketCancellation c1 = new TicketCancellation();
            c1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FlightCancellations c1 = new FlightCancellations();
            c1.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h1 = new HomePage();
            h1.Show();
        }
    }
}
