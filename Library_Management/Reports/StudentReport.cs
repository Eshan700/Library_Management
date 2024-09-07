using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management.Reports
{
    public partial class StudentReport : Form
    {
        
        public StudentReport()
        {
            InitializeComponent();
        }

        private void StudentReport_Load(object sender, EventArgs e)
        {
 
            this.StudentreportViewer1.RefreshReport();
        }

        private void StudentreportViewer1_Load(object sender, EventArgs e)
        {
            MySqlConnection con;
            con = Database.ConnectDB();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM library.students", con);         
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (0 < dt.Rows.Count)
            {
                StudentreportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                StudentreportViewer1.LocalReport.DataSources.Add(rds);
                this.StudentreportViewer1.RefreshReport();
                StudentreportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                StudentreportViewer1.ZoomMode = ZoomMode.Percent;
            }
            else
            {
                MessageBox.Show("No Data", "Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
