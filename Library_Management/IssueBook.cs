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
    public partial class IssueBook : Form
    {
        MySqlConnection con;
        public IssueBook()
        {
            InitializeComponent();
        }

        public void loadBookID()
        {


            try
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                //auto suggestions in searchbox start 
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("Select BookID from library.books", con);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                comBookId.DisplayMember = "BookID";
                comBookId.DataSource = dt1;

                con.Close();
                //auto suggestions in searchbox end


            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //load studentID
        public void loadStudentID()
        {


            try
            {
                if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
            //auto suggestions in searchbox start 
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select StudentID from library.students", con);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            comStudentId.DisplayMember = "StudentID";
            comStudentId.DataSource = dt1;

            con.Close();
                //auto suggestions in searchbox end


            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //show datagrid
        public void sho()
        {
            dataGridView1.Rows.Clear();
            con.Open();
            MySqlCommand cmdAddData = new MySqlCommand("SELECT * from library.issue_book", con);
            MySqlDataReader drAddData = cmdAddData.ExecuteReader();


            if (drAddData.HasRows)
            {
                while (drAddData.Read())
                {

                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dataGridView1);
                    newRow.Cells[0].Value = drAddData["ID"].ToString(); ;
                    newRow.Cells[1].Value = drAddData["BookID"].ToString();
                    newRow.Cells[2].Value = drAddData["StudentID"].ToString();
                    newRow.Cells[3].Value = drAddData["ContactNumber"].ToString();
                    newRow.Cells[4].Value = drAddData["IssueDate"].ToString();
                    newRow.Cells[5].Value = drAddData["ReturnDate"].ToString();
                    newRow.Cells[6].Value = drAddData["DamageNote"].ToString();

                    dataGridView1.Rows.Add(newRow);


                }

                con.Close();
            }
            con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            con = Database.ConnectDB();
            loadBookID();
            loadStudentID();
            sho();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                //auto suggestions in searchbox start 
                con.Open();
                string select = "Select Quantity FROM library.books where BookID='" + comBookId.Text + "'";
                MySqlCommand cmdselect = new MySqlCommand(select, con);
                MySqlDataReader drselect = cmdselect.ExecuteReader();

                if (drselect.HasRows)
                {
                    while (drselect.Read())
                    {
                        labQty.Text = drselect["Quantity"].ToString();
                    }
                }

                con.Close();

                //auto suggestions in searchbox end


            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error: " + ex.Message);
            }
        
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comStudentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                //auto suggestions in searchbox start 
                con.Open();
                string selectStudent = "Select StudentName,ContactNumber,ParentEmail,Grade from library.students where StudentID='" + comStudentId.Text + "'";
                MySqlCommand cmdselectStudent = new MySqlCommand(selectStudent, con);
                MySqlDataReader drselectStudent = cmdselectStudent.ExecuteReader();

                if (drselectStudent.HasRows)
                {
                    while (drselectStudent.Read())
                    {
                        txtStudentName.Text = drselectStudent["StudentName"].ToString();
                        txtContact2.Text = drselectStudent["ContactNumber"].ToString();
                        txtEmail.Text = drselectStudent["ParentEmail"].ToString();
                        txtGrade.Text = drselectStudent["Grade"].ToString();
                    }
                }

                con.Close();

                //auto suggestions in searchbox end


            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        public void clear()
        {
            txtContact1.Text = "";
            comBookId.Text = "";
            comStudentId.Text = "";
            dateTimeIssue.ResetText();
            dateTimeReturn.ResetText();
            txtDamageNote.Clear();

        }  

          

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContact1.Text == "" || txtDamageNote.Text == "")
                {
                    MessageBox.Show("cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                else
                {
                    con.Open();
                    string Query = "insert into library.issue_book(BookID,StudentID,ContactNumber,IssueDate,ReturnDate,DamageNote,Issue) values('" + Convert.ToInt32(comBookId.Text) + "','" + Convert.ToInt32(comStudentId.Text) + "','"+txtContact1.Text+"','" + dateTimeIssue.Value.ToString("yyyy-MM-dd") + "','" + dateTimeReturn.Value.ToString("yyyy-MM-dd") + "','" + txtDamageNote.Text + "','true')";
                    MySqlCommand cmdInsertBook = new MySqlCommand(Query, con);
                    
                    cmdInsertBook.ExecuteNonQuery();

                    MessageBox.Show("Record added successfully", "Registration Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    con.Close();
                    sho();

                    //qtyUpdate
                    con.Open();
                    string QueryQtyUpdate = "UPDATE library.books SET Quantity = '" + (Convert.ToInt32(labQty.Text)-1).ToString() + "'WHERE BookID = '" + comBookId.Text + "'";
                    MySqlCommand cmdQueryQtyUpdate = new MySqlCommand(QueryQtyUpdate, con);

                    cmdQueryQtyUpdate.ExecuteNonQuery();
                   
                    con.Close();
                    clear();
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
        int id =0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                id= Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                comBookId.SelectedIndex = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[1].Value.ToString())-1;
                comStudentId.SelectedIndex = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[2].Value.ToString())-1;
                txtContact1.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                dateTimeIssue.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                dateTimeReturn.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                txtDamageNote.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            else
            {
                MessageBox.Show("no");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContact1.Text == "" || txtDamageNote.Text == "")
                {
                    MessageBox.Show("cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    con.Open();
                MySqlCommand cmdUpdate = new MySqlCommand("UPDATE library.issue_book SET BookID = '" + comBookId.Text + "',StudentID='" + comStudentId.Text + "',ContactNumber='" + txtContact1.Text + "',IssueDate='" + dateTimeIssue.Value.ToString("yyyy-MM-dd") + "',ReturnDate='" + dateTimeReturn.Value.ToString("yyyy-MM-dd") + "',DamageNote='"+ txtDamageNote.Text + "' WHERE ID = '" +id + "'", con);
                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("Record Update successfully", "Registration Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    con.Close();
                this.sho();
                    clear();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to delete this Record ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {

                    con.Open();

                    MySqlCommand cmdDelete = new MySqlCommand("DELETE FROM library.issue_book WHERE ID ='" +id + "'", con);
                    cmdDelete.ExecuteNonQuery();
                    MessageBox.Show("Record Delete successfully", "Registration Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    con.Close();
                    sho();
                    clear();
                }
            }
        }
    }
}
