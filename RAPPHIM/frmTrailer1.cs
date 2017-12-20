using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using BuSinessAccessLayer;

namespace RAPPHIM
{
    public partial class frmTrailer1 : Form
    {
        Home_NV home1;
        BAPhim p = new BAPhim();
        public frmTrailer1(Home_NV a)
        {
            InitializeComponent();
            home1 = a;
        }
        string maphim;
        public string Maphim
        {
            get { return maphim; }
            set { maphim = value; }
        }
        string Link = "";
        public void Load1()
        {

            DataSet ds = new DataSet();
            ds = p.LayPhim();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row[0].ToString().Trim() == maphim)
                {
                    Link = row[7].ToString();
                    break;
                }
            }
        }
        private void frmTrailer1_Load(object sender, EventArgs e)
        {
            Load1();
            sfTrailer.Movie = Link;
        }

        private void frmTrailer1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            home1.Show();
        }
    }
}
