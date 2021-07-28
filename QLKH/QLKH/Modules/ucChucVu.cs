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
    public partial class ucChucVu : UserControl
    {
        public ucChucVu()
        {
            InitializeComponent();
        }

        void Clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtSearchName.Text = "";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void ucChucVu_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid(string t = "",string w = "",string o = "")
        {
            dgrView.DataSource = ChucVuBUS.ChucVu_GetByTop(t, w, o);
            dgrView.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrView.Columns["Alias"].Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string w = "Alias like '%" + Common.UnSignChar.ConvertToUnsign(txtSearchName.Text) + "%'";
            BindGrid("", w, "");
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
            txtID.Text = r.Cells["ID"].Value.ToString();
            txtName.Text = r.Cells["Name"].Value.ToString();
        }

        private void menuEditEmployee_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgrView.SelectedRows[0];
            txtID.Text = r.Cells["ID"].Value.ToString();
            txtName.Text = r.Cells["Name"].Value.ToString();
        }

        private void menuDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa tất cả bản ghi đã chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int count = 0;
                foreach (DataGridViewRow r in dgrView.SelectedRows)
                {
                    if (ChucVuBUS.ChucVu_Delete(r.Cells["ID"].Value.ToString()))
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
                ChucVu kh = new ChucVu(null, txtName.Text);
                if (MessageBox.Show("Thêm mới chức vụ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (ChucVuBUS.ChucVu_Insert(kh))
                    {
                        MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    BindGrid("", "", " ID desc");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                ChucVu kh = new ChucVu(txtID.Text, txtName.Text);
                if (MessageBox.Show("Sửa chức vụ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (ChucVuBUS.ChucVu_Update(kh))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("TSửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    BindGrid("", "", "");
                }
            }
        }
    }
}
