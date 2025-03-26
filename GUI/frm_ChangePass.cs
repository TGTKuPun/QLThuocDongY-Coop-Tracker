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
    public partial class frm_ChangePass : Form
    {
        private frm_Login LoginForm;
        public frm_ChangePass(frm_Login form_Login)
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
            string old_password = txt_old_password.Text.Trim();
            string new_password = txt_new_password.Text.Trim();

            BUS_FormChangePass bus_formChangePass = new BUS_FormChangePass();

            DTO_FormChangePass dt_user = bus_formChangePass.checkEmail(email, old_password, new_password, out bool Identity);

            if (dt_user != null && Identity)
            {   
                if (new_password != dt_user.Password)
                {
                    bus_formChangePass.changePassword(email, new_password);
                    MessageBox.Show("Password changed successfully", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoginForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("New password must be different from the old one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Email does not exist or wrong passworld", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exit_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
