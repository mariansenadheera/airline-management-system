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
    public partial class Passenger : Form
    {
        public Passenger()
        {
            InitializeComponent();
        }

        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnrecord_Click(object sender, EventArgs e)
        {
            this.Close();
            PassengerRegistration r1 = new PassengerRegistration();
            r1.Show();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h1 = new HomePage();
            h1.Show();
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewPassengers v1 = new ViewPassengers();   
            v1.Show();
        }
    }
}
