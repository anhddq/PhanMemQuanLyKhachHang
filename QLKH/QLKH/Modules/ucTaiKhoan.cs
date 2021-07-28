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
    public partial class ucTaiKhoan : UserControl
    {
        public ucTaiKhoan()
        {
            InitializeComponent();
        }

        private void ucTaiKhoan_Load(object sender, EventArgs e)
        {
            BindCmbEmployee();
            BindGrid();
        }
        private void BindCmbEmployee(string t = "", string w = "", string o = "")
        {
            List<NhanVien> lst = NhanVienBUS.NhanVien_GetByTop(t, w, o);
            lst.Insert(0, new NhanVien("0", "--Chọn một lựa chọn--", null, null, null));
            cmbEmployee.DataSource = lst;
            cmbEmployee.ValueMember = "ID";
            cmbEmployee.DisplayMember = "Name";
        }
        private void BindGrid(string t="",string w="",string o = "")
        {
            dgrView.DataSource = TaiKhoanBUS.TaiKhoan_GetByTop(t, w, o);
            dgrView.Columns["IDNhanVien"].Visible = false;
            dgrView.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["Password"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["TenNhanVien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["Quyen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["Alias"].Visible = false;
            if (w == "") Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid("", "Username like '%" + txtSearchUsername.Text + "%' and Alias like '%" + Common.UnSignChar.ConvertToUnsign(txtSearchName.Text) + "%'", "");
        }

        private void dgrView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgrView.Rows[e.RowIndex];
            txtUsername.Text = r.Cells["Username"].Value.ToString();
            cmbEmployee.SelectedValue = r.Cells["IDNhanVien"].Value.ToString();
            txtPosition.Text = r.Cells["Quyen"].Value.ToString();
        }

        private void menuEditEmployee_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgrView.SelectedRows[0];
            txtUsername.Text = r.Cells["Username"].Value.ToString();
            cmbEmployee.SelectedValue = DateTime.Parse(r.Cells["IDNhanVien"].Value.ToString());
            txtPosition.Text = r.Cells["Quyen"].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtPassword.Text = "";
            txtSearchName.Text = "";
            txtUsername.Text = "";
            txtPosition.Text = "";
            cmbEmployee.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void menuDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa tất cả bản ghi đã chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int count = 0;
                foreach (DataGridViewRow r in dgrView.SelectedRows)
                {
                    if (TaiKhoanBUS.TaiKhoan_Delete(r.Cells["Username"].Value.ToString()))
                    {
                        count++;
                    }
                }
                MessageBox.Show("Xóa thành công " + count + " bản ghi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            BindGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if(txtPassword.Text == "" || txtPassword.Text != txtRePassword.Text)
                {
                    MessageBox.Show("Bạn cần tạo mật khẩu");
                    return;
                }
                TaiKhoan kh = new TaiKhoan(txtUsername.Text, Common.Encryptor.MD5Hash(txtPassword.Text), txtPosition.Text);
                kh.IDNhanVien = cmbEmployee.SelectedValue.ToString();
                if (MessageBox.Show("Thêm mới tài khoản?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (TaiKhoanBUS.TaiKhoan_Insert(kh))
                    {
                        MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    BindGrid("", "", "");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                string pass = null;
                if(txtPassword.Text != "")
                {
                    pass = Common.Encryptor.MD5Hash(txtPassword.Text);
                }
                TaiKhoan kh = new TaiKhoan(txtUsername.Text, pass , txtPosition.Text);
                kh.IDNhanVien = cmbEmployee.SelectedValue.ToString();
                if (MessageBox.Show("Sửa tài khoản?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (TaiKhoanBUS.TaiKhoan_Update(kh))
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
    }
}
