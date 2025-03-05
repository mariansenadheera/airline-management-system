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
    public partial class PassengerReportView : Form
    {
        public PassengerReportView()
        {
            InitializeComponent();
        }

        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            //Connection
            string ccc = @"Data Source = Mari; 
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection conn = new SqlConnection(ccc);
            conn.Open();

            //Define a command
            String sss = "SELECT * FROM tblPassenger WHERE Nationality=@pid";
            //sql command object
            SqlCommand com = new SqlCommand(sss, conn);
            com.Parameters.AddWithValue("@pid", this.cmbnationality.Text);

            //ACCESS Data
            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dap.Fill(ds);

            //create a Report object
            PassengerReport rpt = new PassengerReport();
            rpt.Load("C:\\Users\\ranju\\source\\repos\\Final\\Airline1\\Airline\\PassengerReport.rpt");
            rpt.SetDataSource(ds.Tables[0]);

            this.crystalReportViewer1.ReportSource = rpt;

            //Disconnect from the server
            conn.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h1 = new HomePage();
            h1.Show();
        }
    }
}
