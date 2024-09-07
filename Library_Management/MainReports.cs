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

namespace Library_Management
{
    public partial class MainReports : Form
    {
        public MainReports()
        {
            InitializeComponent();
        }

        private void MainReports_Load(object sender, EventArgs e)
        {

        }

        private void btnstudent_Click(object sender, EventArgs e)
        {
            new StudentReport().Show();
        }

        private void btnbooks_Click(object sender, EventArgs e)
        {
            new Books().Show();
        }

        private void btnIssuBook_Click(object sender, EventArgs e)
        {
            new IssuReports().Show();
        }

        private void btnReturnbooks_Click(object sender, EventArgs e)
        {
            new RetrunBookDetailsReport().Show();
        }
    }
}
