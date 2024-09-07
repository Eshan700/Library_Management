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
    public partial class ReturnBook : Form
    {
        MySqlConnection con;
        public ReturnBook()
        {
            InitializeComponent();
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
                MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(StudentID) from library.issue_book where Issue='true'", con);
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
            MySqlCommand cmdAddData = new MySqlCommand("SELECT issue_book.BookID,books.BookName,issue_book.IssueDate,issue_book.ReturnDate,issue_book.DamageNote,issue_book.ID from library.issue_book  inner join books ON issue_book.BookID = books.BookID where issue_book.StudentID='" + comStudentId.Text + "' AND issue_book.Issue='true'", con);
            MySqlDataReader drAddData = cmdAddData.ExecuteReader();


            if (drAddData.HasRows)
            {
                while (drAddData.Read())
                {

                    DataGridViewRow newRow = new DataGridViewRow();

                     newRow.CreateCells(dataGridView1);
                     newRow.Cells[0].Value = drAddData["BookID"].ToString(); ;
                     newRow.Cells[1].Value = drAddData["BookName"].ToString();
                     newRow.Cells[2].Value = drAddData["IssueDate"].ToString();
                     newRow.Cells[3].Value = drAddData["ReturnDate"].ToString();
                     newRow.Cells[4].Value = drAddData["DamageNote"].ToString();
                     newRow.Cells[5].Value = drAddData["ID"].ToString();
                

                     dataGridView1.Rows.Add(newRow);

    
                }

                    con.Close();
            }
             con.Close();
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            con = Database.ConnectDB();
            //loadBookID();
            loadStudentID();
            sho();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
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
                string selectStudent = "Select students.StudentName,students.ContactNumber,students.ParentEmail,issue_book.IssueDate,issue_book.ReturnDate from library.students inner join issue_book ON students.StudentID = issue_book.StudentID where students.StudentID='" + comStudentId.Text + "'";
                MySqlCommand cmdselectStudent = new MySqlCommand(selectStudent, con);
                MySqlDataReader drselectStudent = cmdselectStudent.ExecuteReader();

                if (drselectStudent.HasRows)
                {
                    while (drselectStudent.Read())
                    {
                        txtStudentName.Text = drselectStudent["StudentName"].ToString();
                        txtContact2.Text = drselectStudent["ContactNumber"].ToString();
                        txtEmail.Text = drselectStudent["ParentEmail"].ToString();
                        dateTimeIssueDate.Value = Convert.ToDateTime(drselectStudent["IssueDate"].ToString()); 
                        dateTimeDueDate.Value = Convert.ToDateTime(drselectStudent["ReturnDate"].ToString()); 
                    }
                }
                con.Close();
                sho();
                //auto suggestions in searchbox end
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtContact2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int id = 0;
        string bookid = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                id= Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[5].Value.ToString());
                dateTimeIssueDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                dateTimeDueDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                txtDamageNote.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                bookid = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            }
            else
            {
                MessageBox.Show("no");
            }
        }

        private void dateTimeRetrnDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        string qty = "";
        private void button6_Click(object sender, EventArgs e)
        {
            if (txtLateDate.Text == "" || txtLateAmount.Text == "" || txtDamageAmount.Text == "" || txtTotal.Text == "")
            {
                MessageBox.Show("cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    con.Open();
                    MySqlCommand cmdUpdate = new MySqlCommand("UPDATE library.issue_book SET LateDays = '" + txtLateDate.Text + "',LateAmount='" + txtLateAmount.Text + "',DamageAmount='" + txtDamageAmount.Text + "',TotalAmount='" + txtTotal.Text + "',Issue='false' WHERE ID = '" + id + "'", con);
                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Record Update successfully", "Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    this.sho();
                    //qtyUpdate
                    con.Open();
                    string select = "Select Quantity FROM library.books where BookID='" + Convert.ToInt32(bookid) + "'";
                    MySqlCommand cmdselect = new MySqlCommand(select, con);
                    MySqlDataReader drselect = cmdselect.ExecuteReader();

                    if (drselect.HasRows)
                    {
                        while (drselect.Read())
                        {
                            qty = drselect["Quantity"].ToString();
                        }
                    }
                    con.Close();
                    con.Open();
                    string QueryQtyUpdate = "UPDATE library.books SET Quantity = '" + (Convert.ToInt32(qty) + 1).ToString() + "'WHERE BookID = '" + Convert.ToInt32(bookid) + "'";
                    MySqlCommand cmdQueryQtyUpdate = new MySqlCommand(QueryQtyUpdate, con);

                    cmdQueryQtyUpdate.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Select Full Row","Select Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                con.Open();
                MySqlCommand cmdUpdate = new MySqlCommand("UPDATE library.issue_book SET BooKDate = '" + dateTimeRetrnDate.Value.ToString("yyyy-MM-dd") + "',DamageNote='" + txtDamageNote.Text + "' WHERE ID = '" + id + "'", con);
                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("Record Update successfully", "Registration Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                con.Close();
                this.sho();

                if (dateTimeDueDate.Value < dateTimeRetrnDate.Value)
                {
                    int date = (dateTimeRetrnDate.Value - dateTimeDueDate.Value).Days;
                    if (date < 3)
                    {
                        txtLateDate.Text =date.ToString();
                        txtLateAmount.Text = "0";
                    }
                    else if(date > 2 && date < 15)
                    {
                        txtLateDate.Text = date.ToString();
                        txtLateAmount.Text = (10*date).ToString();
                    }
                    else
                    {
                        txtLateDate.Text = date.ToString();
                        txtLateAmount.Text = (20 * date).ToString();
                    }
                }
                else
                {
                    txtLateDate.Text = "0";
                    txtLateAmount.Text = "0";
                }

            }
            else
            {
                MessageBox.Show("Select Full Row");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtLateAmount.Text == "" || txtDamageAmount.Text == "")
            {
                MessageBox.Show("cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtTotal.Text = (Convert.ToDouble(txtLateAmount.Text) + Convert.ToDouble(txtDamageAmount.Text)).ToString();
            }
           
        }
    }
}
