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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void img_User_Click(object sender, EventArgs e)
        {
            Menu_User menu_user = new Menu_User();
            this.Hide();
            menu_user.ShowDialog();
        }

        private void img_Product_Click(object sender, EventArgs e)
        {
            Menu_Product menu_product = new Menu_Product();
            this.Hide();
            menu_product.ShowDialog();
        }

        private void img_Order_Click(object sender, EventArgs e)
        {
            Menu_Order menu_order = new Menu_Order();
            this.Hide();
            menu_order.ShowDialog();
        }
    }
}
