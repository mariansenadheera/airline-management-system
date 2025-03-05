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
    public partial class TicketCancellation : Form
    {
        public TicketCancellation()
        {
            InitializeComponent();
        }

        DataSet ds;

        private void fillTicketID()
        {
            //creating a connection with mysql server
            string cs = @"Data Source = DESKTOP-8EPAH64;
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //Define a command
            String sql = "SELECT TID from tblTicketBooking";
            SqlCommand com = new SqlCommand(sql, con);

            SqlDataReader dr = com.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("TID", typeof(string));
            dt.Load(dr);
            comboTicketID.ValueMember = "TID";
            comboTicketID.DataSource = dt;
            con.Close();

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
                String sql = "SELECT * FROM tblTicketCancellation";
                SqlCommand com = new SqlCommand(sql, con);

                //Execute command and access data using Data Adaptor method
                SqlDataAdapter dap = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                dap.Fill(ds);

                //display table at once
                this.datagridView1.DataSource = ds.Tables[0];
                //Disconnect from the server
                con.Close();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);


            }
        }
        private void fetchFcode()
        {
            //creating a connection with mysql server
            string cs = @"Data Source = DESKTOP-8EPAH64;
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            con.Open();

            //Define a command
            String sql = "SELECT * FROM tblTicketBooking WHERE TID = @TID";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@TID", this.comboTicketID.Text);

            DataTable dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(com);
            dap.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboFlightCode.Text = dr["fCode"].ToString();

            }
            con.Close();

        }

        private void TicketCancellation_Load(object sender, EventArgs e)
        {
            fillTicketID();
            gridView();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtCancellationNo.Clear();
            this.comboTicketID.SelectedIndex = -1;
            this.comboFlightCode.SelectedIndex = -1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //creating a connection with mysql server
            string cs = @"Data Source = DESKTOP-8EPAH64;
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            if (this.txtCancellationNo.Text == "" || this.comboFlightCode.Text == "")
            {
                MessageBox.Show("All fields are required to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {
                    con.Open();

                    //Define a command
                    String sql = "INSERT INTO tblTicketCancellation VALUES (@CancelNo,@TID,@fCode,@CancelDate)";
                    SqlCommand com = new SqlCommand(sql, con);
                    com.Parameters.AddWithValue("@CancelNo", this.txtCancellationNo.Text);
                    com.Parameters.AddWithValue("@TID", this.comboTicketID.Text);
                    com.Parameters.AddWithValue("@fCode", this.comboFlightCode.Text);
                    com.Parameters.AddWithValue("@CancelDate", this.dateTimePicker1.Text);


                    //Execute command and access data using Data Adaptor method
                    //get the confirmation from a msg box
                    string mret = MessageBox.Show("Are you sure to delete this record?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();

                    if (mret == "Yes")
                    {
                        int ret = com.ExecuteNonQuery();
                        MessageBox.Show("Ticket cancelled successfully! :" + ret, "Information");

                    }

                    //Disconnect from the server
                    con.Close();
                    gridView();
                    deleteTicketRecord();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);


                }
            }
        }

        private void deleteTicketRecord()
        {
            //create a connection with mssql server
            string cs = @"Data Source = DESKTOP-8EPAH64; Initial Catalog = Airline; Integrated Security = True";

            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    con.Open();

                    // Define a command
                    string sql = "DELETE FROM tblTicketBooking WHERE TID = @TID";
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.Parameters.Add("@TID", SqlDbType.VarChar).Value = this.comboTicketID.Text;

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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboTicketID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboTicketID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchFcode();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            txtCancellationNo.Text = "";
            comboFlightCode.SelectedIndex = -1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fillTicketID();
            gridView();

        }
    }
}
