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
using MySql.Data.MySqlClient;

namespace Library_Management
{
    public partial class Login : Form
    {
        MySqlConnection con;
        
        public Login()
        {
            InitializeComponent();
           
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
             MySqlDataAdapter sda = new MySqlDataAdapter("Select Count(*) From employees where Adminname='" + txtadminID.Text+ "' and" +
                 " Password='" + txtadminPassword.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();

                Dashboard Dash = new Dashboard();
                Dash.Show();
            }
            else
            {
                MessageBox.Show("Please Check your Username and Password");
            }
            clear();
        }
        public void clear()
        {
            txtadminID.Text = "";
            txtadminPassword.Text = "";
           

        }
        private void Login_Load(object sender, EventArgs e)
        {
            con = Database.ConnectDB();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            signup signup = new signup();
            signup.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                txtadminPassword.UseSystemPasswordChar = true;
            }
            else
            { txtadminPassword.UseSystemPasswordChar = false;
            
            }
        }

        private void txtadminPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnloginclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
