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
    public partial class RetrunBookDetailsReport : Form
    {
        public RetrunBookDetailsReport()
        {
            InitializeComponent();
        }

        private void RetrunBookDetailsReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
          
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MySqlConnection con;
            con = Database.ConnectDB();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT BookID,StudentID,ContactNumber,ReturnDate FROM library.issue_book where ReturnDate='"+ dateTimePicker1.Value.ToString("yyyy/MM/dd")+ "' ", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (0 < dt.Rows.Count)
            {
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;


            }
            else
            {
                MessageBox.Show("No Data", "Books", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
