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
    public partial class signup : Form
    {
        MySqlConnection con;
        public signup()
        {
            InitializeComponent();
        }

        //static string connection = @"Data Source=DESKTOP-U81NNJ7;Initial Catalog=Library;Integrated Security=True";

        //SqlConnection con = new SqlConnection(connection);


        //public void GetAdminId()
        //{
        //    string AdminId;
        //    string query = "Select AdminId from SignUp order by AdminId Desc";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    SqlDataReader dr = cmd.ExecuteReader();

        //    if (dr.Read())
        //    {
        //        int no = int.Parse(dr[0].ToString()) + 1;
        //        AdminId = no.ToString("0000");
        //    }

        //    else if (Convert.IsDBNull(dr))
        //    {
        //        AdminId = ("0001");
        //    }
        //    else
        //    {
        //        AdminId = ("0001");
        //    }

        //    con.Close();

        //    textBox4.Text = AdminId.ToString();
        // }
        //load StudentID id
        public void loadAdminID()
        {
            try
            {
                con.Open();
            string query = "Select MAX(Adminid) AS Adminid from library.employees";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader ds = cmd.ExecuteReader();

            if (ds.HasRows)
            {
                while (ds.Read())
                {
                    string Adminid = ds["Adminid"].ToString();
                    lbladminid.Text = (Convert.ToInt32(Adminid) + 1).ToString();
                }
            }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
                    //(ex.Message);
            }
           

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
            //string commandString;
            string commandString = "INSERT INTO employees (Adminid,Adminname,Adminemail,Contactno,Gender,Designation,Password,Retypepassword) VALUES ('" + lbladminid.Text+ "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + cmdgender.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
            MySqlCommand cmnd = new MySqlCommand(commandString , con);
           
            cmnd.ExecuteNonQuery();
              MessageBox.Show("Record Insert successfully", "Registration Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (textBox6.Text.Trim() != textBox7.Text.Trim())
            {
                MessageBox.Show("Password confirmation doesn't match","Password confirmation error!", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
               
            else
                {
                Login log = new Login();
                log.Show();
                this.Hide();
            }
           // Clear();
            textBox1.Focus();
            con.Close();
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

}



       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void Clear()
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            cmdgender.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }



        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void signup_Load(object sender, EventArgs e)
        {
            con = Database.ConnectDB();
            loadAdminID();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbladminid_Click(object sender, EventArgs e)
        {

        }
    }
}
