using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library
{
    public partial class Form1 : Form
    {
        string str = "Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True";
        SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-IHGIJ8V\\STEVENSERVER;Initial Catalog=Library;Integrated Security=True");

        public static Form1 form1instance = new Form1(); 
        public TextBox UserName = new TextBox();
        public TextBox Password = new TextBox();

        public Form1()
        {
            InitializeComponent();
            PasswordtextBox.PasswordChar = '*';
            SignUpPasswordtextBox.PasswordChar = '*';

            form1instance = this;
            WrongPasswordlabel.Visible = false;

            UserName = UsernametextBox;
            Password = PasswordtextBox;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUppanel.Visible = true;
            LogInpanel.Visible = false;
        }

        private void LogInpanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SignUppanel.Visible = false;
            LogInpanel.Visible = true;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            UsernametextBox.Clear();
        }

        private void UsernametextBox_MouseLeave(object sender, EventArgs e)
        {
            if(UsernametextBox.Text=="")
            {
                UsernametextBox.Text = "Username";
            }
        }

        private void PasswordtextBox_Click(object sender, EventArgs e)
        {
            PasswordtextBox.Clear();
        }

        private void PasswordtextBox_MouseLeave(object sender, EventArgs e)
        {
            if (PasswordtextBox.Text == "")
            {
                PasswordtextBox.Text = "Password";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            
                if (UsernametextBox.Text == "Username")
                   Usernamepanel.BackColor = Color.Red;
                else
                    Usernamepanel.BackColor = Color.Black;

               if (PasswordtextBox.Text == "Password")
                   Passwordpanel.BackColor = Color.Red;
                else
                    Passwordpanel.BackColor = Color.Black;


                if (UsernametextBox.Text!= "Username" && PasswordtextBox.Text!= "Password")
                {
                    Conn.Open();


                    string logIn = "SELECT * FROM LogIn WHERE UserName='" + UsernametextBox.Text + "'";
                    SqlCommand cmd = new SqlCommand(logIn, Conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    string pass = "";

                    while (dr.Read())
                    {
                        pass = dr.GetValue(1).ToString();
                    }
                    if (UsernametextBox.Text == "Admin" && pass == PasswordtextBox.Text)
                    {
                        this.Hide();
                        Form2 form = new Form2();
                        form.Show();
                    }
                    else if(UsernametextBox.Text != "Admin" && pass == PasswordtextBox.Text)
                    {
                        this.Hide();
                        Form2 form = new Form2();
                        form.Show();
                    }
                    else
                    {
                        WrongPasswordlabel.Visible = true;
                    }
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
            if (FirstNametextBox.Text == "")
                fnamelabel.Visible = true;
            else
                fnamelabel.Visible = false;

            if (LastNametextBox.Text == "")
                lnamelable.Visible = true;
            else
                lnamelable.Visible = false;

            if (UserNameRegisttextBox.Text == "")
                usernamelabel2.Visible = true;
            else
                usernamelabel2.Visible = false;

            if (SignUpPasswordtextBox.Text == "")
                passwordlabel.Visible = true;
            else
                passwordlabel.Visible = false;

            if (EmailtextBox.Text == "")
                emaillabel.Visible = true;
            else
                emaillabel.Visible = false;

            if (ContactNumbertextBox.Text == "")
                contactlabel.Visible = true;
            else
                contactlabel.Visible = false;


            if (RollNoRegisttextBox.Text == "")
                RollNolabel.Visible = true;
            else
                RollNolabel.Visible = false;




            //  if (ConfirmPassCreatetextBox.Text != "" && ConfirmPassCreatetextBox.Text != CreatePasswordtextBox.Text)
            //    NotMatch.Visible = true;
            //else if (ConfirmPassCreatetextBox.Text != "" && ConfirmPassCreatetextBox.Text == CreatePasswordtextBox.Text)
            //NotMatch.Visible = false;

            //f (FirstNametextBox.Text == "")
            // fnamelabel.Visible = true;
            //lse
            //fnamelabel.Visible = false;


            //if (CreatePasswordtextBox.Text == ConfirmPassCreatetextBox.Text && CreatePasswordtextBox.Text != "" && ConfirmPassCreatetextBox.Text != "" && CreateUserNametextBox.Text != "")
            //{
            //   try
            //   {
            //       Conn.Open();
            //       SqlCommand cmd = new SqlCommand("INSERT INTO log_In(UserName, Password) VALUES(@UserName,@Password)", Conn);
            //       cmd.Parameters.AddWithValue("@UserName", CreateUserNametextBox.Text);
            //        cmd.Parameters.AddWithValue("@Password", SignUpPasswordtextBox.Text);
            //        cmd.ExecuteNonQuery();

            //        ConfirmPasswordCreatelabel.Visible = false;
            //        UsernameCreateLabel.Visible = false;
            //       PasswordCreateLabel.Visible = false;
            //       NotMatch.Visible = false;
            //       MessageBox.Show("Created Successfully");
            //       Conn.Close();
            //   }
            //   catch (Exception E)
            //   {
            //       MessageBox.Show(E.Message);
            //       Conn.Close();
            //   }



        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }
    }
}
