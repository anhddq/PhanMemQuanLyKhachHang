using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKH.BUS;
using QLKH.Entities;

namespace QLKH.Modules
{
    public partial class ucKhachHang : UserControl
    {
        public ucKhachHang()
        {
            InitializeComponent();
        }

        private void ucKhachHang_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid(string t = "", string w = "", string o = "")
        {
            dgrCustomer.DataSource = KhachHangBUS.KhachHang_GetByTop(t, w, o);
            dgrCustomer.Columns["Alias"].Visible = false;
            dgrCustomer.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrCustomer.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrCustomer.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrCustomer.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrCustomer.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (w == "") Clear();
        }

        private void Clear()
        {
            txtAdress.Text = "";
            txtEmail.Text = "";
            txtID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtSearchEmail.Text = "";
            txtSearchName.Text = "";
            txtSearchPhone.Text = "";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void validatorCustomer_CustomValidatorValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Text == "DotNetBar")
                e.IsValid = true;
            else
                e.IsValid = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateCustomer.Validate())
            {
                KhachHang kh = new KhachHang(null, txtName.Text, txtAdress.Text, txtPhone.Text, txtEmail.Text);
                if (MessageBox.Show("Thêm mới khách hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (KhachHangBUS.KhachHang_Insert(kh))
                    {
                        MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    BindGrid("", "", " id desc");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (validateCustomer.Validate())
            {
                KhachHang kh = new KhachHang(txtID.Text, txtName.Text, txtAdress.Text, txtPhone.Text, txtEmail.Text);
                if (MessageBox.Show("Sửa thông tin khách hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (KhachHangBUS.KhachHang_Update(kh))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    BindGrid("", "", "");
                }
            }
        }

        private void sửaKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgrCustomer.SelectedRows[0];
            txtID.Text = r.Cells["ID"].Value.ToString();
            txtName.Text = r.Cells["Name"].Value.ToString();
            txtPhone.Text = r.Cells["Phone"].Value.ToString();
            txtEmail.Text = r.Cells["Email"].Value.ToString();
            txtAdress.Text = r.Cells["Address"].Value.ToString();
        }

        private void dgrCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgrCustomer.Rows[e.RowIndex];
            txtID.Text = r.Cells["ID"].Value.ToString();
            txtName.Text = r.Cells["Name"].Value.ToString();
            txtPhone.Text = r.Cells["Phone"].Value.ToString();
            txtEmail.Text = r.Cells["Email"].Value.ToString();
            txtAdress.Text = r.Cells["Address"].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void xóaKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Xóa tất cả bản ghi đã chọn?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int count = 0;
                foreach(DataGridViewRow r in dgrCustomer.SelectedRows)
                {
                    if (KhachHangBUS.KhachHang_Delete(r.Cells["ID"].Value.ToString()))
                    {
                        count++;
                    }
                }
                MessageBox.Show("Xóa thành công " + count + " bản ghi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            BindGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = Common.UnSignChar.ConvertToUnsign(txtSearchName.Text);
            string phone = txtSearchPhone.Text.Trim();
            string email = txtSearchEmail.Text.Trim().ToLower();
            string w = "Alias like '%" + name + "%' and phone like '%" + phone + "%' and email like '%" + email + "%'";
            BindGrid("", w, "");
        }
    }
}
