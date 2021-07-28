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
    public partial class ucNhanVien : UserControl
    {
        public ucNhanVien()
        {
            InitializeComponent();
        }

        private void ucNhanVien_Load(object sender, EventArgs e)
        {
            BindCmbPosition();
            BindCmbSearchPosition();
            BindGrid();
        }
        private void BindGrid(string t = "", string w = "", string o = "")
        {
            dgrEmployee.DataSource = NhanVienBUS.NhanVien_GetByTop(t, w, o);
            dgrEmployee.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrEmployee.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrEmployee.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrEmployee.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrEmployee.Columns["TenChucVu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrEmployee.Columns["MaChucVu"].Visible = false;
            dgrEmployee.Columns["Alias"].Visible = false;
            if (w == "") Clear();
        }

        void Clear()
        {
            txtAdress.Text = "";
            cmbPosition.SelectedIndex = 0;
            cmbSearchPosition.SelectedIndex = 0;
            txtID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtSearchName.Text = "";
            txtSearchPhone.Text = "";
        }

        private void BindCmbPosition(string t = "", string w = "", string o = "")
        {
            List<ChucVu> lst = ChucVuBUS.ChucVu_GetByTop(t, w, o);
            lst.Insert(0, new ChucVu("0", "--Chọn một lựa chọn--"));
            cmbPosition.DataSource = lst;
            cmbPosition.ValueMember = "ID";
            cmbPosition.DisplayMember = "Name";
        }
        private void BindCmbSearchPosition(string t = "", string w = "", string o = "")
        {
            List<ChucVu> lst = ChucVuBUS.ChucVu_GetByTop(t, w, o);
            lst.Insert(0, new ChucVu("0", "--Tất cả--"));
            cmbSearchPosition.DataSource = lst;
            cmbSearchPosition.ValueMember = "ID";
            cmbSearchPosition.DisplayMember = "Name";
        }

        private void dgrEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgrEmployee.Rows[e.RowIndex];
            txtID.Text = r.Cells["ID"].Value.ToString();
            txtName.Text = r.Cells["Name"].Value.ToString();
            txtPhone.Text = r.Cells["Phone"].Value.ToString();
            cmbPosition.SelectedValue = r.Cells["MaChucVu"].Value.ToString();
            txtAdress.Text = r.Cells["Address"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateEmployee.Validate())
            {
                NhanVien kh = new NhanVien(null, txtName.Text, txtAdress.Text, txtPhone.Text, cmbPosition.SelectedValue.ToString());
                if (MessageBox.Show("Thêm mới nhân viên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (NhanVienBUS.NhanVien_Insert(kh))
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
            Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (validateEmployee.Validate())
            {
                NhanVien kh = new NhanVien(txtID.Text, txtName.Text, txtAdress.Text, txtPhone.Text, cmbPosition.SelectedValue.ToString());
                if (MessageBox.Show("Sửa nhân viên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (NhanVienBUS.NhanVien_Update(kh))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    BindGrid("", "", " id desc");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = Common.UnSignChar.ConvertToUnsign(txtSearchName.Text);
            string phone = txtSearchPhone.Text.Trim();
            string position = cmbSearchPosition.SelectedValue.ToString();
            string w = "";
            if (position == "0")
            {
                w = "Alias like '%" + name + "%' and phone like '%" + phone + "%'";
            }
            else
            {
                w = "Alias like '%" + name + "%' and phone like '%" + phone + "%' and MaChucVu = '" + position + "'";
            }

            BindGrid("", w, "");
        }

        private void sửaKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgrEmployee.SelectedRows[0];
            txtID.Text = r.Cells["ID"].Value.ToString();
            txtName.Text = r.Cells["Name"].Value.ToString();
            txtPhone.Text = r.Cells["Phone"].Value.ToString();
            cmbPosition.SelectedValue = r.Cells["MaChucVu"].Value.ToString();
            txtAdress.Text = r.Cells["Address"].Value.ToString();
        }

        private void xóaKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa tất cả bản ghi đã chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int count = 0;
                foreach (DataGridViewRow r in dgrEmployee.SelectedRows)
                {
                    if (NhanVienBUS.NhanVien_Delete(r.Cells["ID"].Value.ToString()))
                    {
                        count++;
                    }
                }
                MessageBox.Show("Xóa thành công " + count + " bản ghi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            BindGrid();
        }
    }
}
