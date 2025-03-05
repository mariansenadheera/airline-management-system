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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            this.txtuid.Clear();
            this.txtpwd.Clear();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //connection
            string cs = @"Data Source = Mari; 
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection conn = new SqlConnection(cs);
            if (this.txtuid.Text == "" || this.txtpwd.Text == "")
            {
                MessageBox.Show("All fields are required to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            else
            {
                try
                {

                    conn.Open();

                    //command
                    string sql = "SELECT * FROM tblUsers WHERE uid = @un AND pswd = @pwd";
                    SqlCommand com = new SqlCommand(sql, conn);
                    com.Parameters.AddWithValue("@un", this.txtuid.Text);
                    com.Parameters.AddWithValue("@pwd", this.txtpwd.Text);

                    SqlDataReader dr = com.ExecuteReader();

                    if (dr.Read() == true)
                    {

                        HomePage home = new HomePage();
                        home.Show();
                        this.Hide();

                    }

                    else
                    {
                        MessageBox.Show("Invalid username or password", "Error");
                    }
                    //Disconnect
                    conn.Close();
                }
                catch (Exception Ex) {

                    MessageBox.Show(Ex.Message);
  
                
                }
            }
        }

        private void btnreset_Click_1(object sender, EventArgs e)
        {
            this.txtuid.Clear();
            this.txtpwd.Clear();

        }

        private void txtuid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
