using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordPadWF
{
    public partial class DateAndTimeForm : Form
    {
        public DateAndTimeForm()
        {
            InitializeComponent();
        }
        private Form1 mainForm = null;
        public DateAndTimeForm(Form1 form1)
        {
            mainForm = form1 as Form1;
            InitializeComponent();
            guna2RadioButton1.Text = DateTime.Now.ToLongDateString();
            guna2RadioButton2.Text = DateTime.Now.ToShortDateString();
            guna2RadioButton3.Text = DateTime.Now.ToLongTimeString();
            guna2RadioButton4.Text = DateTime.Now.ToShortTimeString();
        }

        private void BtnCancel_Click(object sender, EventArgs e) => this.Hide();

        private void BtnOk_Click(object sender, EventArgs e)
        {
            var rb = Controls.OfType<Guna.UI2.WinForms.Guna2RadioButton>().ToList().Find(r => r.Checked == true);
            mainForm.richTextBox1.Text += rb.Text;
            this.Hide();
        }
    }
}
