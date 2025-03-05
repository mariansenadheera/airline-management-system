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
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnpassRep_Click(object sender, EventArgs e)
        {
            this.Hide();
            PassengerReportView v1 = new PassengerReportView();
            v1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FlightReportView v1 = new FlightReportView();
            v1.Show();
        }
    }
}
