using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library
{
    public partial class Form9 : Form
    {
        string str = "Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True";
        SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True");
        public static Form9 form9instance=new Form9();
        public DataGridView IssueView;
        public DataGridView ReturnView;
        public Form9()
        {
            InitializeComponent();
            form9instance = this;
            IssueView = IssueBooksDoubledataGridView;
            ReturnView = ReturnBooksDoubledataGridView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT [Student_Roll_numer], [Student_Name], [Student_Phone_Number], [Student_Department], [Student_Semester], [Student_Email], [Book_Name], [Book_Issue_Date] FROM [dbo].[Issue_Book]", Conn);
                DataTable Data = new DataTable();
                sqlDa.Fill(Data);
                IssueBooksDoubledataGridView.DataSource = Data;

                sqlDa = new SqlDataAdapter("SELECT [Student_Roll_numer], [Student_Name], [Student_Phone_Number], [Book_Name],  [Book_Issue_Date], [Book_Return_Date]  FROM [dbo].[BookReturn]", Conn);
                Data = new DataTable();
                sqlDa.Fill(Data);
                ReturnBooksDoubledataGridView.DataSource = Data;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT [Student_Roll_numer], [Student_Name], [Student_Phone_Number], [Student_Department], [Student_Semester], [Student_Email], [Book_Name], [Book_Issue_Date] FROM [dbo].[Issue_Book] WHERE [Student_Roll_numer]='" + SearchCompleteDetailstextBox.Text + "'", Conn);
                DataTable Data = new DataTable();
                sqlDa.Fill(Data);
                IssueBooksDoubledataGridView.DataSource = Data;

                sqlDa = new SqlDataAdapter("SELECT [Student_Roll_numer], [Student_Name], [Student_Phone_Number], [Book_Name],  [Book_Issue_Date], [Book_Return_Date] FROM [dbo].[BookReturn] WHERE [Student_Roll_numer]='" + SearchCompleteDetailstextBox.Text + "'", Conn);
                Data = new DataTable();
                sqlDa.Fill(Data);
                ReturnBooksDoubledataGridView.DataSource = Data;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }
    }
}
