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
using System.IO;
using Config;


namespace GUI
{
    public partial class frm_Login : Form
    {
        public frm_Login(string Username, string Password)
        {
            InitializeComponent();
            txt_username.Text = Username;
            txt_password.Text = Password;

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            frm_ChangePass form = new frm_ChangePass(this);
            this.Hide();
            form.ShowDialog();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {   
            /*Reset content state*/
            txt_username.Clear();
            txt_password.Clear();
            /*Adjust the border's color*/
            txt_username.FocusedState.BorderColor = Color.Silver;
            txt_password.FocusedState.BorderColor = Color.Silver;
            txt_username.Focus();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Config_Settings.Server) || string.IsNullOrEmpty(Config_Settings.Database))
            {
                MessageBox.Show("Config is missing! Please configure the system first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = txt_username.Text.Trim();
            string password = txt_password.Text.Trim();

            BUS_FormLogin bus_FormLogin = new BUS_FormLogin();

            // Return object userInfo and check whether the user is admin or not
            DTO_FormLogin user = bus_FormLogin.checkLogin(username, password, out bool isAdmin);

            if (user != null) // Nếu đăng nhập thành công
            {
                if (isAdmin)
                {
                    MessageBox.Show($"Hello Admin !", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frm_Menu menu = new frm_Menu(username, password);
                    menu.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Hello User !", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frm_uOrder user_Order = new frm_uOrder(user.UserID, username, password);
                    user_Order.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exit_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
