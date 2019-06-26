using System;
using System.Windows.Forms;

namespace LearnCSharp
{
    public partial class MainForm : Form
    {
        public delegate void myDelegate();

        public static int current_value = 0;
        myDelegate mydele;

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
            mydele.Invoke();
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            mytimer.Enabled = true;
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            mytimer.Enabled = false;
        }
    }
}
