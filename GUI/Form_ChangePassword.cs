using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI
{
    public partial class Form_ChangePassword : Form
    {
        private Form_Login LoginForm;
        public Form_ChangePassword(Form_Login form_Login)
        {
            InitializeComponent();
            this.LoginForm = form_Login;
        }

        private void btn_GoBack_Click(object sender, EventArgs e)
        {
            LoginForm.Show();
            this.Close();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_ChangePass_Click(object sender, EventArgs e)
        {
            string email = txt_email.Text.Trim();
            string new_password = txt_new_password.Text.Trim();

            BUS_FormChangePass bus_formChangePass = new BUS_FormChangePass();

            DTO_FormChangePass dt_user = bus_formChangePass.checkEmail(email);

            if (dt_user != null)
            {   
                bus_formChangePass.changePassword(email, new_password);
                MessageBox.Show("Password changed successfully", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                LoginForm.Show();
            }
            else
            {
                MessageBox.Show("Email does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
