using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI
{
    public partial class frm_Menu : Form
    {
        string username;
        string password;
        public frm_Menu(string Username, string Password)
        {
            InitializeComponent();
            this.username = Username;
            this.password = Password;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void img_User_Click(object sender, EventArgs e)
        {
            frm_User menu_user = new frm_User();
            this.Hide();
            menu_user.ShowDialog();
        }

        private void img_Product_Click(object sender, EventArgs e)
        {
            frm_Product menu_product = new frm_Product();
            this.Hide();
            menu_product.ShowDialog();
        }

        private void img_Order_Click(object sender, EventArgs e)
        {
            frm_Order menu_order = new frm_Order();
            this.Hide();
            menu_order.ShowDialog();
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
