using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq;

namespace Library
{
    public partial class Form3 : Form
    {
        string str = "Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True";
        SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True");

        public static Form3 form3instance=new Form3();
        public TextBox BookCode = new TextBox();
        public TextBox BookName=new TextBox();
        public TextBox Authour = new TextBox();
        public TextBox Status = new TextBox();
        public TextBox Price = new TextBox();
        public TextBox Quantity = new TextBox();
        public TextBox Departement = new TextBox();

        public Form3()
        {
            InitializeComponent();
            form3instance = this;
            BookName = Bname;
            Departement = department;
            Authour = authour;
            Status = status;
            Quantity =Quan;
            Price = Bprice;
            BookCode = BookCodetextBox;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

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
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Books(Book_Name, Book_Department, Auther_Name, Book_Price, Quantity,Status_Book) VALUES(@Book_Name, @Book_Department, @Auther_Name, @Book_Price, @Quantity,@Status_Book)", conn);
                   
                    cmd.Parameters.AddWithValue("@Book_Name", Bname.Text);
                    cmd.Parameters.AddWithValue("@Book_Department", department.Text);
                    cmd.Parameters.AddWithValue("@Auther_Name", authour.Text);
                    cmd.Parameters.AddWithValue("@Book_Price", Price.Text);
                    cmd.Parameters.AddWithValue("@Quantity",Quan.Text);
                    cmd.Parameters.AddWithValue("@Status_Book",status.Text);

                    cmd.ExecuteNonQuery();


                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT ID, Book_Name, Book_Department, Auther_Name, Status_Book, Book_Price FROM Books", conn);
                    DataTable Data = new DataTable();
                    sqlDa.Fill(Data);
                    Form5.form5instance.bookView.DataSource = Data;

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
            Bname.Clear();
            department.Clear();
            authour.Clear();
            Price.Clear();
            Quan.Clear();
            status.Clear();
        }
    }
}
