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
    public partial class Home : Form
    {

        MySqlConnection con;
        public Home()
        {
            InitializeComponent();
        }

        //Load Total Books

        public void LoadTotalBook()
        {
            //auto suggestions in searchbox start 
            con.Open();
            string select = "Select SUM(Quantity) AS Quantity FROM library.books";
            MySqlCommand cmdselect = new MySqlCommand(select, con);
            MySqlDataReader drselect = cmdselect.ExecuteReader();

            if (drselect.HasRows)
            {
                while (drselect.Read())
                {
                    labTotalBook.Text = drselect["Quantity"].ToString();
                }
            }

            con.Close();

        }

        //Load Total Student

        public void LoadTotalStudent()
        {
            //auto suggestions in searchbox start 
            con.Open();
            string select = "Select COUNT(StudentID) AS StudentID FROM library.students";
            MySqlCommand cmdselect = new MySqlCommand(select, con);
            MySqlDataReader drselect = cmdselect.ExecuteReader();

            if (drselect.HasRows)
            {
                while (drselect.Read())
                {
                    labTotalStudent.Text = drselect["StudentID"].ToString();
                }
            }

            con.Close();

        }

        //Load Total Issued book

        public void LoadIssuedBook()
        {
            //auto suggestions in searchbox start 
            con.Open();
            string select = "Select COUNT(ID) AS ID FROM library.issue_book where Issue='true'";
            MySqlCommand cmdselect = new MySqlCommand(select, con);
            MySqlDataReader drselect = cmdselect.ExecuteReader();

            if (drselect.HasRows)
            {
                while (drselect.Read())
                {
                    labIssuedBook.Text = drselect["ID"].ToString();
                }
            }

            con.Close();

        }

        //Load Total Late book
        int days = 0;
        public void LoadLateBook()
        {
            //auto suggestions in searchbox start 
            con.Open();
            string select = "Select ReturnDate FROM library.issue_book where Issue='true'";
            MySqlCommand cmdselect = new MySqlCommand(select, con);
            MySqlDataReader drselect = cmdselect.ExecuteReader();

            if (drselect.HasRows)
            {
                while (drselect.Read())
                {
                     
                    if (Convert.ToDateTime(drselect["ReturnDate"]) < DateTime.Now)
                    {
                        days = days + 1;
                    }
                }
                labLateBooks.Text = days.ToString();
            }

            con.Close();

        }
        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            con = Database.ConnectDB();
            LoadTotalBook();
            LoadTotalStudent();
            LoadIssuedBook();
            LoadLateBook();

            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select books.Category,count(issue_book.StudentID) AS StudentID from library.books inner join library.issue_book ON books.BookID = issue_book.BookID  GROUP BY books.Category";
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);

            this.chartinventry.DataSource = ds.Tables[0];

            //Mapping a field with x-value of chart
            this.chartinventry.Series[0].XValueMember = "Category";

            //Mapping a field with y-value of Chart
            this.chartinventry.Series[0].YValueMembers = "StudentID";

            this.chartinventry.DataBind();

            con.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
