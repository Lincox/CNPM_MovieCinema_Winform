using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BuSinessAccessLayer;

namespace RAPPHIM
{
    public partial class DangNhap : Form
    {
        public DataTable dta = null;
        BADangNhap dn = new BADangNhap();
        DataSet ds = new DataSet();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            ds = dn.LayTaiKhoan();
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            txtTaiKhoan.Text = dv.Table.Rows[0][0].ToString();
        }
       
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txt_MatKhau.Text.Trim() != "")
            {
              
               string a = txtTaiKhoan.Text;
               string b = dn.Layquyen1(a).Tables[0].Rows[0][0].ToString(); /// 
               if(b == "Admin")
                {
                    bool f = dn.KiemTraTaiKhoan(txtTaiKhoan.Text, txt_MatKhau.Text);
                    if (f)
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DangNhap.ActiveForm.Hide();
                        Home Form2 = new Home();
                        Form2.Text = txtTaiKhoan.Text;
                        Form2.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không đúng!\nHãy thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_MatKhau.ResetText();
                        txt_MatKhau.Focus();
                    }
                }
               else
                {
                    bool f = dn.KiemTraTaiKhoan(txtTaiKhoan.Text, txt_MatKhau.Text);
                    if (f)
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DangNhap.ActiveForm.Hide();
                        Home_NV Form2 = new Home_NV();
                        Form2.Text = txtTaiKhoan.Text;
                        Form2.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không đúng!\nHãy thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_MatKhau.ResetText();
                        txt_MatKhau.Focus();
                    }
                }
                
               
            }
            else
            {
                MessageBox.Show("Không được để trống mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MatKhau.Focus();
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
