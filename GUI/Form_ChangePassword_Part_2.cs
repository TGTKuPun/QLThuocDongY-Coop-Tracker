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
    public partial class Form_ChangePassword_Part_2 : Form
    {
        private Form_ChangePassword ChangeForm;
        public Form_ChangePassword_Part_2(Form_ChangePassword form_ChangePasssword)
        {
            InitializeComponent();
            this.ChangeForm = form_ChangePasssword;
        }

        private void btn_GoBack_Click(object sender, EventArgs e)
        {
            ChangeForm.Show();
            this.Close();
        }
    }
}
