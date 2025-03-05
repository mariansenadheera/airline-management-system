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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void btnPassengers_Click(object sender, EventArgs e)
        {
            
            Passenger p1 = new Passenger();
            p1.MdiParent = this;
            p1.Show();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void recordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPassengers_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Passenger p1 = new Passenger();
            p1.Show();
        }

        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void passengersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();    
            PassengerRegistration p1 = new PassengerRegistration();
            p1.Show();
        }

        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewPassengers v1 = new ViewPassengers();
            v1.Show();
        }

        private void btnflights_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flight f1 = new Flight();
            f1.Show();

        }

        private void flightsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Record_Flight f1 = new Record_Flight();
            f1.Show();
        }

        private void flightsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flight_View v1 = new Flight_View();
            v1.Show();
        }

        private void btntickets_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tickets t1 = new Tickets();
            t1.Show();
        }

        private void ticketsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ticket_booking b1 = new ticket_booking();
            b1.Show();
        }

        private void passengerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            TicketCancellation c1 = new TicketCancellation();
            c1.Show();
        }

        private void btncancellations_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cancellation c1 = new Cancellation();
            c1.Show();
        }

        private void flightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FlightCancellations c1 = new FlightCancellations();
            c1.Show();
        }

        private void passengerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewPassengers v1 = new ViewPassengers();
            v1.Show();
        }

        private void passengerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewPassengers v1 = new ViewPassengers();
            v1.Show();
        }

        private void flightToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flight_View v1 = new Flight_View();
            v1.Show();
        }

        private void flightToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flight_View v1 = new Flight_View();
            v1.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            report r1 = new report();
            r1.Show();

        }

        private void passengersByNationalityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PassengerReportView v1 = new PassengerReportView(); 
            v1.Show();
        }

        private void flightReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FlightReportView v1 = new FlightReportView();   
            v1.Show();
        }

        private void passengersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l1 = new Login();
            l1.Show();
        }

        private void flightsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Record_Flight r1 = new Record_Flight();
            r1.Show();
        }
    }
}
