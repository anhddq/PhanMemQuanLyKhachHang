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
    public partial class ucPhieuHen : UserControl
    {
        string IDNhanVien;
        public ucPhieuHen(string _IDNhanVien)
        {
            IDNhanVien = _IDNhanVien;
            InitializeComponent();
        }

        private void ucPhieuHen_Load(object sender, EventArgs e)
        {
            BindCmbEmployee();
            BindCmbRequest();
            BindGrid();
            cmbPrioriti.SelectedIndex = 0;
        }

        private void BindCmbEmployee(string t = "", string w = "", string o = "")
        {
            List<NhanVien> lst = NhanVienBUS.NhanVien_GetByTop(t, w, o);
            lst.Insert(0, new NhanVien("0", "--Chọn một lựa chọn--", null, null, null));
            cmbEmployee.DataSource = lst;
            cmbEmployee.ValueMember = "ID";
            cmbEmployee.DisplayMember = "Name";
        }

        private void BindCmbRequest(string t = "", string w = "", string o = "")
        {
            List<PhieuYeuCau> lst = PhieuYeuCauBUS.PhieuYeuCau_GetByTop(t, w, o);
            lst.Insert(0, new PhieuYeuCau("0", null, "--Chọn một lựa chọn--", null, null));
            cmbRequest.DataSource = lst;
            cmbRequest.ValueMember = "MaPhieuYC";
            cmbRequest.DisplayMember = "YeuCau";
        }

        private void BindGrid(string t = "", string w = "", string o = "")
        {
            dgrView.DataSource = PhieuHenBUS.PhieuHen_GetByTop(t, w, o);
            dgrView.Columns["MaNV"].Visible = false;
            dgrView.Columns["MaPhieuYC"].Visible = false;
            dgrView.Columns["Alias"].Visible = false;
            dgrView.Columns["MaPhieuHen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["YeuCau"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["PAGiaiQUyet"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["ThoiGianHen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["DoUuTien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["TinhTrang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["TenNhanVien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["TenKhachHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (w == "") Clear();
        }
        void Clear()
        {
            txtID.Text = "";
            txtPlan.Text = "";
            txtSearchName.Text = "";
            dtAttentTime.Value = DateTime.Today;
            dtStart.Value = DateTime.MinValue;
            dtEnd.Value = DateTime.MaxValue;
            cmbPrioriti.SelectedIndex = 0;
            cmbEmployee.SelectedValue = IDNhanVien;
            cmbRequest.SelectedIndex = 0;
            ckSolve.Checked = false;

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

        private void dgrView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgrView.Rows[e.RowIndex];
            txtID.Text = r.Cells["MaPhieuYC"].Value.ToString();
            txtPlan.Text = r.Cells["PAGiaiQuyet"].Value.ToString();
            dtAttentTime.Value = DateTime.Parse(r.Cells["ThoiGianHen"].Value.ToString());
            cmbPrioriti.SelectedValue = r.Cells["DoUuTien"].Value.ToString();
            cmbEmployee.SelectedValue = r.Cells["MaNV"].Value.ToString();
            cmbRequest.SelectedValue = r.Cells["MaPhieuYC"].Value.ToString();
            if (r.Cells["TinhTrang"].Value.ToString().Equals("True"))
            {
                ckSolve.Checked = true;
            }
            else ckSolve.Checked = false;
        }

        private void menuEditEmployee_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgrView.SelectedRows[0];
            txtID.Text = r.Cells["MaPhieuYC"].Value.ToString();
            txtPlan.Text = r.Cells["PAGiaiQuyet"].Value.ToString();
            dtAttentTime.Value = DateTime.Parse(r.Cells["ThoiGianHen"].Value.ToString());
            cmbPrioriti.SelectedValue = r.Cells["DoUuTien"].Value.ToString();
            cmbEmployee.SelectedValue = r.Cells["MaNV"].Value.ToString();
            cmbRequest.SelectedValue = r.Cells["MaPhieuYC"].Value.ToString();
            if (r.Cells["TinhTrang"].Value.ToString().Equals("True"))
            {
                ckSolve.Checked = true;
            }
            else ckSolve.Checked = false;
        }

        private void menuDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa tất cả bản ghi đã chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int count = 0;
                foreach (DataGridViewRow r in dgrView.SelectedRows)
                {
                    if (PhieuHenBUS.PhieuHen_Delete(r.Cells["MaPhieuHen"].Value.ToString()))
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
                PhieuHen kh = new PhieuHen(null,cmbRequest.SelectedValue.ToString(),txtPlan.Text,dtAttentTime.Value.ToString(),cmbPrioriti.SelectedText.ToString(),(ckSolve.Checked ? "true" : "false"),cmbEmployee.SelectedValue.ToString());
                if (MessageBox.Show("Thêm mới phiếu hẹn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (PhieuHenBUS.PhieuHen_Insert(kh))
                    {
                        MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    BindGrid("", "", " MaPhieuHen desc");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                PhieuHen kh = new PhieuHen(txtID.Text, cmbRequest.SelectedValue.ToString(), txtPlan.Text, dtAttentTime.Value.ToString(), cmbPrioriti.SelectedText.ToString(), (ckSolve.Checked ? "true" : "false"), cmbEmployee.SelectedValue.ToString());
                if (MessageBox.Show("Sửa phiếu hẹn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (PhieuHenBUS.PhieuHen_Update(kh))
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = Common.UnSignChar.ConvertToUnsign(txtSearchName.Text);
            string start = dtStart.Value.ToString();
            string end = dtEnd.Value.ToString();
            string w = "Alias like '%" + name + "%' and ThoiGianHen >= '" + start + "' and ThoiGianHen <= '" + end + "'";
            BindGrid("", w, "");
        }
    }
}
