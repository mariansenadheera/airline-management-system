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
    public partial class FlightReportView : Form
    {
        public FlightReportView()
        {
            InitializeComponent();
        }

        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FlightReportView_Load(object sender, EventArgs e)
        {
            //Connection
            string ccc = @"Data Source = Mari; 
            Initial Catalog = Airline;
            Integrated Security = True";
            SqlConnection conn = new SqlConnection(ccc);
            conn.Open();

            //Define a command
            String sss = "SELECT * FROM tblFlight";
            //sql command object
            SqlCommand com = new SqlCommand(sss, conn);
           

            //ACCESS Data
            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dap.Fill(ds);

            //create a Report object
            FlightReport rpt = new FlightReport();
            rpt.Load("C:\\Users\\ranju\\source\\repos\\Final\\Airline1\\Airline\\FlightReport.rpt");
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
