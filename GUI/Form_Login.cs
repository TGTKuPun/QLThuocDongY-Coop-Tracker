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
            string username = txt_username.Text.Trim();
            string password = txt_password.Text.Trim();

            BUS_FormLogin bus_FormLogin = new BUS_FormLogin();

            // Nhận kết quả từ phương thức checkLogin
            DTO_FormLogin user = bus_FormLogin.checkLogin(username, password, out bool isAdmin);

            if (user != null) // Nếu đăng nhập thành công
            {
                if (isAdmin)
                {
                    MessageBox.Show($"Hello Admin !", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Menu menu = new Menu();
                    menu.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Hello User !", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
