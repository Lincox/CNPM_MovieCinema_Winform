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
    public partial class Form_Ve : Form
    {
        string hula;
        public Form_Ve()
        {
            InitializeComponent();
        }

       
        void LoadData()
        {
            //this.label1.BackColor = Color.Transparent;
            //this.lable1.BackColor = Color.Transparent;
            //Home dv = UIParent as Home;
            DataSet ds = new DataSet();
            BAVeBan hd = new BAVeBan();
            string[] arr = hula.ToString().Split('/');
            // ds = hd.LayHoaDonDichVu(); 
            ds = hd.LoadVe(arr[0]);
            // ds = kh.ChiTietPhieuThuCuaKH(arr[0], arr[1]);
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];

            lb_mave.Text = dv.Table.Rows[0][0].ToString();
            la_malc.Text = dv.Table.Rows[0][1].ToString();
            lb_malv.Text = dv.Table.Rows[0][2].ToString();
            lb_soluong1.Text = dv.Table.Rows[0][3].ToString();
            lb_ghe.Text = dv.Table.Rows[0][4].ToString();
            lb_nv.Text = dv.Table.Rows[0][5].ToString();
            lb_gia.Text = dv.Table.Rows[0][5].ToString();
        }

        private void Form_Ve_Load_1(object sender, EventArgs e)
        {
            
        }

        private void Form_Ve_Load(object sender, EventArgs e)
        {
            hula = this.Text;
            this.Text = "Form_Ve";
            LoadData();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lb_gia_Click(object sender, EventArgs e)
        {

        }
    }
}
