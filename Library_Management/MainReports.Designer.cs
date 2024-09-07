
namespace Library_Management
{
    partial class MainReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReturnbooks = new System.Windows.Forms.Button();
            this.btnIssuBook = new System.Windows.Forms.Button();
            this.btnbooks = new System.Windows.Forms.Button();
            this.btnstudent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReturnbooks
            // 
            this.btnReturnbooks.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReturnbooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnbooks.Image = global::Library_Management.Properties.Resources.icons8_borrow_book_96;
            this.btnReturnbooks.Location = new System.Drawing.Point(700, 326);
            this.btnReturnbooks.Name = "btnReturnbooks";
            this.btnReturnbooks.Size = new System.Drawing.Size(252, 241);
            this.btnReturnbooks.TabIndex = 3;
            this.btnReturnbooks.Text = "Return Books Details";
            this.btnReturnbooks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReturnbooks.UseVisualStyleBackColor = false;
            this.btnReturnbooks.Click += new System.EventHandler(this.btnReturnbooks_Click);
            // 
            // btnIssuBook
            // 
            this.btnIssuBook.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnIssuBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssuBook.Image = global::Library_Management.Properties.Resources.icons8_knowledge_sharing_96;
            this.btnIssuBook.Location = new System.Drawing.Point(91, 269);
            this.btnIssuBook.Name = "btnIssuBook";
            this.btnIssuBook.Size = new System.Drawing.Size(603, 298);
            this.btnIssuBook.TabIndex = 2;
            this.btnIssuBook.Text = "IssuBooks";
            this.btnIssuBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIssuBook.UseVisualStyleBackColor = false;
            this.btnIssuBook.Click += new System.EventHandler(this.btnIssuBook_Click);
            // 
            // btnbooks
            // 
            this.btnbooks.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnbooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbooks.Image = global::Library_Management.Properties.Resources.icons8_book_96;
            this.btnbooks.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnbooks.Location = new System.Drawing.Point(700, 32);
            this.btnbooks.Name = "btnbooks";
            this.btnbooks.Size = new System.Drawing.Size(252, 291);
            this.btnbooks.TabIndex = 1;
            this.btnbooks.Text = "Books Reports";
            this.btnbooks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnbooks.UseVisualStyleBackColor = false;
            this.btnbooks.Click += new System.EventHandler(this.btnbooks_Click);
            // 
            // btnstudent
            // 
            this.btnstudent.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnstudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstudent.Image = global::Library_Management.Properties.Resources.icons8_people_96;
            this.btnstudent.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnstudent.Location = new System.Drawing.Point(91, 32);
            this.btnstudent.Name = "btnstudent";
            this.btnstudent.Size = new System.Drawing.Size(607, 233);
            this.btnstudent.TabIndex = 0;
            this.btnstudent.Text = "Student";
            this.btnstudent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnstudent.UseVisualStyleBackColor = false;
            this.btnstudent.Click += new System.EventHandler(this.btnstudent_Click);
            // 
            // MainReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1021, 615);
            this.Controls.Add(this.btnReturnbooks);
            this.Controls.Add(this.btnIssuBook);
            this.Controls.Add(this.btnbooks);
            this.Controls.Add(this.btnstudent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainReports";
            this.Text = "MainReports";
            this.Load += new System.EventHandler(this.MainReports_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnstudent;
        private System.Windows.Forms.Button btnbooks;
        private System.Windows.Forms.Button btnIssuBook;
        private System.Windows.Forms.Button btnReturnbooks;
    }
}