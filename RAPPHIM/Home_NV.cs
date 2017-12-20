using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BuSinessAccessLayer;
using System.Data.SqlClient;
using System.IO;


namespace RAPPHIM
{
    public partial class Home_NV : Form
    {
        public DataTable dtMDH2 = null;
        public string soghe;

        bool f;

        BALichChieu lc = new BALichChieu();
        BAPhim p = new BAPhim();
        BAPhongChieu pc = new BAPhongChieu();
        BADichVu dvu = new BADichVu();
        BAHoaDonDichVu hddv = new BAHoaDonDichVu();
        BANhanVien nv = new BANhanVien();
        BAVeBan vb = new BAVeBan();
        DataSet ds = new DataSet();
        BALoaiVe lv = new BALoaiVe();

        public Home_NV()
        {
            InitializeComponent();
            Load_HoaDonDichVu();
            Load_LichChieu();
            loadTrangChu();
        }

        //============================================* PHAN DAT VE *========================================================//

        //============================================* PHAN DAT VE *=======================================================//

        private void B_Click(object sender, EventArgs e)
        {
            soghe = ((Button)sender).Name;

            //
            if (((Button)sender).BackColor == Color.White)
            {
               // btn_xacnhan.Enabled = true;
                changeColor(soghe);

            }
            else
            {
               // btn_xacnhan.Enabled = false;
            }

            txt_ghe1.Text = ((Button)sender).Text + "" + txt_ghe1.Text;
            //txtGhe.Text = (button)sender).text +","+ txtGhe.Text
        }

        private void Home_NV_Load(object sender, EventArgs e)
        {
            LoadData_Ve();
            LoadDichVu();
        }
        public void LoadData_Ve()
        {
            // A1.Enabled = false;
            DataView dv = new DataView();
            ds = vb.LayVeBan();
            //dgv_hoadon.DataSource = ds.Tables[0];
            // Load ma lich chieu
            ds = lc.LayLichChieu();
            DataView d = new DataView();
            d.Table = ds.Tables[0];
            for (int i = 0; i < d.Count; i++)
            {
                cbx_lichchieu1.Items.Add(d.Table.Rows[i][1]);

            }
            cbx_lichchieu1.SelectedIndex = 0;
            ////load combox cho nhan vien
            ds = nv.LayNhanVien();
            DataView dvv = new DataView();
            //string donGia = "";
            dvv.Table = ds.Tables[0];
            for (int i = 0; i < dvv.Count; i++)
            {
                cbx_nhanvien1.Items.Add(dvv.Table.Rows[i][0]);
            }
            cbx_nhanvien1.SelectedIndex = 0;


            ////load loai ve
            ds = lv.LayLoaiVe();
            DataView dvvv = new DataView();
            //string donGia = "";
            dvvv.Table = ds.Tables[0];
            for (int i = 0; i < dvvv.Count; i++)
            {
                cbx_maloaive1.Items.Add(dvvv.Table.Rows[i][1]);
            }
            cbx_maloaive1.SelectedIndex = 0;


        }
        //private void cbx_lichchieu1_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    txt_malichchieu1.Text = vb.lichchieu(cbx_lichchieu1.Text).Tables[0].Rows[0][0].ToString();

        //}
        public void LoadGhe()
        {
           // this.pa_chonghe.BackColor = Color.Transparent;
            string mb;
            string ml;
            dtMDH2 = new DataTable();

            mb = A3.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                A3.BackColor = Color.Green;
            }
            else
            {
                A3.BackColor = Color.White;
            }

            mb = A4.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                A4.BackColor = Color.Green;
            }
            else
            {
                A4.BackColor = Color.White;
            }

