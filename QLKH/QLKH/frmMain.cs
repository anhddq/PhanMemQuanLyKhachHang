using QLKH.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKH
{
    public partial class frmMain : Form
    {
        string IDNhanVien;
        public frmMain(string _idNhanVien)
        {
            IDNhanVien = _idNhanVien;
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ucIntro uc = new ucIntro();
            uc.Dock = DockStyle.Fill;
            gpView.Controls.Clear();
            gpView.Controls.Add(uc);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ucKhachHang uc = new ucKhachHang();
            uc.Dock = DockStyle.Fill;
            gpView.Controls.Clear();
            gpView.Controls.Add(uc);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            ucNhanVien uc = new ucNhanVien();
            uc.Dock = DockStyle.Fill;
            gpView.Controls.Clear();
            gpView.Controls.Add(uc);
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            ucPhieuYeuCau uc = new ucPhieuYeuCau(IDNhanVien);
            uc.Dock = DockStyle.Fill;
            gpView.Controls.Clear();
            gpView.Controls.Add(uc);
        }

        private void btnAttent_Click(object sender, EventArgs e)
        {
            ucPhieuHen uc = new ucPhieuHen(IDNhanVien);
            uc.Dock = DockStyle.Fill;
            gpView.Controls.Clear();
            gpView.Controls.Add(uc);
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            ucChucVu uc = new ucChucVu();
            uc.Dock = DockStyle.Fill;
            gpView.Controls.Clear();
            gpView.Controls.Add(uc);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            ucTaiKhoan uc = new ucTaiKhoan();
            uc.Dock = DockStyle.Fill;
            gpView.Controls.Clear();
            gpView.Controls.Add(uc);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Đóng ứng dụng?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            Application.Exit();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            ucIntro uc = new ucIntro();
            uc.Dock = DockStyle.Fill;
            gpView.Controls.Clear();
            gpView.Controls.Add(uc);
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmLogin().Show();
            
        }
    }
}
