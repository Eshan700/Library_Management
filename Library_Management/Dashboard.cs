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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void loadForm (Form form)
        { 
            panel2.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel2.Controls.Add(form);
            form.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            colourChange(button1);
            Home mc = new Home();
            loadForm(mc);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            colourChange(button4);
            IssueBook mc = new IssueBook();
            loadForm(mc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colourChange(button1);
            Home mc = new Home();
            loadForm(mc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colourChange(button2);
            Book mc = new Book();
            loadForm(mc);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colourChange(button3);
            Students mc = new Students();
            loadForm(mc);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            colourChange(button5);
            ReturnBook mc = new ReturnBook();
            loadForm(mc);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            colourChange(button8);
            users mc = new users();
            loadForm(mc);
        }

        private void colourChange(Button btn)
        {
            button1.BackColor = Color.Transparent;
            button2.BackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            button4.BackColor = Color.Transparent;
            button5.BackColor = Color.Transparent;
            button6.BackColor = Color.Transparent;
            button7.BackColor = Color.Transparent;
            button8.BackColor = Color.Transparent;

            btn.BackColor = Color.FromArgb(233, 150, 122);

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            colourChange(button7);
            pastPapers mc = new pastPapers();
            loadForm(mc);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
                colourChange(button6);
            MainReports mc = new MainReports();
            loadForm(mc);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
