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
using Library_Management.Reports;


namespace Library_Management.Reports
{
    
    public partial class IssuReports : Form
    {
        //  private readonly object dateTimePicker1;
        //string date;
        //private object cmbissubook;

        //string date = Convert.ToDateTime(dateTimePicker1.Text);
        public IssuReports()
        {
            InitializeComponent();
            //this.IssueDate = IssueDate;
        }
        //public IssuReports( string IssueDate)
        //{
        //    InitializeComponent();
        //    IssueDate = date;
        //}

        private void IssuReports_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
            //this.reportViewer2.RefreshReport();
            this.reportViewer2.RefreshReport();
            //this.reportViewer4.RefreshReport();
        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {
            //MySqlConnection con;
            //con = Database.ConnectDB();
            //con.Open();
            //MySqlCommand cmd = new MySqlCommand("SELECT BookID,StudentID,ContactNumber,IssueDate FROM library.issue_book where IssueDate='"+date+ "'", con);
            //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //if (0 < dt.Rows.Count)
            //{
            //    reportViewer2.LocalReport.DataSources.Clear();
            //    ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            //    reportViewer2.LocalReport.DataSources.Add(rds);
            //    this.reportViewer2.RefreshReport();
            //    reportViewer2.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            //    reportViewer2.ZoomMode = ZoomMode.Percent;


            //}
            //else
            //{
            //    MessageBox.Show("No Data", "Books", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con;
            con = Database.ConnectDB();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT BookID,StudentID,ContactNumber,IssueDate FROM library.issue_book " +
                "where IssueDate='" + dtpissubook.Value.ToString("yyyy/MM/dd") + "'", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (0 < dt.Rows.Count)
            {
                reportViewer2.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                reportViewer2.LocalReport.DataSources.Add(rds);
                this.reportViewer2.RefreshReport();
                reportViewer2.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer2.ZoomMode = ZoomMode.Percent;


            }
            else
            {
                MessageBox.Show("No Data", "Books", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
