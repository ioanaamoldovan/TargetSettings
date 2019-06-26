using System;
using System.Windows.Forms;

namespace LearnCSharp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            my_textbox.AppendText("Hello\r\n");
        }

        private void mytimer_Tick(object sender, EventArgs e)
        {
            my_textbox.AppendText("New line\r\n");
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
