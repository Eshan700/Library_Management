using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class Book : Form
    {

        MySqlConnection con;
        public Book()
        {
            InitializeComponent();
            
        }

        //load book id
        public void loadBookID()
        {
            con.Open();
            string query = "Select MAX(BookID) AS BookID from library.books";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader ds = cmd.ExecuteReader();

            if (ds.HasRows)
            {
                while (ds.Read())
                {
                    string bookid=ds["BookID"].ToString();
                    label11.Text = (Convert.ToInt32(bookid) + 1).ToString();
                }
            }
            con.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            con = Database.ConnectDB();
            loadBookID();
            sho();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBookName.Text == "" || txtAuthorName.Text == "" || txtEditionVolume.Text == "" || txtPublisher.Text == "" || comCategory.SelectedIndex == -1)
                {
                    MessageBox.Show("cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtPrice.Text == "" || txtPrice.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Price Is Not Valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtISBN.Text == "")
                {
                    MessageBox.Show("Author Name cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtQuantity.Text == "" || txtQuantity.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Quantity cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (pictureBox2.Image == null)
                {
                    MessageBox.Show("upload a photo of the book", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    con.Open();

                    MySqlCommand cmdUpdate = new MySqlCommand("UPDATE library.books SET BookName = '"+txtBookName.Text+ "',AuthorName='"+txtAuthorName.Text+ "',EditionVolume='"+txtEditionVolume.Text+ "',Price='"+Convert.ToDouble(txtPrice.Text)+ "',Category='"+comCategory.Text+ "',Publisher='"+txtPublisher.Text+ "',ISBN='"+txtISBN.Text+ "',Quantity='"+Convert.ToInt32(txtQuantity.Text)+ "',Image=?Image,Barcode='" + txtbarcode.Text + "' WHERE BookID = '" + Convert.ToInt32(label11.Text) + "'", con);
                    
                    cmdUpdate.Parameters.Add("@Image", MySqlDbType.Blob);
                    cmdUpdate.Parameters["@Image"].Value = img;
                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("Record Update successfully", "Registration Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                    con.Close();
                this.sho();
                    clear();
            }
        }
            catch(Exception ex)
            {

            }

}

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to delete this Book ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {
                   
                    con.Open();

                    MySqlCommand cmdDelete = new MySqlCommand("DELETE FROM library.books WHERE BookID ='"+Convert.ToInt32(label11.Text)+"'", con);
                    cmdDelete.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully.", "Deleted Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    sho();
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void clear()
        {
            txtBookName.Text = "";

            txtAuthorName.Text = "";
            txtEditionVolume.Text = "";
            txtPublisher.Text = "";
            // comCategory.Clear();
            txtPrice.Clear();
            txtISBN.Clear();
            txtQuantity.Clear();
            txtbarcode.Clear();
            pictureBox2.Image = null;

            pictureBox1.Image = null;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBookName.Text == "" || txtAuthorName.Text == "" || txtEditionVolume.Text == ""  || txtPublisher.Text == ""|| comCategory.SelectedIndex == -1 || txtbarcode.Text=="" || txtbarcode.Text=="")
                {
                    MessageBox.Show("cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtPrice.Text == ""||txtPrice.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Price Is Not Valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtISBN.Text == "")
                {
                    MessageBox.Show("Author Name cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtQuantity.Text == "" || txtQuantity.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Quantity cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (pictureBox2.Image ==null)
                 {
                    MessageBox.Show("upload a photo of the book", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 }

            else
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    con.Open();
                    string Query = "insert into library.books(BookID,BookName,AuthorName,EditionVolume,Price,Category,Publisher,ISBN,Quantity,Image,Barcode) values('" + Convert.ToInt32(label11.Text) + "','" + txtBookName.Text + "','" + txtAuthorName.Text + "','" + txtEditionVolume.Text + "','" + Convert.ToDouble(txtPrice.Text) + "','"+comCategory.Text+"','"+txtPublisher.Text+"','"+txtISBN.Text+"','"+Convert.ToInt32(txtQuantity.Text)+ "',?Image,'" + txtbarcode.Text+ "')";
                    MySqlCommand cmdInsertBook = new MySqlCommand(Query, con);
                    cmdInsertBook.Parameters.Add("@Image", MySqlDbType.Blob);
                    cmdInsertBook.Parameters["@Image"].Value = img;
                    cmdInsertBook.ExecuteNonQuery();
                    
                    MessageBox.Show("Record added successfully", "Registration Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
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

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|**.jpg;*.png;*.gif;*.JPEG";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(opf.FileName);

            }

        }

        //Data Enter the datagridview1 
        public void sho()
        {
            dataGridView1.Rows.Clear();
            con.Open();
            MySqlCommand cmdAddData = new MySqlCommand("SELECT BookID,BookName,AuthorName,EditionVolume,Price,Category,Publisher,ISBN,Quantity,Image,Barcode from library.books", con);
            MySqlDataReader drAddData = cmdAddData.ExecuteReader();


            if (drAddData.HasRows)
            {
                while (drAddData.Read())
                {

                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dataGridView1);
                    newRow.Cells[0].Value = drAddData["BookID"].ToString(); ;
                    newRow.Cells[1].Value = drAddData["BookName"].ToString();
                    newRow.Cells[2].Value = drAddData["AuthorName"].ToString();
                    newRow.Cells[3].Value = drAddData["EditionVolume"].ToString();
                    newRow.Cells[4].Value = drAddData["Price"].ToString();
                    newRow.Cells[5].Value = drAddData["Category"].ToString();
                    newRow.Cells[6].Value = drAddData["Publisher"].ToString();
                    newRow.Cells[7].Value = drAddData["ISBN"].ToString();
                    newRow.Cells[8].Value = drAddData["Quantity"].ToString();
                    newRow.Cells[9].Value = drAddData["Image"];
                    newRow.Cells[10].Value = drAddData["Barcode"];

                    dataGridView1.Rows.Add(newRow);


                }

                con.Close();
            }
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            if (dataGridView1.SelectedRows.Count == 1)
            {

                label11.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtBookName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtAuthorName.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtEditionVolume.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtPrice.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comCategory.SelectedItem = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtPublisher.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtISBN.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtQuantity.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
                // pictureBox2.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString

                Byte[] data = new Byte[0];
                data = (Byte[])(dataGridView1.CurrentRow.Cells[9].Value);
                MemoryStream mem = new MemoryStream(data);
                pictureBox2.Image = Image.FromStream(mem);
                txtbarcode.Text= this.dataGridView1.CurrentRow.Cells[10].Value.ToString();
            }
            else
            {
                MessageBox.Show("no");
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtbarcode.Text == "")
            {
                MessageBox.Show("cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string barcode = txtbarcode.Text;
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
