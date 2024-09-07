using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Library_Management
{
    public partial class pastPapers : Form
    {
        MySqlConnection con;
        public pastPapers()
        {
            InitializeComponent();
            con = Database.ConnectDB();
            sho();
        }

        private void button6_Click(object sender, EventArgs e)
        {

                         OpenFileDialog FileUpload = new OpenFileDialog();
                        FileUpload.Filter = "PDF Document(*.pdf)|*.pdf";
            if (FileUpload.ShowDialog() == DialogResult.OK)
            {
                string filename = FileUpload.FileName;
                string filename1 = Path.GetFileName(filename);
                uploadFille(filename,filename1);
               
            }

            
            sho();

      
        }

            public void uploadFille(string file,string name)
        {
            con.Open();
            FileStream fstream = File.OpenRead(file);
            byte[] contents = new byte[fstream.Length];
            fstream.Read(contents, 0, (int)fstream.Length);
            fstream.Close();

            string query = "insert into library.pastpapers(Name,Data) values (@Name, @Data)";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Name", name);
                
                cmd.Parameters.AddWithValue("@Data", contents);
              
                cmd.ExecuteNonQuery();
                con.Close();
            }
            con.Close();
        }

        //show grid
        public void sho()
        {
           
            string query = "Select *from library.pastpapers";
            dataGridView1.Rows.Clear();
            con.Open();
            MySqlCommand cmdAddData = new MySqlCommand(query, con);
            MySqlDataReader drAddData = cmdAddData.ExecuteReader();
            if (drAddData.HasRows)
            {
                while (drAddData.Read())
                {
                   DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dataGridView1);
                    newRow.Cells[0].Value = drAddData["id"].ToString(); ;
                    newRow.Cells[1].Value = drAddData["Name"].ToString();
                    newRow.Cells[2].Value = drAddData["Data"].ToString();
                    newRow.Cells[3].Value = "Download";                  
                    dataGridView1.Rows.Add(newRow);
                }
                con.Close();
            }
            con.Close();            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int id = Convert.ToInt16((row.Cells[0].Value));
                byte[] bytes;
                string fileName, contentType;
               
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "select Name, Data from pastpapers where Id=@Id";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            bytes = (byte[])sdr["Data"];
                            
                            fileName = sdr["Name"].ToString();

                            Stream stream;
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "PDF Document(*.pdf)|*.pdf";
                            saveFileDialog.FilterIndex = 1;
                            saveFileDialog.RestoreDirectory = true;
                            saveFileDialog.FileName = fileName;
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                stream = saveFileDialog.OpenFile();
                                stream.Write(bytes, 0, bytes.Length);
                                stream.Close();
                            }
                        }
                    }
                    con.Close();
               
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
