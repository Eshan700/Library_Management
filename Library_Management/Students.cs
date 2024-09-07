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
using System.Net;
using System.Net.Mail;
using System.Drawing.Imaging;
using System.IO;

namespace Library_Management
{

    public partial class Students : Form
    {

        MySqlConnection con;
        public Students()
        {
            InitializeComponent();


        }

        //load StudentID id
        public void loadStudentID()
        {
            con.Open();
            string query = "Select MAX(StudentID) AS StudentID from library.students";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader ds = cmd.ExecuteReader();

            if (ds.HasRows)
            {
                while (ds.Read())
                {
                    string StudentID = ds["StudentID"].ToString();
                    label6.Text = (Convert.ToInt32(StudentID) + 1).ToString();
                }
            }
            con.Close();
        }
        //Data Enter the datagridview1
        public void sho()
        {
            dataGridView2.Rows.Clear();
            con.Open();
            MySqlCommand cmdAddData = new MySqlCommand("SELECT * from library.students", con);
            MySqlDataReader drAddData = cmdAddData.ExecuteReader();


            if (drAddData.HasRows)
            {
                while (drAddData.Read())
                {

                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dataGridView2);
                    newRow.Cells[0].Value = drAddData["StudentID"].ToString(); ;
                    newRow.Cells[1].Value = drAddData["StudentName"].ToString();
                    newRow.Cells[2].Value = drAddData["DateOfBirth"].ToString();
                    newRow.Cells[3].Value = drAddData["Grade"].ToString();
                    newRow.Cells[4].Value = drAddData["ContactNumber"].ToString();
                    newRow.Cells[5].Value = drAddData["ParentEmail"].ToString();
                    newRow.Cells[6].Value = drAddData["Barcode"].ToString();
                    dataGridView2.Rows.Add(newRow);


                }

                con.Close();
            }
            con.Close();
        }


        //Send Email

        public void sendMail()
        {

            string SenderEmail = "librarystpetersgampaha@gmail.com";
            string SenderPassword = "Gampaha123";
            string SMTPServer = "smtp.gmail.com";
            string PortNumber = "587";


            string RecEmail = "kavinda700@gmail.com";
            string Subject = "ST.PETER'S COLLEGE GAMPAHA LIBRARY";
            string Body = "Dear Sir, '"+txtStudentName.Text+"' has successfully created a school library account.";

            SmtpClient clientDetails = new SmtpClient();
            clientDetails.Port = Convert.ToInt32(PortNumber);
            clientDetails.Host = SMTPServer.Trim();
            clientDetails.EnableSsl = true;
            clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
            clientDetails.UseDefaultCredentials = false;
            clientDetails.Credentials = new NetworkCredential(SenderEmail.Trim(), SenderPassword.Trim());

            MailMessage mailDetails = new MailMessage();

            mailDetails.From = new MailAddress(SenderEmail.Trim());
            mailDetails.To.Add(RecEmail.Trim());
            mailDetails.Subject = Subject.Trim();
            mailDetails.IsBodyHtml = true;
            mailDetails.Body = Body.Trim();

            clientDetails.Send(mailDetails);
            MessageBox.Show("Sending Sucssesfuly  !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Students_Load(object sender, EventArgs e)
        {
            con = Database.ConnectDB();
            loadStudentID();
            sho();
        }

        public void Clear()
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {


        }
        public void clear()
        {
            txtStudentName.Text = "";

            txtContact.Text = "";
            comGrade.Text = "";
            txtbarcodee.Text = "";
            // comCategory.Clear();
            txtEmail.Clear();
          
            pictureBox1.Image = null;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentName.Text == "" || txtContact.Text == "" || txtContact.Text.Any(char.IsLetter) || comGrade.SelectedIndex == -1 || txtbarcodee.Text=="")
                {
                    MessageBox.Show("cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                else if (txtEmail.Text == "")
                {
                    MessageBox.Show("Email cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {

                    con.Open();
                    string Query = "insert into library.students(StudentID,StudentName,DateOfBirth,Grade,ContactNumber,ParentEmail,Barcode) values('" +  (label6.Text) + "','" + txtStudentName.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + comGrade.Text + "','" + txtContact.Text + "','" + txtEmail.Text + "','" + txtbarcodee.Text+ "')";
                    MySqlCommand cmdInsertStudent = new MySqlCommand(Query, con);

                    cmdInsertStudent.ExecuteNonQuery();

                    MessageBox.Show("Record added successfully", "Registration Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    //sendMail();
                    con.Close();
                    sho();
                    clear();
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

       


        private void button5_Click(object sender, EventArgs e)
        {
            con = Database.ConnectDB();
            //try
            //{
            if (txtStudentName.Text == "" || txtContact.Text == "" || txtContact.Text.Any(char.IsLetter) || comGrade.SelectedIndex == -1)
            {
                MessageBox.Show("cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Email cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                con.Open();
                MySqlCommand cmdUpdate = new MySqlCommand("UPDATE library.students SET StudentName = '" + txtStudentName.Text + "',DateOfBirth='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',Grade='" + comGrade.Text + "',ContactNumber='" + txtContact.Text + "',ParentEmail='" +txtEmail.Text+ "',Barcode='" + txtbarcodee.Text + "' WHERE StudentID = '" + Convert.ToInt32(label6.Text) + "'", con);
                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("Record Update successfully", "Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
                this.sho();
                clear();
            }

                }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to delete this Student ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {

                    con.Open();

                    MySqlCommand cmdDelete = new MySqlCommand("DELETE FROM library.students WHERE StudentID ='" + Convert.ToInt32(label6.Text) + "'", con);
                    cmdDelete.ExecuteNonQuery();
                    MessageBox.Show("Record Delete successfully", "Delete Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();
                    sho();
                    clear();
                }
            }
            }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.CurrentRow.Selected = true;
            if (dataGridView2.SelectedRows.Count == 1)
            {

                label6.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
                txtStudentName.Text = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
                dateTimePicker1.Value=Convert.ToDateTime(dataGridView2.Rows[e.RowIndex].Cells[2].Value);
                comGrade.SelectedItem = this.dataGridView2.CurrentRow.Cells[3].Value.ToString();
                txtContact.Text = this.dataGridView2.CurrentRow.Cells[4].Value.ToString();
                txtEmail.Text = this.dataGridView2.CurrentRow.Cells[5].Value.ToString();
                txtbarcodee.Text = this.dataGridView2.CurrentRow.Cells[6].Value.ToString();

            }
            else
            {
                MessageBox.Show("no");
            }
        
    }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string barcode = txtbarcodee.Text;
            Bitmap bitmap = new Bitmap(barcode.Length * 40, 150);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Font ofont = new System.Drawing.Font("IDAutomationHC39M Free Version", 20);
                //("TYP ", 20);

                PointF point = new PointF(2f, 2f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush White = new SolidBrush(Color.White);

                graphics.FillRectangle(White, 0, 0, bitmap.Width, bitmap.Height);
                graphics.DrawString("*" + barcode + "*", ofont, black, point);
            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                pictureBox1.Image = bitmap;
                pictureBox1.Height = bitmap.Height;
                pictureBox1.Width = bitmap.Width;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sve = new SaveFileDialog() { Filter = "PNG|*.png" })
            {
                if (sve.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(sve.FileName);
                }
            }
        }
    }
}
