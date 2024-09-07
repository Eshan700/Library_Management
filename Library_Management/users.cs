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

namespace Library_Management
{
    public partial class users : Form
    {

        MySqlConnection con;
        MySqlDataReader reader;
        private object dt;

        public users()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
       
        private void Form2_Load(object sender, EventArgs e)
        {
            con = Database.ConnectDB();
            con.Open();
           
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT Adminid FROM library.employees", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbadminid.DataSource = dt;
            cmbadminid.DisplayMember = "Adminid";
            cmbadminid.ValueMember = "Adminid";

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void cmbadminid_SelectedIndexChanged(object sender, EventArgs e)
        {

            con = Database.ConnectDB();
            con.Open();
            MySqlCommand command = new MySqlCommand("Select * from library.employees where Adminid='" + cmbadminid.Text + "'",con);
            MySqlDataReader dr = command.ExecuteReader();
        
            while (dr.Read())
                {

                    txtadminname.Text = dr["Adminname"].ToString();
                    txtemail.Text = dr["Adminemail"].ToString();
                    txtcontactno.Text = dr["Contactno"].ToString();
                    cmbgender.Text = dr["Gender"].ToString();
                    txtdesignation.Text = dr["Designation"].ToString();
                    txtpassword.Text = dr["Password"].ToString();
                    txtretypepassword.Text = dr["Retypepassword"].ToString();
            }
          
            dr.Close();

            con.Close();
        }

        private void loadAdminIDs()
        {
           
        }

        public void Clear()
        {

            txtadminname.Text = "";
            txtemail.Text = "";
            txtcontactno.Text = "";
            cmbgender.Text = "";
            txtdesignation.Text = "";
            txtpassword.Text = "";
            txtretypepassword.Text = "";
            cmbadminid.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtpassword.Text.Trim() != txtretypepassword.Text.Trim())
                {
                    MessageBox.Show("Password confirmation doesn't match", "Password confirmation error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    con.Open();
                    MySqlCommand cmdUpdate = new MySqlCommand("UPDATE library.employees SET Adminname = '" + txtadminname.Text + "'," +
                        "Adminemail='" + txtemail.Text + "',Contactno='" + txtcontactno.Text + "',Gender='" + cmbgender.Text + "'," +
                        "Designation='" + txtdesignation.Text + "',Password='" + txtpassword.Text + "',Retypepassword='" + txtretypepassword.Text + "' " +
                        "WHERE Adminid =  '" + cmbadminid.Text + "'", con);
                    cmdUpdate.ExecuteNonQuery();



                    MessageBox.Show("Record Update successfully", "Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to delete this Student ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {

                    con.Open();

                    MySqlCommand cmdDelete = new MySqlCommand("DELETE FROM library.employees WHERE Adminid='" + cmbadminid.Text + "'", con);
                    cmdDelete.ExecuteNonQuery();
                    MessageBox.Show("Record Delete successfully", "Delete Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);


                con.Close();
                  
                }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
