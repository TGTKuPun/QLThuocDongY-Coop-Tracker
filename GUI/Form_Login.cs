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
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            Form_ChangePassword form = new Form_ChangePassword(this);
            this.Hide();
            form.ShowDialog();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();
            txt_username.FocusedState.BorderColor = Color.Silver;
            txt_password.FocusedState.BorderColor = Color.Silver;
            txt_username.Focus();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text.Trim();
            string password = txt_password.Text.Trim();

            BUS_FormLogin bus_FormLogin = new BUS_FormLogin();

            if (bus_FormLogin.checkLogin(username, password, out bool isAdmin))
            {
                if (isAdmin)
                {
                    MessageBox.Show("Hello Admin!", "Annoucement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Chuyển sang giao diện Admin
                    this.Hide();
                    Menu menu = new Menu();
                    menu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Hello User!", "Annoucement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Chuyển sang giao diện User
                    this.Hide();
                    User_Order user_Order = new User_Order();
                    user_Order.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
