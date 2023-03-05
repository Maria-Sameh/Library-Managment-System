using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Library
{
    public partial class Form2 : Form
    {
        public static Form2 form2instance = new Form2();
        public Button Addstudent = new Button();
        public Button AddBook = new Button();

        public Form2()
        {
            InitializeComponent();
            BooksListpanel.Visible = false;
            StudentListpanel.Visible = false;

            form2instance = this;
            Addstudent = AddStudentbutton;
            AddBook = AddBookbutton;

            if (Form1.form1instance.UserName.Text == "Admin")
            {
                AddStudentbutton.Enabled = true;
                AddBookbutton.Enabled = true;
            }
            else
            {
                AddStudentbutton.Enabled = false;
                AddBookbutton.Enabled = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 Form = new Form1();
            this.Hide();
            Form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BooksListpanel.Visible = true;
            StudentListpanel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BooksListpanel.Visible = false;
            StudentListpanel.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form3 Form = new Form3();
            Form.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form4 Form = new Form4();
            Form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 Form = new Form5();
            Form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form6 Form = new Form6();
            Form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 Form = new Form7();
            Form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 Form = new Form8();
            Form.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form1 Form = new Form1();
            this.Hide();
            Form.Show();
        }

        private void Mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form9 Form = new Form9();
            Form.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Credit Form = new Credit();
            Form.Show();
        }
    }
}
