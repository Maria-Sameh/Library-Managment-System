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
    public partial class Form6 : Form
    {
        string str = "Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True";
        SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True");

        public static Form6 form6instance=new Form6();
        public DataGridView StudentView=new DataGridView();
        public Form6()
        {
            InitializeComponent();
            form6instance = this;

            StudentView = StudentdataGridView;

            if (Form1.form1instance.UserName.Text == "Admin")
            {
                EditStudentbutton.Enabled = true;
                DeleteStudentbutton.Enabled = true;
            }
            else
            {
                EditStudentbutton.Enabled = false;
                DeleteStudentbutton.Enabled = false;
            }


            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Student", Conn);
            DataTable Data = new DataTable();
            sqlDa.Fill(Data);
            StudentdataGridView.DataSource = Data;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();

                int i = StudentdataGridView.SelectedRows[0].Index;
                string Roll_numer = StudentdataGridView.Rows[i].Cells[0].Value.ToString();

                string Query = "DELETE FROM Student WHERE Roll_numer='" + Roll_numer + "'";
                SqlConnection ConDataDase = new SqlConnection(str);
                ConDataDase.Open();
                SqlCommand CMD = new SqlCommand(Query, ConDataDase);
                CMD.ExecuteNonQuery();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Student", Conn);
                DataTable Data = new DataTable();
                sqlDa.Fill(Data);
                StudentdataGridView.DataSource = Data;

                ConDataDase.Close();
                Conn.Close();
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
                Conn.Open();

                int i = StudentdataGridView.SelectedRows[0].Index;
                string Roll_numer = StudentdataGridView.Rows[i].Cells[0].Value.ToString();

                string Query = "UPDATE Student SET Student_Name='" + Form4.form4instance.studentname.Text + "' ,Student_Phone_Number='" + Form4.form4instance.StudentContact.Text + "', Student_Department='" + Form4.form4instance.Departement.Text + "',Student_Semester ='" + Form4.form4instance.StudentSemester.Text + "', Student_Email='" + Form4.form4instance.Email.Text + "' WHERE Roll_numer ='" + Roll_numer + "'";
                SqlConnection ConDataDase = new SqlConnection(str);
                ConDataDase.Open();
                SqlCommand CMD = new SqlCommand(Query, ConDataDase);
                CMD.ExecuteNonQuery();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Student", Conn);
                DataTable Data = new DataTable();
                sqlDa.Fill(Data);
                StudentdataGridView.DataSource = Data;

                ConDataDase.Close();
                Conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }

        }

        private void StudentdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (StudentdataGridView.SelectedRows.Count >= 0)
                {
                    Conn.Open();

                    int i = StudentdataGridView.SelectedRows[0].Index;
                    string Roll_numer = StudentdataGridView.Rows[i].Cells[0].Value.ToString();

                    SqlCommand CMD = new SqlCommand("SELECT * FROM Student WHERE Roll_numer='" + Roll_numer + "'", Conn);
                    CMD.Parameters.AddWithValue(Roll_numer, Convert.ToString(Form4.form4instance.EnrollementNo.Text));

                    SqlDataReader Read = CMD.ExecuteReader();

                    while (Read.Read())
                    {
                        Form4.form4instance.EnrollementNo.Text = Read.GetValue(0).ToString();
                        Form4.form4instance.Departement.Text = Read.GetValue(3).ToString();
                        Form4.form4instance.StudentSemester.Text = Read.GetValue(4).ToString();
                        Form4.form4instance.StudentContact.Text = Read.GetValue(2).ToString();
                        Form4.form4instance.Email.Text = Read.GetValue(5).ToString();
                        Form4.form4instance.studentname.Text = Read.GetValue(1).ToString();
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
    }
}
