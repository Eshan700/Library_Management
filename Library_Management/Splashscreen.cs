using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class Splashscreen : Form
    {
        public Splashscreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = 10;
            progressbar.Width += x;

            if (progressbar.Width > 600)
            {
                timer1.Enabled = false;
                Login login = new Login();
                login.Show();
                this.Hide();



            }
        }
    }
}
