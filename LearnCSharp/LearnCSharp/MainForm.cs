using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using LearnCSharp.Database;

namespace LearnCSharp
{
    public partial class MainForm : Form
    {
        public delegate void myDelegate();

        myDelegate mydele;
        public static int current_value = 0;
        IList<Person> personList = new List<Person>();

        public void showValue()
        {
            my_textbox.AppendText("My Value is: " + current_value + "\r\n");
        }

        public void incrementValue()
        {
            my_textbox.AppendText("My Incremented Value is: " + ++current_value + "\r\n");
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            my_textbox.AppendText("Hello\r\n");

            mydele = new myDelegate(showValue);
            mydele += incrementValue;
        }

        private void mytimer_Tick(object sender, EventArgs e)
        {
            personList.Add(new Person(current_value));
            mydele.Invoke();
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            mytimer.Enabled = true;
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            mytimer.Enabled = false;

            var adults = personList.Where(s => s.Age > 18)
                .Select(s => s);
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = Security.CreateMD5(PasswordTextBox.Text);

            bool result = DBAccess.Instance.AddAccount(username, password);
            if (!result)
            {
                MessageBox.Show("Add Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Add Account", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void check_btn_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = Security.CreateMD5(PasswordTextBox.Text);

            bool result = DBAccess.Instance.CheckAccount(username, password);
            if (!result)
            {
                MessageBox.Show("Check Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Check Account", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
