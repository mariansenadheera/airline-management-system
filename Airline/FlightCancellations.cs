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
    public partial class FlightCancellations : Form
    {
        public FlightCancellations()
        {
            InitializeComponent();
        }

        DataSet ds;

        private void deleteFlightRecord()
        {
            //create a connection with mssql server
            string cs = @"Data Source = DESKTOP-8EPAH64; Initial Catalog = Airline; Integrated Security = True";

            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    con.Open();

                    // Define a command
                    string sql = "DELETE FROM tblFlight WHERE fCode = @fCode";
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.Parameters.Add("@fCode", SqlDbType.VarChar).Value = this.comboFlightCode.Text;

                        // Execute the command
                        com.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            txtCancellationNo.Text = "";
            comboFlightCode.SelectedItem = -1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //creating a connection with mysql server
            string cs = @"Data Source = DESKTOP-8EPAH64;
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            if (this.txtCancellationNo.Text == "" || this.txtNoOfSeats.Text == "")
            {
                MessageBox.Show("All fields are required to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {
                    con.Open();

                    //Define a command
                    String sql = "INSERT INTO tblFlightCancellation VALUES (@FlightCancelNo,@fCode,@fSeats,@CancelDate)";
                    SqlCommand com = new SqlCommand(sql, con);
                    com.Parameters.AddWithValue("@FlightCancelNo", this.txtCancellationNo.Text);
                    com.Parameters.AddWithValue("@fCode", this.comboFlightCode.Text);
                    com.Parameters.AddWithValue("@fSeats", this.txtNoOfSeats.Text);
                    com.Parameters.AddWithValue("@CancelDate", this.dateTimePicker1.Text);


                    //Execute command and access data using Data Adaptor method
                    //get the confirmation from a msg box
                    string mret = MessageBox.Show("Are you sure to cancel this flight?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();

                    if (mret == "Yes")
                    {
                        int ret = com.ExecuteNonQuery();
                        MessageBox.Show("Flight cancelled successfully! :" + ret, "Information");

                    }

                    //Disconnect from the server
                    con.Close();
                    gridView();
                    deleteFlightRecord();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);


                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtCancellationNo.Clear();
            this.txtNoOfSeats.Clear();
            this.comboFlightCode.SelectedIndex = -1;
        }

        private void FlightCancellations_Load(object sender, EventArgs e)
        {
            fillFlightID();
            gridView();
        }
        
        private void fetchCode()
        {
            //creating a connection with mysql server
            string cs = @"Data Source = DESKTOP-8EPAH64;
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            con.Open();

            //Define a command
            String sql = "SELECT * FROM tblFlight WHERE fCode = @fCode";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@fCode", this.comboFlightCode.Text);

            DataTable dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(com);
            dap.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                txtNoOfSeats.Text = dr["fSeats"].ToString();

            }
            con.Close();
        }
        
        private void comboFlightCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
           fetchCode();
        }

        private void gridView()
        {

            string cs = @"Data Source = DESKTOP-8EPAH64;
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();

                //Define a command
                String sql = "SELECT * FROM tblFlightCancellation";
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

        private void fillFlightID()
        {
            //creating a connection with mysql server
            string cs = @"Data Source = DESKTOP-8EPAH64;
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //Define a command
            String sql = "SELECT fCode from tblFlight";
            SqlCommand com = new SqlCommand(sql, con);

            SqlDataReader dr = com.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("fCode", typeof(string));
            dt.Load(dr);
            comboFlightCode.ValueMember = "fCode";
            comboFlightCode.DataSource = dt;
            con.Close();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fillFlightID();
            gridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
