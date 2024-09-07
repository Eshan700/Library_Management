
namespace Library_Management.Reports
{
    partial class StudentReport
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
            this.studentdataset = new Library_Management.Reports.studentdataset();
            this.StudentreportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentdataset)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.studentdataset;
            // 
            // studentdataset
            // 
            this.studentdataset.DataSetName = "studentdataset";
            this.studentdataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // StudentreportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.StudentreportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.StudentreportViewer1.LocalReport.ReportEmbeddedResource = "Library_Management.Reports.StudentReports.rdlc";
            this.StudentreportViewer1.Location = new System.Drawing.Point(-2, 0);
            this.StudentreportViewer1.Name = "StudentreportViewer1";
            this.StudentreportViewer1.ServerReport.BearerToken = null;
            this.StudentreportViewer1.Size = new System.Drawing.Size(1499, 773);
            this.StudentreportViewer1.TabIndex = 0;
            this.StudentreportViewer1.Load += new System.EventHandler(this.StudentreportViewer1_Load);
            // 
            // StudentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 698);
            this.Controls.Add(this.StudentreportViewer1);
            this.Name = "StudentReport";
            this.Text = "StudentReport";
            this.Load += new System.EventHandler(this.StudentReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentdataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer StudentreportViewer1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private studentdataset studentdataset;
    }
}