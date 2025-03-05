using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline
{
    public partial class ticket_booking : Form
    {
        public ticket_booking()
        {
            InitializeComponent();
        }

        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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

        private void btnreset_Click(object sender, EventArgs e)
        {
            this.txtticketID.Clear();
            this.txtname.Clear();
            this.txtnationality.Clear();
            this.txtpassport.Clear();
            this.txtamount.Clear();
            this.cmbpassengerID.SelectedIndex = -1;
            this.cmbfcode.SelectedIndex = -1;
            this.cmbclass.SelectedIndex = -1;

        }

        private void ticket_booking_Load(object sender, EventArgs e)
        {
            string cs = @"Data Source = Mari; 
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();

                //Define a command
                String sql = "SELECT * FROM tblTicketBooking";
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

            fillPassengerID();
            fillFlightCode();

        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            //create a connection with mssql server
            string cs = @"Data Source = Mari; 
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            if (this.txtticketID.Text == "" || this.txtpassport.Text == "" || this.txtnationality.Text == "" ||
                this.txtname.Text == "" || this.txtamount.Text == "" || this.cmbpassengerID.Text == "" || this.cmbfcode.Text == "" || this.cmbclass.Text == "")
            {
                MessageBox.Show("All fields are required to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {
                    con.Open();

                    //Define a command
                    String sql = "INSERT INTO tblTicketBooking VALUES (@ticketID,@PID,@fCode,@class,@name,@passport," +
                        "@nationality,@amount)";
                    SqlCommand com = new SqlCommand(sql, con);
                    com.Parameters.AddWithValue("@ticketID", this.txtticketID.Text);
                    com.Parameters.AddWithValue("@PID", this.cmbpassengerID.Text);
                    com.Parameters.AddWithValue("@fCode", this.cmbfcode.Text);
                    com.Parameters.AddWithValue("@class", this.cmbclass.Text);
                    com.Parameters.AddWithValue("@name", this.txtname.Text);
                    com.Parameters.AddWithValue("@passport", this.txtpassport.Text);
                    com.Parameters.AddWithValue("@nationality", this.txtnationality.Text);
                    com.Parameters.AddWithValue("@amount", Convert.ToInt32(this.txtamount.Text));


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

        //predefine function
        private void fillPassengerID() {

            //create a connection with mssql server
            string cs = @"Data Source = Mari; 
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

             con.Open();

            //Define a command
            String sql = "SELECT PassengerID FROM tblPassenger";
            SqlCommand com = new SqlCommand(sql, con);

            //Execute command and access data using Data Reader method
            SqlDataReader rdr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PassengerID", typeof(string));
            dt.Load(rdr);
            cmbpassengerID.ValueMember = "PassengerID";
            cmbpassengerID.DataSource = dt;
            //Disconnect from the server
            con.Close();


        }


        string pname, ppassport, pnationality;

        private void cmbpassengerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchPassenger();
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
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
                String sql = "SELECT * FROM tblTicketBooking";
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

        //predefined function
        private void fetchPassenger() {
            //create a connection with mssql server
            string cs = @"Data Source = Mari; 
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            con.Open();

            //Define a command
            String sql = "SELECT * FROM tblPassenger WHERE PassengerID = @ID";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@ID", this.cmbpassengerID.Text);

            DataTable dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(com);
            dap.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                pname = dr["Name"].ToString();
                ppassport = dr["PassengerNo"].ToString();
                pnationality = dr["Nationality"].ToString() ;
                txtname.Text = pname;
                txtpassport.Text = ppassport;  
                txtnationality.Text = pnationality;
            }
            con.Close();

        }

        private void fillFlightCode() {
            //create a connection with mssql server
            string cs = @"Data Source = Mari; 
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            con.Open();

            //Define a command
            String sql = "SELECT fCode FROM tblFlight";
            SqlCommand com = new SqlCommand(sql, con);

            //Execute command and access data using Data Reader method
            SqlDataReader rdr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("fCode", typeof(string));
            dt.Load(rdr);
            cmbfcode.ValueMember = "fCode";
            cmbfcode.DataSource = dt;
            //Disconnect from the server
            con.Close();



        }
    }
}
