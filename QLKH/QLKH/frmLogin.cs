using QLKH.BUS;
using QLKH.Entities;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(superValidator1.Validate())
            {
                List<TaiKhoan> lst = TaiKhoanBUS.TaiKhoan_GetByTop("", "Username = '" + txtUsername.Text + "' and Password = '" + Common.Encryptor.MD5Hash(txtPassword.Text) + "'", "");
                if (lst.Count > 0)
                {
                    this.Hide();
                    new frmMain(lst.ElementAt(0).IDNhanVien).Show();
                }
                else
                {
                    lbMessage.Text = "Sai tên đăng nhập hoặc mật khẩu";
                    lbMessage.Visible = true;
                }
            }
            else {

            }
        }
    }
}
