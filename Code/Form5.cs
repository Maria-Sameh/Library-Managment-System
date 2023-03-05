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
    public partial class Form5 : Form
    {
        string str = "Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True";
        SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True");

        public static Form5 form5instance=new Form5();
        public Button bookEdit = new Button();
        public Button bookDelete = new Button();
        public DataGridView bookView = new DataGridView();

        public Form5()
        {
            InitializeComponent();
            form5instance = this;

            bookEdit = DeleteBookbutton;
            bookDelete = EditBookbutton;
            bookView = BookGridView;

            if(Form1.form1instance.UserName.Text=="Admin")
            {
                EditBookbutton.Enabled = true;
                DeleteBookbutton.Enabled = true;
            }
            else
            {
                EditBookbutton.Enabled = false;
                DeleteBookbutton.Enabled = false;
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT ID, Book_Name, Book_Department, Auther_Name, Status_Book, Book_Price FROM Books", Conn);
            DataTable Data = new DataTable();
            sqlDa.Fill(Data);
            BookGridView.DataSource = Data;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();

                int i = BookGridView.SelectedRows[0].Index;
                string ID = BookGridView.Rows[i].Cells[0].Value.ToString();

                string Query = "DELETE FROM Books WHERE ID='" + ID + "'";
                SqlConnection ConDataDase = new SqlConnection(str);
                ConDataDase.Open();
                SqlCommand CMD = new SqlCommand(Query, ConDataDase);
                CMD.ExecuteNonQuery();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT ID, Book_Name, Book_Department, Auther_Name, Status_Book, Book_Price FROM Books", Conn);
                DataTable Data = new DataTable();
                sqlDa.Fill(Data);
                BookGridView.DataSource = Data;


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

                int i = BookGridView.SelectedRows[0].Index;
                string ID = BookGridView.Rows[i].Cells[0].Value.ToString();

                string Query = "UPDATE Books SET Book_Name='" + Form3.form3instance.BookName.Text + "' ,Book_Department='" + Form3.form3instance.Departement.Text + "', Auther_Name='" + Form3.form3instance.Authour.Text + "',Status_Book ='" + Form3.form3instance.Status.Text + "', Book_Price='" + Form3.form3instance.Price.Text + "' WHERE ID ='" + ID + "'";
                SqlConnection ConDataDase = new SqlConnection(str);
                ConDataDase.Open();
                SqlCommand CMD = new SqlCommand(Query, ConDataDase);
                CMD.ExecuteNonQuery();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT ID, Book_Name, Book_Department, Auther_Name, Status_Book, Book_Price FROM Books", Conn);
                DataTable Data = new DataTable();
                sqlDa.Fill(Data);
                BookGridView.DataSource = Data;

                ConDataDase.Close();
                Conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void BookGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (BookGridView.SelectedRows.Count >= 0)
                {
                    Conn.Open();

                    int i = BookGridView.SelectedRows[0].Index;
                    string ID = BookGridView.Rows[i].Cells[0].Value.ToString();

                    SqlCommand CMD = new SqlCommand("SELECT * FROM Books WHERE ID='" + ID + "'", Conn);
                    CMD.Parameters.AddWithValue(ID, Convert.ToString(Form3.form3instance.BookCode.Text));
                    SqlDataReader Read = CMD.ExecuteReader();


                    while (Read.Read())
                    {
                        Form3.form3instance.BookCode.Text= Read.GetValue(0).ToString();
                        Form3.form3instance.BookName.Text = Read.GetValue(1).ToString();
                        Form3.form3instance.Authour.Text = Read.GetValue(3).ToString();
                        Form3.form3instance.Status.Text = Read.GetValue(6).ToString();
                        Form3.form3instance.Quantity.Text = Read.GetValue(5).ToString();
                        Form3.form3instance.Price.Text = Read.GetValue(4).ToString();
                        Form3.form3instance.Departement.Text = Read.GetValue(2).ToString();
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
