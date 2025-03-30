using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using Guna.UI2.WinForms;
using iTextSharp.text.pdf;
using iTextSharp.text;


namespace GUI
{
    public partial class frm_User : Form
    {
        private BUS_FormUser bus_user = new BUS_FormUser();
        int dk = 0;

        public frm_User()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void styleGRD()
        {
            grd.DefaultCellStyle.Font = new System.Drawing.Font("Roboto", 11, FontStyle.Regular);
            grd.DefaultCellStyle.ForeColor = Color.Black;
            grd.DefaultCellStyle.BackColor = Color.White;

            /*Automatically resize the columns to fill all available space*/
            grd.Dock = DockStyle.Fill;
            grd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn col in grd.Columns)
            {
                col.MinimumWidth = 100;  
            }
        }

        public void initGRD()
        {
            grd.Rows.Clear();
            grd.Columns.Clear();
            grd.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn col_id = new DataGridViewTextBoxColumn();
            col_id.Name = "id_user";
            col_id.HeaderText = "ID User";
            col_id.DataPropertyName = "id_user";
            grd.Columns.Add(col_id);

            DataGridViewTextBoxColumn col_hoten = new DataGridViewTextBoxColumn();
            col_hoten.Name = "hoten";
            col_hoten.HeaderText = "Full Name";
            col_hoten.DataPropertyName = "hoten";
            grd.Columns.Add(col_hoten);

            DataGridViewTextBoxColumn col_username = new DataGridViewTextBoxColumn();
            col_username.Name = "username";
            col_username.HeaderText = "Username";
            col_username.DataPropertyName = "username";
            grd.Columns.Add(col_username);

            DataGridViewTextBoxColumn col_email = new DataGridViewTextBoxColumn();
            col_email.Name = "email";
            col_email.HeaderText = "Email";
            col_email.DataPropertyName = "email";
            grd.Columns.Add(col_email);

            DataGridViewColumn col_pass = new DataGridViewTextBoxColumn();
            col_pass.Name = "password";
            col_pass.HeaderText = "Password";
            col_pass.DataPropertyName = "password";
            col_pass.Visible = false;
            grd.Columns.Add(col_pass);

            loadUserData();
        }

        private void loadUserData()
        {
            List<DTO_FormUser> userList = bus_user.getUser();

            foreach (var user in userList)
            {
                user.password = "******";
            }

            grd.AutoGenerateColumns = false;
            grd.DataSource = userList;
        }
        public void enable(Guna2GroupBox grp, bool b)
        {
            foreach (Control ctrl in grp.Controls)
            {
                /*To exclude btn_Exit for being false*/
                if (ctrl != btn_Exit)
                {
                    ctrl.Enabled = b;
                }
            }
        }
        private void frm_User_Load(object sender, EventArgs e)
        {
            initGRD();
            styleGRD();
            enable(grp_user, false);
            btn_del.Enabled = false;
            btn_edit.Enabled = false;
            btn_save.Enabled = false;
            /*For convenience, this assists for selecting more than one row*/
            grd.MultiSelect = true;
            /*For convenience, this selects the row of the chosen cell.*/
            grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            enable(grp_user, true);
            txt_id.Text = bus_user.generateUserID();
            txt_username.Clear();
            txt_fullname.Clear();
            txt_email.Clear();
            txt_password.Clear();
            txt_username.Focus();
            btn_save.Enabled = true;
            dk = 1;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (dk == 1)
            {
                if (string.IsNullOrWhiteSpace(txt_username.Text) ||
                    string.IsNullOrWhiteSpace(txt_fullname.Text) ||
                    string.IsNullOrWhiteSpace(txt_email.Text))
                {
                    MessageBox.Show("Please fill in all the required fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DTO_FormUser newUser = new DTO_FormUser(
                    txt_id.Text,
                    txt_fullname.Text,
                    txt_username.Text,
                    txt_email.Text,
                    txt_password.Text
                );

                try
                {
                    bus_user.addUser(newUser);
                    MessageBox.Show("User added successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadUserData();
                    enable(grp_user, false);
                    btn_save.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dk == 2)
            {
                if (string.IsNullOrWhiteSpace(txt_username.Text) ||
                    string.IsNullOrWhiteSpace(txt_fullname.Text) ||
                    string.IsNullOrWhiteSpace(txt_email.Text))
                {
                    MessageBox.Show("Please fill in all the required fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DTO_FormUser updatedUser = new DTO_FormUser(
                    txt_id.Text,
                    txt_fullname.Text,
                    txt_username.Text,
                    txt_email.Text,
                    txt_password.Text
                );

                try
                {
                    bus_user.updateUser(updatedUser);
                    MessageBox.Show("User information updated successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadUserData();
                    enable(grp_user, false);
                    btn_save.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void grd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && grd.Columns.Contains("id_user"))
            {
                DataGridViewRow row = grd.Rows[e.RowIndex];

                txt_id.Text = row.Cells["id_user"].Value?.ToString();
                txt_fullname.Text = row.Cells["hoten"].Value?.ToString();
                txt_username.Text = row.Cells["username"].Value?.ToString();
                txt_email.Text = row.Cells["email"].Value?.ToString();

                txt_password.Text = (btn_edit.Enabled) ? "******" : "";

                enable(grp_user, true);
                btn_edit.Enabled = true;
                btn_del.Enabled = true;
                btn_save.Enabled = false;
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (grd.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to delete!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete the selected rows?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.No) return;

            List<string> userIDs = new List<string>();

            foreach (DataGridViewRow row in grd.SelectedRows)
            {
                if (row.Cells["id_user"].Value != null)
                {
                    userIDs.Add(row.Cells["id_user"].Value.ToString());
                }
            }

            if (userIDs.Count > 0)
            {
                try
                {
                    bus_user.delUser(userIDs);
                    MessageBox.Show("Successfully deleted!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadUserData(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (grd.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in grd.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    string userId = row.Cells["id_user"].Value.ToString();
                    string fullName = row.Cells["hoten"].Value.ToString();
                    string username = row.Cells["username"].Value.ToString();
                    string email = row.Cells["email"].Value.ToString();

                    txt_id.Text = userId;
                    txt_fullname.Text = fullName;
                    txt_username.Text = username;
                    txt_email.Text = email;
                    txt_password.Text = "******"; 

                    enable(grp_user, true);
                    btn_save.Enabled = true;
                    dk = 2;
                }
            }
        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {
            if (grd.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = "UserList.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document doc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();


                    iTextSharp.text.Font titleFont = FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 12);
                    Paragraph title = new Paragraph("User List", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);
                    doc.Add(new Paragraph("\n"));

                    PdfPTable table = new PdfPTable(grd.Columns.Count);
                    table.WidthPercentage = 100;

                    foreach (DataGridViewColumn column in grd.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        cell.BackgroundColor = new BaseColor(200, 200, 200); 
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);
                    }


                    foreach (DataGridViewRow row in grd.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                table.AddCell(new Phrase(cell.Value?.ToString() ?? ""));
                            }
                        }
                    }

                    doc.Add(table);
                    doc.Close();

                    MessageBox.Show("Exported to PDF successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting to PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