            mb = A5.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                A5.BackColor = Color.Green;
            }
            else
            {
                A5.BackColor = Color.White;
            }

            mb = A6.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                A6.BackColor = Color.Green;
            }
            else
            {
                A6.BackColor = Color.White;
            }

            mb = A7.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                A7.BackColor = Color.Green;
            }
            else
            {
                A7.BackColor = Color.White;
            }

        
            mb = B3.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                B3.BackColor = Color.Green;
            }
            else
            {
                B3.BackColor = Color.White;
            }

            mb = B4.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                B4.BackColor = Color.Green;
            }
            else
            {
                B4.BackColor = Color.White;
            }

            mb = B5.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                B5.BackColor = Color.Green;
            }
            else
            {
                B5.BackColor = Color.White;
            }

            mb = B6.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                B6.BackColor = Color.Green;
            }
            else
            {
                B6.BackColor = Color.White;
            }

            mb = B7.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                B7.BackColor = Color.Green;
            }
            else
            {
                B7.BackColor = Color.White;
            }

           
            mb = C3.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                C3.BackColor = Color.Green;
            }
            else
            {
                C3.BackColor = Color.White;
            }

            mb = C4.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                C4.BackColor = Color.Green;
            }
            else
            {
                C4.BackColor = Color.White;
            }

            mb = C5.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                C5.BackColor = Color.Green;
            }
            else
            {
                C5.BackColor = Color.White;
            }

            mb = C6.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                C6.BackColor = Color.Green;
            }
            else
            {
                C6.BackColor = Color.White;
            }

            mb = C7.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                C7.BackColor = Color.Green;
            }
            else
            {
                C7.BackColor = Color.White;
            }

            mb = D3.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                D3.BackColor = Color.Green;
            }
            else
            {
                D3.BackColor = Color.White;
            }

            mb = D4.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                D4.BackColor = Color.Green;
            }
            else
            {
                D4.BackColor = Color.White;
            }

            mb = D5.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                D5.BackColor = Color.Green;
            }
            else
            {
                D5.BackColor = Color.White;
            }

            mb = D6.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                D6.BackColor = Color.Green;
            }
            else
            {
                D6.BackColor = Color.White;
            }

            mb = D7.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                D7.BackColor = Color.Green;
            }
            else
            {
                D7.BackColor = Color.White;
            }


            mb = E3.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                E3.BackColor = Color.Green;
            }
            else
            {
                E3.BackColor = Color.White;
            }

            mb = E4.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                E4.BackColor = Color.Green;
            }
            else
            {
                E4.BackColor = Color.White;
            }

            mb = E5.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                E5.BackColor = Color.Green;
            }
            else
            {
                E5.BackColor = Color.White;
            }

            mb = E6.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                E6.BackColor = Color.Green;
            }
            else
            {
                E6.BackColor = Color.White;
            }

            mb = E7.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                E7.BackColor = Color.Green;
            }
            else
            {
                E7.BackColor = Color.White;
            }

            mb = F3.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                F3.BackColor = Color.Green;
            }
            else
            {
                F3.BackColor = Color.White;
            }

            mb = F4.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                F4.BackColor = Color.Green;
            }
            else
            {
                F4.BackColor = Color.White;
            }

            mb = F5.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                F5.BackColor = Color.Green;
            }
            else
            {
                F5.BackColor = Color.White;
            }

            mb = F6.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                F6.BackColor = Color.Green;
            }
            else
            {
                F6.BackColor = Color.White;
            }

            mb = F7.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                F7.BackColor = Color.Green;
            }
            else
            {
                F7.BackColor = Color.White;
            }

            mb = G3.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                G3.BackColor = Color.Green;
            }
            else
            {
                G3.BackColor = Color.White;
            }

            mb = G4.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                G4.BackColor = Color.Green;
            }
            else
            {
                G4.BackColor = Color.White;
            }

            mb = G5.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                G5.BackColor = Color.Green;
            }
            else
            {
                G5.BackColor = Color.White;
            }

            mb = G6.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                G6.BackColor = Color.Green;
            }
            else
            {
                G6.BackColor = Color.White;
            }

            mb = G7.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                G7.BackColor = Color.Green;
            }
            else
            {
                G7.BackColor = Color.White;
            }

            mb = H3.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                H3.BackColor = Color.Green;
            }
            else
            {
                H3.BackColor = Color.White;
            }

            mb = H4.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                H4.BackColor = Color.Green;
            }
            else
            {
                H4.BackColor = Color.White;
            }

            mb = H5.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                H5.BackColor = Color.Green;
            }
            else
            {
                H5.BackColor = Color.White;
            }

            mb = H6.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                H6.BackColor = Color.Green;
            }
            else
            {
                H6.BackColor = Color.White;
            }

            mb = H7.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                H7.BackColor = Color.Green;
            }
            else
            {
                H7.BackColor = Color.White;
            }

            mb = I3.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                I3.BackColor = Color.Green;
            }
            else
            {
                I3.BackColor = Color.White;
            }

            mb = I4.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                I4.BackColor = Color.Green;
            }
            else
            {
                I4.BackColor = Color.White;
            }

            mb = I5.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                I5.BackColor = Color.Green;
            }
            else
            {
                I5.BackColor = Color.White;
            }

            mb = I6.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                I6.BackColor = Color.Green;
            }
            else
            {
                I6.BackColor = Color.White;
            }

            mb = I7.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                I7.BackColor = Color.Green;
            }
            else
            {
                I7.BackColor = Color.White;
            }

            mb = K3.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                K3.BackColor = Color.Green;
            }
            else
            {
                K3.BackColor = Color.White;
            }

            mb = K4.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                K4.BackColor = Color.Green;
            }
            else
            {
                K4.BackColor = Color.White;
            }

            mb = K5.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                K5.BackColor = Color.Green;
            }
            else
            {
                K5.BackColor = Color.White;
            }

            mb = K6.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                K6.BackColor = Color.Green;
            }
            else
            {
                K6.BackColor = Color.White;
            }

            mb = K7.Name;
            ml = txt_malichchieu1.Text;
            dtMDH2.Clear();
            dtMDH2 = vb.LayMaGheCuaVe(mb, ml).Tables[0];
            if (dtMDH2.Rows.Count > 0)
            {
                K7.BackColor = Color.Green;
            }
            else
            {
                K7.BackColor = Color.White;
            }

        }
        void changeColor(string x)
        {
            if (x == A3.Name)
            {
                A3.BackColor = Color.Orange;
            }
            if (x == A4.Name)
            {
                A4.BackColor = Color.Orange;
            }
            if (x == A5.Name)
            {
                A5.BackColor = Color.Orange;
            }
            if (x == A6.Name)
            {
                A6.BackColor = Color.Orange;
            }
            if (x == A7.Name)
            {
                A7.BackColor = Color.Orange;
            }

            if (x == B3.Name)
            {
                B3.BackColor = Color.Orange;
            }
            if (x == B4.Name)
            {
                B4.BackColor = Color.Orange;
            }
            if (x == B5.Name)
            {
                B5.BackColor = Color.Orange;
            }
            if (x == B6.Name)
            {
                B6.BackColor = Color.Orange;
            }
            if (x == B7.Name)
            {
                B7.BackColor = Color.Orange;
            }

            if (x == C3.Name)
            {
                C3.BackColor = Color.Orange;
            }
            if (x == C4.Name)
            {
                C4.BackColor = Color.Orange;
            }
            if (x == C5.Name)
            {
                C5.BackColor = Color.Orange;
            }
            if (x == C6.Name)
            {
                C6.BackColor = Color.Orange;
            }
            if (x == C7.Name)
            {
                C7.BackColor = Color.Orange;
            }

            if (x == D3.Name)
            {
                D3.BackColor = Color.Orange;
            }
            if (x == D4.Name)
            {
                D4.BackColor = Color.Orange;
            }
            if (x == D5.Name)
            {
                D5.BackColor = Color.Orange;
            }
            if (x == D6.Name)
            {
                D6.BackColor = Color.Orange;
            }
            if (x == D7.Name)
            {
                D7.BackColor = Color.Orange;
            }

            if (x == E3.Name)
            {
                E3.BackColor = Color.Orange;
            }
            if (x == E4.Name)
            {
                E4.BackColor = Color.Orange;
            }
            if (x == E5.Name)
            {
                E5.BackColor = Color.Orange;
            }
            if (x == E6.Name)
            {
                E6.BackColor = Color.Orange;
            }
            if (x == E7.Name)
            {
                E7.BackColor = Color.Orange;
            }

            if (x == F3.Name)
            {
                F3.BackColor = Color.Orange;
            }
            if (x == F4.Name)
            {
                F4.BackColor = Color.Orange;
            }
            if (x == F5.Name)
            {
                F5.BackColor = Color.Orange;
            }
            if (x == F6.Name)
            {
                F6.BackColor = Color.Orange;
            }
            if (x == F7.Name)
            {
                F7.BackColor = Color.Orange;
            }

            if (x == G3.Name)
            {
                G3.BackColor = Color.Orange;
            }
            if (x == G4.Name)
            {
                G4.BackColor = Color.Orange;
            }
            if (x == G5.Name)
            {
                G5.BackColor = Color.Orange;
            }
            if (x == G6.Name)
            {
                G6.BackColor = Color.Orange;
            }
            if (x == G7.Name)
            {
                G7.BackColor = Color.Orange;
            }

            if (x == H3.Name)
            {
                H3.BackColor = Color.Orange;
            }
            if (x == H4.Name)
            {
                H4.BackColor = Color.Orange;
            }
            if (x == H5.Name)
            {
                H5.BackColor = Color.Orange;
            }
            if (x == H6.Name)
            {
                H6.BackColor = Color.Orange;
            }
            if (x == H7.Name)
            {
                H7.BackColor = Color.Orange;
            }

            if (x == I3.Name)
            {
                I3.BackColor = Color.Orange;
            }
            if (x == I4.Name)
            {
                I4.BackColor = Color.Orange;
            }
            if (x == I5.Name)
            {
                I5.BackColor = Color.Orange;
            }
            if (x == I6.Name)
            {
                I6.BackColor = Color.Orange;
            }
            if (x == I7.Name)
            {
                I7.BackColor = Color.Orange;
            }

            if (x == K3.Name)
            {
                K3.BackColor = Color.Orange;
            }
          
            if (x == K4.Name)
            {
                K4.BackColor = Color.Orange;
            }
            if (x == K5.Name)
            {
                K5.BackColor = Color.Orange;
            }
            if (x == K6.Name)
            {
                K6.BackColor = Color.Orange;
            }
            if (x == K7.Name)
            {
                K7.BackColor = Color.Orange;
            }
           


        }

        private void btn_SDPC_Click_1(object sender, EventArgs e)
        {
            LoadGhe();
        }

        private void cbx_lichchieu1_SelectedValueChanged_1(object sender, EventArgs e)
        {
            txt_malichchieu1.Text = vb.lichchieu(cbx_lichchieu1.Text).Tables[0].Rows[0][0].ToString();
            //txt_giave1.Text = vb.lichchieu(cbx_lichchieu1.Text).Tables[0].Rows[0][5].ToString();
        }

        private void cbx_maloaive1_SelectedValueChanged(object sender, EventArgs e)
        {
           txt_maloaive1.Text = vb.loaive(cbx_maloaive1.Text).Tables[0].Rows[0][0].ToString();
           txt_giave1.Text = vb.loaive(cbx_maloaive1.Text).Tables[0].Rows[0][5].ToString();
        }

        private void txt_soluong1_TextChanged(object sender, EventArgs e)
        {
            double a, b, kq;
            try
            {

                a = Double.Parse(txt_soluong1.Text);
                b = Double.Parse(txt_giave1.Text);
                kq = a * b;
                //txtTienDu.Text = kq.ToString();
                txt_gia.Text = kq.ToString();
            }
            catch (Exception)
            {
                // MessageBox.Show("Lỗi");
            }
        }

        private void btn_hoantat_Click(object sender, EventArgs e)
        {

            try
            {
                
                    string err = "";
                    bool trangthai = vb.ThemVeBan(ref err, txt_mave.Text, txt_malichchieu1.Text, txt_maloaive1.Text, Int32.Parse(txt_soluong1.Text), txt_ghe1.Text, cbx_nhanvien1.Text, float.Parse(txt_gia.Text));


                    if (trangthai)
                    {
                       
                        MessageBox.Show("Đặt Vé Thành Công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGhe();
                    }
                    else
                    {
                        MessageBox.Show("Không thêm được vé !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
              
                
            }
            catch (SqlException)
            {

            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            txt_ghe1.ResetText();
            LoadGhe();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void btn_inve_Click(object sender, EventArgs e)
        {
                string mave;
                //DataSet ds = new DataSet();
                try
                {
                    if (txt_mave.Text == "" || txt_malichchieu1.Text == "" || txt_maloaive1.Text == "" || txt_soluong1.Text == ""
                     || txt_ghe1.Text == "" || cbx_nhanvien1.Text == "" || txt_gia.Text == "")
                    {
                        MessageBox.Show("Có thông tin bạn chưa nhập kìa!");
                        //LoadData_Ve();
                    }
                    else
                    {
                        string err = "";

                        bool trangthai = vb.ThemVeBan(ref err, txt_mave.Text, txt_malichchieu1.Text, txt_maloaive1.Text, Int32.Parse(txt_soluong1.Text), txt_ghe1.Text, cbx_nhanvien1.Text, float.Parse(txt_gia.Text));
                        mave = txt_mave.Text;
                        Form_Ve hd = new Form_Ve();
                        // hd.UIParent = this;
                        hd.Text = txt_mave.Text + "/" + mave;
                        hd.ShowDialog();
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi Rồi!");
                }
                /////////////////

               
           // }

        }

       
        //============================================* PHAN DICH VU *========================================================//

        //============================================* PHAN DICH VU *=======================================================//
        public void Load_HoaDonDichVu()
        {
            btn_themHD.Enabled = true;
            btn_suaHD.Enabled = true;
            btn_xoaHD.Enabled = true;
            btn_huyHD.Enabled = true;
            btn_luuHD.Enabled = true;

            DataView dv = new DataView();
            ds = hddv.LayHoaDonDichVu();
            dgv_hoadon.DataSource = ds.Tables[0];

            // Load ma nhan vien
            ds = nv.LayNhanVien();
            DataView d = new DataView();
            d.Table = ds.Tables[0];
            for (int i = 0; i < d.Count; i++)
            {
                cbx_manhanvien.Items.Add(d.Table.Rows[i][0]);
            }
            cbx_manhanvien.SelectedIndex = 0;
            ////load combox cho ma dich vu
            ds = dvu.LayDichVu();
            DataView dvv = new DataView();
            //string donGia = "";
            dvv.Table = ds.Tables[0];
            for (int i = 0; i < dvv.Count; i++)
            {
                cbx_madichvu.Items.Add(dvv.Table.Rows[i][0]);


            }
            cbx_madichvu.SelectedIndex = 0;

        }
        private void btn_huyHD_Click(object sender, EventArgs e)
        {
            Load_HoaDonDichVu();
        }
        private void btn_themHD_Click(object sender, EventArgs e)
        {
            btn_themHD.Enabled = false;
            btn_suaHD.Enabled = false;
            btn_xoaHD.Enabled = false;
            btn_huyHD.Enabled = true;
            btn_luuHD.Enabled = true;


            f = true;
            txt_mahoadondv.ResetText();
            txt_mahoadondv.Enabled = true;
            cbx_manhanvien.Enabled = true;
            cbx_madichvu.Enabled = true;
            txt_soluong.ResetText();
            txt_soluong.Enabled = true;
            txt_giadv.ResetText();
            txt_giadv.Enabled = true;
            txt_thanhtien.ResetText();
            txt_thanhtien.Enabled = true;
        }

        private void btn_suaHD_Click(object sender, EventArgs e)
        {
            btn_themHD.Enabled = false;
            btn_suaHD.Enabled = false;
            btn_xoaHD.Enabled = false;
            btn_huyHD.Enabled = true;
            btn_luuHD.Enabled = true;

            f = false;

            txt_mahoadondv.Enabled = true;
            cbx_manhanvien.Enabled = true;
            cbx_maphim.Enabled = true;
            cbx_madichvu.Enabled = true;
            txt_soluong.Enabled = true;
            txt_giadv.Enabled = true;

            //Lay hang can sua
            int r = dgv_hoadon.CurrentCell.RowIndex;
            this.txt_mahoadondv.Text = dgv_hoadon.Rows[r].Cells[0].Value.ToString();
            this.cbx_manhanvien.Text = dgv_hoadon.Rows[r].Cells[1].Value.ToString();
            this.cbx_madichvu.Text = dgv_hoadon.Rows[r].Cells[2].Value.ToString();
            this.txt_soluong.Text = dgv_hoadon.Rows[r].Cells[3].Value.ToString();
            this.txt_giadv.Text = dgv_hoadon.Rows[r].Cells[4].Value.ToString();
            //this.

            txt_mahoadondv.Focus();
        }

        private void btn_xoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy hàng cần xóa
                int r = dgv_hoadon.CurrentCell.RowIndex;
                //lấy mã khách hàng

                string MaHoaDonDichVu = dgv_hoadon.Rows[r].Cells[0].Value.ToString();
                //hỏi xem có muốn xóa không
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi == DialogResult.OK)
                {
                    string err = "";
                    bool trangthai = hddv.XoaHoaDonDichVu(MaHoaDonDichVu, ref err);
                    if (trangthai)
                    {

                        MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Load_HoaDonDichVu();
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {

                }
            }
            catch (SqlException)
            {

            }
        }

        private void btn_luuHD_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_mahoadondv.Text == "" || cbx_manhanvien.Text == "" || cbx_madichvu.Text == "" || txt_soluong.Text == ""
                      || txt_giadv.Text == "" || txt_thanhtien.Text == "" )
                {
                    MessageBox.Show("Có thông tin bạn chưa nhập kìa!");
                }
                else
                {
                    if (f)
                    {
                        string err = "";
                        bool trangthai = hddv.ThemHoaDonDichVu(ref err, txt_mahoadondv.Text, cbx_manhanvien.Text, cbx_madichvu.Text,
                            Int32.Parse(txt_soluong.Text), float.Parse(txt_giadv.Text), float.Parse(txt_thanhtien.Text));

                        if (trangthai)
                        {
                            Load_HoaDonDichVu();
                            MessageBox.Show("Thêm dữ liệu thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Không thêm được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        string err = "";
                        bool trangthai = hddv.CapNhatHoaDonDichVu(ref err, txt_mahoadondv.Text, cbx_manhanvien.Text, cbx_madichvu.Text,
                            Int32.Parse(txt_soluong.Text), float.Parse(txt_giadv.Text), float.Parse(txt_thanhtien.Text));

                        if (trangthai)
                        {
                            Load_HoaDonDichVu();
                            MessageBox.Show("Sữa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không sữa được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (SqlException)
            {

            }
        }
        string mahoadondv;
        private void btn_inhoadon_Click(object sender, EventArgs e)
        {
            //string mahoadondv;
            if (dgv_hoadon.Rows[0].Cells[0].Value != null)
            {
                //////////////
                // HoaDon hd = new HoaDon();
                DataSet ds = new DataSet();
                try
                {
                    if (txt_mahoadondv.Text == "" || cbx_manhanvien.Text == "" || cbx_madichvu.Text == "" || txt_soluong.Text == ""
                      || txt_giadv.Text == "" || txt_thanhtien.Text == "")
                    {
                        MessageBox.Show("Có thông tin bạn chưa nhập kìa!");
                    }
                    else
                    {
                        string err = "";
                        bool trangthai = hddv.ThemHoaDonDichVu(ref err, txt_mahoadondv.Text, cbx_manhanvien.Text, cbx_madichvu.Text,
                            Int32.Parse(txt_soluong.Text), float.Parse(txt_giadv.Text), float.Parse(txt_thanhtien.Text));
                        mahoadondv = txt_mahoadondv.Text;
                        Form_HoaDon hd = new Form_HoaDon();
                        // hd.UIParent = this;
                        hd.Text = txt_mahoadondv.Text + "/" + mahoadondv;
                        hd.ShowDialog();
                    }
                }
                catch (SqlException)
                {
                    //MessageBox.Show("")
                }
                /////////////////

             
            }
        }

        private void cbx_madichvu_SelectedIndexChanged(object sender, EventArgs e)
        {
             txt_giadv.Text = dvu.DichVu(cbx_madichvu.Text).Tables[0].Rows[0][2].ToString();
        }

        private void txt_soluong_TextChanged(object sender, EventArgs e)
        {
             //txt_thanhtien.Text = 
           // this.txt_thanhtien.Text = (Double.Parse(dgv_hoadon.Rows[r].Cells[3].Value.ToString()) * Double.Parse(dgv_hoadon.Rows[r].Cells[5].Value.ToString())).ToString();
            double a, b, kq;
            try
            {

                a = Double.Parse(txt_soluong.Text);
                b = Double.Parse(txt_giadv.Text);
                kq = a *b;
                //txtTienDu.Text = kq.ToString();
                txt_thanhtien.Text = kq.ToString();
            }
            catch (Exception)
            {
               // MessageBox.Show("Lỗi");
            }
        }

        

        private void dgv_hoadon_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgv_hoadon.CurrentCell.RowIndex;
            this.txt_mahoadondv.Text = dgv_hoadon.Rows[r].Cells[0].Value.ToString();
            this.cbx_manhanvien.Text = dgv_hoadon.Rows[r].Cells[1].Value.ToString();
            this.cbx_madichvu.Text = dgv_hoadon.Rows[r].Cells[2].Value.ToString();
            this.txt_soluong.Text = dgv_hoadon.Rows[r].Cells[3].Value.ToString();
            this.txt_giadv.Text = dgv_hoadon.Rows[r].Cells[4].Value.ToString();
            this.txt_thanhtien.Text = dgv_hoadon.Rows[r].Cells[5].Value.ToString();
        }

        private void dgv_dichvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgv_dichvu.CurrentCell.RowIndex;
            //this.txt_mahoadondv.Text = dgv_dichvu.Rows[r].Cells[0].Value.ToString();
            // this.cbx_manhanvien.Text = dgv_dichvu.Rows[r].Cells[1].Value.ToString();
            this.cbx_madichvu.Text = dgv_dichvu.Rows[r].Cells[1].Value.ToString();
            // this.txt_soluong.Text = dgv_dichvu.Rows[r].Cells[3].Value.ToString();
            this.txt_giadv.Text = dgv_dichvu.Rows[r].Cells[2].Value.ToString();
        }
        public void LoadDichVu()
        {
            ds = dvu.LayDichVu();
            dgv_dichvu.DataSource = ds.Tables[0];
        }
        //============================================* XEM LICH CHIEU *========================================================//

        //============================================* XEM LICH CHIEU *=======================================================//
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
                btn_timkiemLC.PerformClick();
            else Load_LichChieu();
        }
        public void Load_LichChieu()
        {

            cbx_tim.Items.Add("NgayChieu");
            ds = lc.LayLichChieu();
            dgv_lichchieu.DataSource = ds.Tables[0];
            
        }
        private void btn_timkiemLC_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
                MessageBox.Show("Hãy nhập liệu vào ô tìm kiếm.", "Thông báo");
            else
            {
                switch (cbx_tim.Text)
                {
                    case "NgayChieu":
                        {
                            ds = lc.Find_NgayChieu(textBox1.Text);
                            dgv_lichchieu.DataSource = ds.Tables[0];
                            break;
                        }

                }
            }
        }

       
       /////////
        public Image byteArrayToImage(byte[] byteArrayIn)
        {

            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }


        void loadTrangChu()
        {
            ds = p.LayPhim();
            DataTable dt = ds.Tables[0];
            List<DataRow> list = new List<DataRow>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr);
            }

            int so = 0;
            int cot = 0;

            while (so < dt.Rows.Count)
            {

                for (int i = 0; i < 5; i++)
                {

                    PictureBox pic = new PictureBox();
                    Label lbl = new Label();
                    Button btn = new Button();
                    pic.Location = new Point(i * 230 + 20, cot * 230 + 20);
                    pic.Name = ds.Tables[0].Rows[so][0].ToString().Trim();
                    pic.AccessibleName = ds.Tables[0].Rows[so][1].ToString().Trim();
                    pic.BackColor = Color.Azure;
                    pic.Size = new Size(200, 200);
                    pic.Image = byteArrayToImage((Byte[])(ds.Tables[0].Rows[so][6]));
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    lbl.Location = new Point(i * 230 + 35, cot * 230 + 225);
                    lbl.Text = (ds.Tables[0].Rows[so][1]).ToString();
                    pic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptb_MouseClick);
                    PanelTrangChu.Controls.Add(pic);
                    PanelTrangChu.Controls.Add(lbl);
                    so++;
                    if (so == dt.Rows.Count)
                        break;

                }
                cot++;
            }
        }

        private void ptb_MouseClick(object sender, EventArgs e)
        {
            List<DataRow> list = new List<DataRow>();
            frmTrailer1 ftl = new frmTrailer1(this);
            PictureBox a = (PictureBox)sender;
            ftl.Maphim = a.Name;
            ftl.Text = a.AccessibleName;
            ftl.ShowDialog();
        }

        private void dgv_lichchieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgv_lichchieu.CurrentCell.RowIndex;
            txt_malichchieu.Text = dgv_lichchieu.Rows[r].Cells[0].Value.ToString();
            dpt_ngaychieu.Text = dgv_lichchieu.Rows[r].Cells[1].Value.ToString();
            dpt_giochieu.Text = dgv_lichchieu.Rows[r].Cells[2].Value.ToString();
            cbx_maphongchieu.Text = dgv_lichchieu.Rows[r].Cells[3].Value.ToString();
            cbx_maphim.Text = dgv_lichchieu.Rows[r].Cells[4].Value.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
