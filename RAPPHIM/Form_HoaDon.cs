using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BuSinessAccessLayer;

namespace RAPPHIM
{
    public partial class Form_HoaDon : Form
    {
        string hula;
        public Form_HoaDon()
        {
            InitializeComponent();
        }
 
        void LoadData()
        {
            //if ()
          //  {
                //Home dv = UIParent as Home;
                DataSet ds = new DataSet();
                BAHoaDonDichVu hd = new BAHoaDonDichVu();
                string[] arr = hula.ToString().Split('/');
               // ds = hd.LayHoaDonDichVu(); 
                ds = hd.LoadHoaDon( arr[0]);
               // ds = kh.ChiTietPhieuThuCuaKH(arr[0], arr[1]);
                DataView dv = new DataView();
                dv.Table = ds.Tables[0];
                
                lb_mahd.Text = dv.Table.Rows[0][0].ToString();
                la_manv.Text = dv.Table.Rows[0][1].ToString();
                lb_madv.Text = dv.Table.Rows[0][2].ToString();
                lb_soluong.Text = dv.Table.Rows[0][3].ToString();
                lb_dongia.Text = dv.Table.Rows[0][4].ToString();
                lb_thanhtien.Text = dv.Table.Rows[0][5].ToString();
        //   }

        }
        private void Form_HoaDon_Load(object sender, EventArgs e)
        {
            hula = this.Text;
            this.Text = "Form_HoaDon";
            LoadData();
        }

       

       

        
    }
}
