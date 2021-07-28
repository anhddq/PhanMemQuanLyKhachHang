using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKH.Entities;
using QLKH.BUS;

namespace QLKH.Modules
{
    public partial class ucPhieuYeuCau : UserControl
    {
        string IDNhanVien;
        public ucPhieuYeuCau(string _IDNhanVien)
        {
            IDNhanVien = _IDNhanVien;
            InitializeComponent();
        }

        private void ucPhieuYeuCau_Load(object sender, EventArgs e)
        {
            BindCmbCustomer();
            BindCmbEmployee();
            BindGrid();
        }

        private void BindGrid(string t = "", string w = "", string o = "")
        {
            dgrView.DataSource = PhieuYeuCauBUS.PhieuYeuCau_GetByTop(t, w, o);
            dgrView.Columns["MaPhieuYC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["TenKhachHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["YeuCau"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["TGNhan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["TenNhanVien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["MaNhanVien"].Visible = false;
            dgrView.Columns["MaKhachHang"].Visible = false;
            dgrView.Columns["Alias"].Visible = false;
            if (w == "") Clear();
        }

        private void BindCmbEmployee(string t = "", string w = "", string o = "")
        {
            List<NhanVien> lst = NhanVienBUS.NhanVien_GetByTop(t, w, o);
            lst.Insert(0, new NhanVien("0", "--Chọn một lựa chọn--", null, null, null));
            cmbEmployee.DataSource = lst;
            cmbEmployee.ValueMember = "ID";
            cmbEmployee.DisplayMember = "Name";
        }

        private void BindCmbCustomer(string t = "", string w = "", string o = "")
        {
            List<KhachHang> lst = KhachHangBUS.KhachHang_GetByTop(t, w, o);
            lst.Insert(0, new KhachHang("0","--Chọn một lựa chọn--",null,null,null));
            cmbCustomer.DataSource = lst;
            cmbCustomer.ValueMember = "ID";
            cmbCustomer.DisplayMember = "Name";
        }

        void Clear()
        {
            txtID.Text = "";
            txtRequest.Text = "";
            txtSearchName.Text = "";
            cmbCustomer.SelectedIndex = 0;
            cmbEmployee.SelectedValue = IDNhanVien;
            dtCreateDate.Value = DateTime.Now;
            dtStart.Value = DateTime.MinValue;
            dtEnd.Value = DateTime.MaxValue;
        }

        private void dgrView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgrView.Rows[e.RowIndex];
            txtID.Text = r.Cells["MaPhieuYC"].Value.ToString();
            txtRequest.Text = r.Cells["YeuCau"].Value.ToString();
            dtCreateDate.Value = DateTime.Parse(r.Cells["TGNhan"].Value.ToString());
            cmbCustomer.SelectedValue = r.Cells["MaKhachHang"].Value.ToString();
            cmbEmployee.SelectedValue = r.Cells["MaNhanVien"].Value.ToString();
        }

        private void menuEditEmployee_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgrView.SelectedRows[0];
            txtID.Text = r.Cells["MaPhieuYC"].Value.ToString();
            txtRequest.Text = r.Cells["YeuCau"].Value.ToString();
            dtCreateDate.Value = DateTime.Parse(r.Cells["TGNhan"].Value.ToString());
            cmbCustomer.SelectedValue = r.Cells["MaKhachHang"].Value.ToString();
            cmbEmployee.SelectedValue = r.Cells["MaNhanVien"].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
            BindGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                PhieuYeuCau kh = new PhieuYeuCau(null, cmbCustomer.SelectedValue.ToString(), txtRequest.Text, DateTime.Now.ToString(), cmbEmployee.SelectedValue.ToString());
                if (MessageBox.Show("Thêm mới nhân viên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (PhieuYeuCauBUS.PhieuYeuCau_Insert(kh))
                    {
                        MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    BindGrid("", "", " MaPhieuYC desc");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                PhieuYeuCau kh = new PhieuYeuCau(txtID.Text, cmbCustomer.SelectedValue.ToString(), txtRequest.Text, dtCreateDate.Value.ToString(), cmbEmployee.SelectedValue.ToString());
                if (MessageBox.Show("Sửa yêu cầu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (PhieuYeuCauBUS.PhieuYeuCau_Update(kh))
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

        private void menuDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa tất cả bản ghi đã chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int count = 0;
                foreach (DataGridViewRow r in dgrView.SelectedRows)
                {
                    if (PhieuYeuCauBUS.PhieuYeuCau_Delete(r.Cells["MaPhieuYC"].Value.ToString()))
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
            string start = dtStart.Value.ToString();
            string end = dtEnd.Value.ToString();
            string w = "Alias like '%" + name + "%' and TGNhan >= '" +start+"' and TGNhan <= '"+end+"'";
            BindGrid("", w, "");
        }
    }
}
