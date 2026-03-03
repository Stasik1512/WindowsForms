using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            LabelTime.Text = DateTime.Now.ToString("HH:mm:ss");
            if (cbShowDate.Checked) LabelTime.Text += $"\n{DateTime.Now.ToString("yyyy.MM.dd")}";
            if (cbShowWeekday.Checked) LabelTime.Text += $"\n{DateTime.Now.DayOfWeek}";


        }

        private void btnHideControls_Click(object sender, EventArgs e)
        {
            cbShowDate.Visible = false;
            cbShowWeekday.Visible = false;
            btnHideControls.Visible = false;
            ShowInTaskbar = false;
        }
    }
}
