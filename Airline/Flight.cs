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
    public partial class Flight : Form
    {
        public Flight()
        {
            InitializeComponent();
        }

        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h1 = new HomePage();
            h1.Show();
        }

        private void btnrecord_Click(object sender, EventArgs e)
        {
            this.Hide();
            Record_Flight r1 = new Record_Flight();
            r1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flight_View v1 = new Flight_View();
            v1.Show();
        }
    }
}
