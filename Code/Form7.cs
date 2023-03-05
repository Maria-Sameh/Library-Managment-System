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
    public partial class Form7 : Form
    {
        string str = "Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True";
        SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True");

        public static Form7 form7inctance=new Form7();
        public ComboBox BookNameIssue;

        public Form7()
        {
            InitializeComponent();
            form7inctance = this;
            BookNameIssue = BookNamecomboBox;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM [dbo].[Issue_Book] WHERE [Student_Roll_numer]='" + SearchIssueBooktextBox.Text + "'", Conn);
                DataTable Data = new DataTable();
                sqlDa.Fill(Data);
                IssueBookdataGridView.DataSource = Data;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }
        private void button3_Click_2(object sender, EventArgs e)
        {
            float Amount = 0, BooksPrice = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();

                    SqlCommand CMD = new SqlCommand("SELECT * FROM Credit WHERE RollNumberCredit='" + Form4.form4instance.EnrollementNo.Text + "'", conn);
                    SqlDataReader ReadAmount = CMD.ExecuteReader();

                    while (ReadAmount.Read())
                    {
                        Amount = float.Parse(ReadAmount.GetValue(1).ToString());
                    }
                    ReadAmount.Close();
                    CMD = new SqlCommand("SELECT * FROM Books WHERE Book_Name='" + BookNamecomboBox.Text + "'", conn);
                    SqlDataReader ReadBooksPrice = CMD.ExecuteReader();

                    while (ReadBooksPrice.Read())
                    {
                        BooksPrice = float.Parse(ReadBooksPrice.GetValue(4).ToString());
                    }
                    ReadBooksPrice.Close();
                    string Query = "UPDATE Credit SET Amount='" + (Amount - BooksPrice) + "' WHERE RollNumberCredit ='" + Form4.form4instance.EnrollementNo.Text + "'";
                    CMD = new SqlCommand(Query, conn);
                    CMD.ExecuteNonQuery();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Issue_Book(Student_Roll_numer, Student_Name, Student_Phone_Number, Student_Department, Student_Semester, Student_Email, Book_Name, Book_Issue_Date) VALUES(@Roll_numer, @Student_Name, @Student_Phone_Number, @Student_Department, @Student_Semester, @Student_Email,@Bname,@IssueDate)", conn);
                    cmd.Parameters.AddWithValue("@Roll_numer", Form4.form4instance.EnrollementNo.Text);
                    cmd.Parameters.AddWithValue("@Student_Name", Form4.form4instance.studentname.Text);
                    cmd.Parameters.AddWithValue("@Student_Phone_Number", Form4.form4instance.StudentContact.Text);
                    cmd.Parameters.AddWithValue("@Student_Department", Form4.form4instance.Departement.Text);
                    cmd.Parameters.AddWithValue("@Student_Semester", Form4.form4instance.StudentSemester.Text);
                    cmd.Parameters.AddWithValue("@Student_Email", Form4.form4instance.Email.Text);
                    cmd.Parameters.AddWithValue("@Bname", BookNamecomboBox.Text);
                    cmd.Parameters.AddWithValue("@IssueDate", IssueBookdateTimePicker.Text);
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Issue_Book", conn);
                    DataTable Data = new DataTable();
                    sqlDa.Fill(Data);
                    IssueBookdataGridView.DataSource = Data;

                    conn.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }
     
        

        private void IssueBookdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IssueBookdataGridView.SelectedRows.Count >= 0)
                {
                    Conn.Open();

                    int i = IssueBookdataGridView.SelectedRows[0].Index;
                    string ID = IssueBookdataGridView.Rows[i].Cells[0].Value.ToString();

                    SqlCommand CMD = new SqlCommand("SELECT * FROM Issue_Book WHERE ID='" + ID + "'", Conn);
                    CMD.Parameters.AddWithValue(ID, Convert.ToString(Form3.form3instance.BookCode.Text));

                    SqlDataReader Read = CMD.ExecuteReader();

                    while (Read.Read())
                    {
                        BookNamecomboBox.Text = Read.GetValue(1).ToString();
                        IssueBookdateTimePicker.Text = Read.GetValue(4).ToString();
                    }
                    Conn.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Issue_Book", Conn);
                DataTable Data = new DataTable();
                sqlDa.Fill(Data);
                IssueBookdataGridView.DataSource = Data;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }
    }
}
