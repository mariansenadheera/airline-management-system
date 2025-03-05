using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline
{
    public partial class Record_Flight : Form
    {
        public Record_Flight()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //create a connection with mssql server
            string cs = @"Data Source = Mari; 
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            if (this.txtfcode.Text == "" || this.cmborigin.Text == "" || this.cmbdestination.Text == "" || this.dtptakeoff.Text == ""
                || this.nudseats.Text == "")
            {
                MessageBox.Show("All fields are required to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {
                    con.Open();

                    //Define a command
                    String sql = "INSERT INTO tblFlight VALUES (@fCode,@fOrigin,@fDestination,@fTakeOff,@fSeats)";
                    SqlCommand com = new SqlCommand(sql, con);
                    com.Parameters.AddWithValue("@fCode", this.txtfcode.Text);
                    com.Parameters.AddWithValue("@fOrigin", this.cmborigin.Text);
                    com.Parameters.AddWithValue("@fDestination", this.cmbdestination.Text);
                    com.Parameters.AddWithValue("@fTakeOff", this.dtptakeoff.Text);
                    com.Parameters.AddWithValue("@fSeats", this.nudseats.Text);

                    //Execute command and access data using Data Adaptor method
                    int ret = com.ExecuteNonQuery();
                    MessageBox.Show("No of records inserted:" + ret, "Information");


                    //Disconnect from the server
                    con.Close();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);


                }
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            this.txtfcode.Clear();
            this.cmborigin.SelectedIndex = -1;
            this.cmbdestination.SelectedIndex = -1;
            this.nudseats.Value = 0;


        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h1 = new HomePage();
            h1.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Flight_View v1 = new Flight_View();
            v1.Show();
        }
    }
}
