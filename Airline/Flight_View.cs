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
    public partial class Flight_View : Form
    {
        public Flight_View()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Flight_View_Load(object sender, EventArgs e)
        {
            string cs = @"Data Source = Mari; 
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();

                //Define a command
                String sql = "SELECT * FROM tblFlight";
                SqlCommand com = new SqlCommand(sql, con);

                //Execute command and access data using Data Adaptor method
                SqlDataAdapter dap = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                dap.Fill(ds);

                //display table at once
                this.dataGridView1.DataSource = ds.Tables[0];
                //Disconnect from the server
                con.Close();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);


            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtfcode2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.cmborigin.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.cmbdestination.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.dtptakeoff.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.nudseats.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            //create a connection with mssql server
            string cs = @"Data Source = Mari; 
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();

                //Define a command
                String sql = "SELECT * FROM tblFlight WHERE fcode=@fcode1";
                SqlCommand com = new SqlCommand(sql, con);
                com.Parameters.AddWithValue("@fcode1", this.txtfcode1.Text);

                //Execute command and access data using Data Reader method
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read() == true)
                {
                    //bind data with controls
                    this.txtfcode2.Text = dr.GetValue(0).ToString();
                    this.cmborigin.Text = dr.GetValue(1).ToString();
                    this.cmbdestination.Text = dr.GetValue(2).ToString();
                    this.dtptakeoff.Text = dr.GetValue(3).ToString();
                    this.nudseats.Text = dr.GetValue(4).ToString();
                }
                else
                {
                    MessageBox.Show("No records found...", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                //Disconnect from the server
                con.Close();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);


            }
        }

        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            //create a connection with mssql server
            string cs = @"Data Source = Mari; 
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();

                //Define a command
                String sql = "SELECT * FROM tblFlight";
                SqlCommand com = new SqlCommand(sql, con);

                //Execute command and access data using Data Adaptor method
                SqlDataAdapter dap = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                dap.Fill(ds);

                //display table at once
                this.dataGridView1.DataSource = ds.Tables[0];

                //Disconnect from the server
                con.Close();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);


            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            //create a connection with mssql server
            string cs = @"Data Source = Mari; 
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            if (this.txtfcode2.Text == "" || this.cmborigin.Text == "" || this.cmbdestination.Text == "" ||
                this.dtptakeoff.Text == "" || this.nudseats.Text == "")
            {
                MessageBox.Show("All fields are required to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {
                    con.Open();

                    //Define a command
                    String sql = "UPDATE tblFlight SET  fOrigin=@forigin, fDestination=@fdestination ," +
                        "fTakeOffDate=@ftakeoff, fSeats=@fSeats WHERE fCode=@fcode";
                    SqlCommand com = new SqlCommand(sql, con);
                    com.Parameters.AddWithValue("@fcode", this.txtfcode2.Text);
                    com.Parameters.AddWithValue("@forigin", this.cmborigin.Text);
                    com.Parameters.AddWithValue("@fdestination", this.cmbdestination.Text);
                    com.Parameters.AddWithValue("@ftakeoff", this.dtptakeoff.Text);
                    com.Parameters.AddWithValue("@fSeats", this.nudseats.Text);
                   

                    //Execute command and access data using Data Adaptor method
                    int ret = com.ExecuteNonQuery();
                    MessageBox.Show("No of records Updated:" + ret, "Information");


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
            this.txtfcode1.Clear();
            this.txtfcode2.Clear();
            this.cmborigin.SelectedIndex = -1;
            this.cmbdestination.SelectedIndex = -1;
            this.nudseats.Value = 0;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            //create a connection with mssql server
            string cs = @"Data Source = Mari; 
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            if (this.txtfcode2.Text == "")
            {
                MessageBox.Show("Please provide Flight Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {
                    con.Open();

                    //Define a command
                    String sql = "DELETE FROM tblFlight WHERE fCode=@fcode2";
                    SqlCommand com = new SqlCommand(sql, con);
                    com.Parameters.AddWithValue("@fcode2", this.txtfcode2.Text);
                   
                    //Execute command and access data using Data Adaptor method
                    //get the confirmation from a msg box
                    string mret = MessageBox.Show("Are you sure to delete this record?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();

                    if (mret == "Yes")
                    {
                        int ret = com.ExecuteNonQuery();
                        MessageBox.Show("No of records Deleted:" + ret, "Information");

                    }



                    //Disconnect from the server
                    con.Close();
                }

                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);


                }
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h1 = new HomePage();
            h1.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Record_Flight r1 = new Record_Flight();
            r1.Show();
        }
    }
}
