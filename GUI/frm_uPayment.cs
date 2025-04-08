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
    public partial class frm_uPayment : Form
    {   
        private string user_id;
        private string price;
        private string quantity;
        private string total_price;
        private string pname;
        private string date;
        public frm_uPayment(string user_id, string price, string quantity, string total_price, string pname, string orderDate)
        {
            InitializeComponent();
            this.user_id = user_id;
            this.price = price;
            this.quantity = quantity;
            this.total_price = total_price;
            this.pname = pname;
            this.date = orderDate;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
            Application.Exit();
        }

        private void frm_uPayment_Load(object sender, EventArgs e)
        {
            lb_id.Text = "UID: " + user_id;
            lb_pname.Text = pname;
            lb_price.Text = $"{price:N0} VND";
            lb_quantity.Text = quantity;
            lb_totalPrice.Text = total_price;
            lb_dateOrder.Text = date;
        }
    }
}
