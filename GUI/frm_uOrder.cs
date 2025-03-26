using DTO;
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
    public partial class frm_uOrder : Form
    {
        private string user_id;
        private string username;
        private string password;
        public frm_uOrder(string ID, string Username, string Password)
        {
            InitializeComponent();
            user_id = ID;
            username = Username;
            password = Password;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void User_Order_Load(object sender, EventArgs e)
        {
            txt_userid.Text = "User ID: " + user_id;
        }

        private void label_signout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure want to sign out?",
                "Confirm Sign Out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Hide();
                frm_Login loginForm = new frm_Login(username, password);
                loginForm.ShowDialog();
            }
        }
    }
}
