
namespace Library_Management.Reports
{
    partial class IssuReports
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IssuBooksDataSet = new Library_Management.Reports.IssuBooksDataSet();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtpissubook = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IssuBooksDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.IssuBooksDataSet;
            // 
            // IssuBooksDataSet
            // 
            this.IssuBooksDataSet.DataSetName = "IssuBooksDataSet";
            this.IssuBooksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer2
            // 
            this.reportViewer2.DocumentMapWidth = 86;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Library_Management.Reports.IssuBooks.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(2, 77);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(1423, 693);
            this.reportViewer2.TabIndex = 2;
            this.reportViewer2.Load += new System.EventHandler(this.reportViewer2_Load);
            // 
            // dtpissubook
            // 
            this.dtpissubook.Location = new System.Drawing.Point(284, 22);
            this.dtpissubook.Name = "dtpissubook";
            this.dtpissubook.Size = new System.Drawing.Size(250, 22);
            this.dtpissubook.TabIndex = 3;
            this.dtpissubook.Value = new System.DateTime(2022, 6, 7, 0, 0, 0, 0);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(572, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IssuReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 526);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpissubook);
            this.Controls.Add(this.reportViewer2);
            this.Name = "IssuReports";
            this.Text = "IssuReports";
            this.Load += new System.EventHandler(this.IssuReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IssuBooksDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private IssuBooksDataSet IssuBooksDataSet;
        private System.Windows.Forms.DateTimePicker dtpissubook;
        private System.Windows.Forms.Button button1;
    }
}