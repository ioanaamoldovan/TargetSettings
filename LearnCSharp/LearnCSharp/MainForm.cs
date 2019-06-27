using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
    }
}
