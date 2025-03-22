using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_ChangePassword : Form
    {
        private Form_Login loginForm;
        public Form_ChangePassword(Form_Login form_Login)
        {
            InitializeComponent();
            this.loginForm = form_Login;
        }

        private void btn_BackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loginForm.Show();
            this.Close();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            Form_ChangePassword_Part_2 form = new Form_ChangePassword_Part_2(this);
            this.Hide();
            form.ShowDialog();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
