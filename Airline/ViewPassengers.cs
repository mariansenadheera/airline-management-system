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
    public partial class ViewPassengers : Form
    {
        public ViewPassengers()
        {
            InitializeComponent();
        }

        string Gender;
        DataSet ds;

        private void AddPassenger_Load(object sender, EventArgs e)
        {
            //creating a connection with mysql server
            string cs = @"Data Source = Mari;
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //Define a command
            string sql = "SELECT * FROM tblPassenger ";
            SqlCommand com = new SqlCommand(sql, con);

            //Execute command using data adapter method
            SqlDataAdapter dap = new SqlDataAdapter(com);
            ds = new DataSet();
            dap.Fill(ds);

            //Diaplay table
            this.dataGridView1.DataSource = ds.Tables[0];

            con.Close();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            //creating a connection with mysql server
            string cs = @"Data Source = Mari;
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);
            if (txtPassengerID.Text == "" || txtPassportNo.Text == "" || txtName.Text == "" || txtAddress.Text == "" || txtTel.Text == "" || comboNationality.Text == "" || Gender == "")
            {
                MessageBox.Show("All fields are required to proceed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {
                    con.Open();

                    //Define a command
                    string sql = "UPDATE tblPassenger SET PassengerNo =@PassengerNo, Name = @Name, Address = @Address,MobileNo = @MobileNo,Nationality = @Nationality,Gender=@Gender WHERE PassengerID = @PassengerID";
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
                    MessageBox.Show("Passenger updated successfully!", "Information");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtPassengerID.Text == "")
            {
                MessageBox.Show("Enter the passenger ID to delete!");
            }
            else
            {
                try
                {
                    //creating a connection with mysql server
                    string cs = @"Data Source = Mari;
                    Initial Catalog = Airline;
                    Integrated Security = True";
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();

                    //Define a command
                    string sql = "DELETE FROM tblPassenger WHERE PassengerID = @PassengerID";
                    SqlCommand com = new SqlCommand(sql, con);
                    com.Parameters.AddWithValue("@PassengerID", this.txtPassengerID.Text);

                    //Execute command to delete data
                    string mret = MessageBox.Show("Are you sure to delete this record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();
                    if (mret == "Yes")
                    {
                        int ret = com.ExecuteNonQuery();
                        MessageBox.Show(ret + " record deleted!", "Information");
                    }

                    //Disconnect from the server
                    con.Close();
                }

                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h1 = new HomePage();
            h1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtPassengerID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.txtPassportNo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.txtName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.txtAddress.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.txtTel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboNationality.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            Gender = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
                //create a connection with mysql server
                string cs = @"Data Source = Mari;
            Initial Catalog = Airline;
            Integrated Security = True";
                SqlConnection con = new SqlConnection(cs);
                con.Open();

                //Define a command
                string sql = "SELECT * FROM tblPassenger WHERE PassengerID = @PassengerID";
                SqlCommand com = new SqlCommand(sql, con);
                com.Parameters.AddWithValue("@PassengerID", this.txtSIDSearch.Text);


                //Execute command and access data using data reader method
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read() == true)
                {
                    //Bind data with controls
                    this.txtPassengerID.Text = dr.GetValue(0).ToString();
                    this.txtPassportNo.Text = dr.GetValue(1).ToString();
                    this.txtName.Text = dr.GetValue(2).ToString();
                    this.txtAddress.Text = dr.GetValue(3).ToString();
                    this.txtTel.Text = dr.GetValue(4).ToString();
                    this.comboNationality.Text = dr.GetValue(5).ToString();

                    string Gender = dr.GetValue(6).ToString();
                    if (Gender == "Male")
                    {
                        this.radioMale.Checked = true;
                    }
                    else if (Gender == "Female")
                    {
                        this.radioFemale.Checked = true;
                    }


                }
                else
                {
                    MessageBox.Show("No records found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                con.Close();

            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //creating a connection with mysql server
            string cs = @"Data Source = Mari;
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //Define a command
            string sql = "SELECT * FROM tblPassenger ";
            SqlCommand com = new SqlCommand(sql, con);

            //Execute command using data adapter method
            SqlDataAdapter dap = new SqlDataAdapter(com);
            ds = new DataSet();
            dap.Fill(ds);

            //Diaplay table
            this.dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }
    }
}
