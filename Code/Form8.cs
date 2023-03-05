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
    public partial class Form8 : Form
    {
        string str = "Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True";
        SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True");
        
        public static Form8 form8inctance=new Form8();
        public ComboBox BookName=new ComboBox();

        public Form8()
        {
            InitializeComponent();
            form8inctance = this;
            BookName = BookNamecomboBox;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM BookReturn WHERE Student_Roll_numer='" + SearchStudenttextBox.Text + "'", Conn);
                DataTable Data = new DataTable();
                sqlDa.Fill(Data);
                ReturnBookdataGridView.DataSource = Data;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void ReturnBookdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ReturnBookdataGridView.SelectedRows.Count >= 0)
                {
                    Conn.Open();

                    int i = ReturnBookdataGridView.SelectedRows[0].Index;
                    string ID = ReturnBookdataGridView.Rows[i].Cells[0].Value.ToString();

                    SqlCommand CMD = new SqlCommand("SELECT * FROM BookReturn WHERE ID='" + ID + "'", Conn);
                    CMD.Parameters.AddWithValue(ID, Convert.ToString(Form3.form3instance.BookCode.Text));

                    SqlDataReader Read = CMD.ExecuteReader();

                    while (Read.Read())
                    {
                        BookNamecomboBox.Text = Read.GetValue(1).ToString();
                        IssuedateTimePicker.Text = Read.GetValue(4).ToString();
                        ReturndateTimePicker.Text = Read.GetValue(5).ToString();
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

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO BookReturn(Student_Roll_numer, Student_Name, Student_Phone_Number, Student_Department, Student_Semester, Student_Email,Book_Name,Book_Issue_Date) VALUES(@Roll_numer, @Student_Name, @Student_Phone_Number, @Student_Department, @Student_Semester, @Student_Email,@Bname,@IssueDate)", conn);
                    cmd.Parameters.AddWithValue("@Roll_numer", Form4.form4instance.EnrollementNo.Text);
                    cmd.Parameters.AddWithValue("@Student_Name", Form4.form4instance.studentname.Text);
                    cmd.Parameters.AddWithValue("@Student_Phone_Number", Form4.form4instance.StudentContact.Text);
                    cmd.Parameters.AddWithValue("@Student_Department", Form4.form4instance.Departement.Text);
                    cmd.Parameters.AddWithValue("@Student_Semester", Form4.form4instance.StudentSemester.Text);
                    cmd.Parameters.AddWithValue("@Student_Email", Form4.form4instance.Email.Text);
                    cmd.Parameters.AddWithValue("@Bname", BookNamecomboBox.Text);
                    cmd.Parameters.AddWithValue("@IssueDate", IssuedateTimePicker.Text);
                    cmd.Parameters.AddWithValue("@IssueDate", ReturndateTimePicker.Text);
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM BookReturn", conn);
                    DataTable Data = new DataTable();
                    sqlDa.Fill(Data);
                    ReturnBookdataGridView.DataSource = Data;

                    conn.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM BookReturn", Conn);
                    DataTable Data = new DataTable();
                    sqlDa.Fill(Data);
                    ReturnBookdataGridView.DataSource = Data;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }
    }
}
