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
    public partial class Credit : Form
    {
        string str = "Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True";
        SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True");


        public Credit()
        {
            InitializeComponent();


            if (Form1.form1instance.UserName.Text == "Admin")
            {
                Editbutton.Enabled = true;
                Savebutton.Enabled = true;
            }
            else
            {
                Editbutton.Enabled = false;
                Savebutton.Enabled = false;
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT  [Student_Name], [Student_Phone_Number], [RollNumberCredit], [Amount] FROM [dbo].[Student] INNER JOIN [dbo].[Credit] ON [RollNumberCredit]=[Roll_numer]", Conn);
            DataTable Data = new DataTable();
            sqlDa.Fill(Data);
            CreditdataGridView.DataSource = Data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();

                    
                    SqlCommand cmd = new SqlCommand("INSERT INTO Credit(RollNumberCredit, Amount) VALUES(@RollNumberCredit, @Amount)", conn);
                    cmd.Parameters.AddWithValue("@Amount", PersonAccount.Text);
                    cmd.Parameters.AddWithValue("@RollNumberCredit", enroll.Text); 
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT  [Student_Name], [Student_Phone_Number], [RollNumberCredit], [Amount] FROM [dbo].[Student] INNER JOIN [dbo].[Credit] ON [RollNumberCredit]=[Roll_numer]", conn);
                    DataTable Data = new DataTable();
                    sqlDa.Fill(Data);
                    CreditdataGridView.DataSource = Data;


                    PersonAccount.Clear();
                    enroll.Clear();

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
            PersonAccount.Clear();
            enroll.Clear();
        }

        private void CreditdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CreditdataGridView.SelectedRows.Count >= 0)
                {
                    Conn.Open();

                    int i = CreditdataGridView.SelectedRows[0].Index;
                    string RollNumberCredit = CreditdataGridView.Rows[i].Cells[2].Value.ToString();

                    SqlCommand CMD = new SqlCommand("SELECT * FROM Credit WHERE RollNumberCredit='" + RollNumberCredit + "'", Conn);
                    CMD.Parameters.AddWithValue(RollNumberCredit, Convert.ToString(enroll.Text));
                    SqlDataReader Read = CMD.ExecuteReader();
                
                    while (Read.Read())
                    {
                        enroll.Text = Read.GetValue(0).ToString();
                        PersonAccount.Text = Read.GetValue(1).ToString();
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

        private void Editbutton_Click(object sender, EventArgs e)
        {
            float amount = 0, Add = 0;
            try
            {
                Conn.Open();

                int i = CreditdataGridView.SelectedRows[0].Index;
                string RollNumberCredit = CreditdataGridView.Rows[i].Cells[2].Value.ToString();

                SqlCommand CMD = new SqlCommand("SELECT * FROM Credit WHERE RollNumberCredit='" + RollNumberCredit + "'", Conn);
                CMD.Parameters.AddWithValue(RollNumberCredit, Convert.ToString(enroll.Text));

                SqlDataReader Read = CMD.ExecuteReader();

                while (Read.Read())
                {
                    amount = float.Parse(Read.GetValue(1).ToString());
                }
                Read.Close();

                Add = float.Parse(PersonAccount.Text);
                SqlConnection ConDataDase;
                if (Add > 0)
                {
                        string Query = "UPDATE Credit SET Amount='" + (Add + amount) + "' WHERE RollNumberCredit ='" + RollNumberCredit + "'";
                        ConDataDase = new SqlConnection(str);
                        ConDataDase.Open();

                        CMD = new SqlCommand(Query, ConDataDase);
                        CMD.ExecuteNonQuery();

                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT [Student_Name], [Student_Phone_Number], [RollNumberCredit], [Amount] FROM [dbo].[Student] INNER JOIN [dbo].[Credit] ON [RollNumberCredit]=[Roll_numer]", Conn);
                    DataTable Data = new DataTable();
                    sqlDa.Fill(Data);
                    CreditdataGridView.DataSource = Data;

                    ConDataDase.Close();
                }
                Conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
         }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
}
