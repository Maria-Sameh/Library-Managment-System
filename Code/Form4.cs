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
    public partial class Form4 : Form
    {
        string str = "Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True";
        SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True");

        public static Form4 form4instance= new Form4();
        public TextBox studentname;
        public TextBox EnrollementNo;
        public TextBox Departement;
        public TextBox StudentSemester;
        public TextBox StudentContact;
        public TextBox Email;
       
        public Form4()
        {
            InitializeComponent();
            form4instance = this;
            studentname = sname;
            EnrollementNo = enroll;
            Departement = sDepart;
            StudentSemester = Ssemester;
            StudentContact = contact;
            Email = email;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Student(Roll_numer, Student_Name, Student_Phone_Number, Student_Department, Student_Semester, Student_Email) VALUES(@Roll_numer, @Student_Name, @Student_Phone_Number, @Student_Department, @Student_Semester, @Student_Email)", conn);
                    cmd.Parameters.AddWithValue("@Roll_numer", enroll.Text);
                    cmd.Parameters.AddWithValue("@Student_Name", sname.Text);
                    cmd.Parameters.AddWithValue("@Student_Phone_Number", contact.Text);
                    cmd.Parameters.AddWithValue("@Student_Department", sDepart.Text);
                    cmd.Parameters.AddWithValue("@Student_Semester", Ssemester.Text);
                    cmd.Parameters.AddWithValue("@Student_Email", email.Text);
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Student", conn);
                    DataTable Data = new DataTable();
                    sqlDa.Fill(Data);
                    Form6.form6instance.StudentView.DataSource = Data;

                    MessageBox.Show("Added Successfully");

                    conn.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            enroll.Clear();
            sname.Clear();
            contact.Clear();
            sDepart.Clear();
            Ssemester.Clear();
            email.Clear();
        }
    }
}
