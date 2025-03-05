using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Airline
{
    public partial class PassengerRegistration : Form
    {
        string Gender;
        public PassengerRegistration()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {

            //creating a connection with mysql server
            string cs = @"Data Source = Mari;
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);
            if (txtPassengerID.Text == "" || txtPassportNo.Text == "" || txtName.Text == "" || txtAddress.Text == "" || txtTel.Text == "" || comboNationality.Text == "" || Gender == "")
            {
                MessageBox.Show("All fields are required to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {
                    con.Open();

                    //Define a command
                    string sql = "INSERT INTO tblPassenger VALUES (@PassengerID,@PassengerNo,@Name,@Address,@MobileNo,@Nationality,@Gender)";
                    SqlCommand com = new SqlCommand(sql, con);
                    com.Parameters.AddWithValue("@PassengerID", txtPassengerID.Text);
                    com.Parameters.AddWithValue("@PassengerNo", txtPassportNo.Text);
                    com.Parameters.AddWithValue("@Name", txtName.Text);
                    com.Parameters.AddWithValue("@Address", txtAddress.Text);
                    com.Parameters.AddWithValue("@MobileNo", txtTel.Text);
                    com.Parameters.AddWithValue("@Nationality", comboNationality.Text);
                    com.Parameters.AddWithValue("@Gender", Gender);

                    //Execute command and access data using data adapter method
                    com.ExecuteNonQuery();
                    MessageBox.Show("Passenger recorded successfully!", "Information");
                    con.Close();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }


        }

        private void radioMale_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Male";
        }

        private void radioFemale_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Female";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtPassengerID.Clear();
            this.txtPassportNo.Clear();
            this.txtName.Clear();
            this.txtAddress.Clear();
            this.txtTel.Clear();
            this.comboNationality.SelectedIndex = -1;
            radioFemale.Checked = false;
            radioMale.Checked = false;
        }

        private void btnViewPassengers_Click(object sender, EventArgs e)
        {
            ViewPassengers v1 = new ViewPassengers();
            v1.Show();
            this.Hide();
        }

        private void lbViewpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewPassengers v1 = new ViewPassengers();
            v1.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h1 = new HomePage();
            h1.Show();
        }
    }
}
