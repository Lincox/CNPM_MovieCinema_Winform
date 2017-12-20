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
    public partial class frmTrailer : Form
    {
        Home home;
        BAPhim p = new BAPhim();
        public frmTrailer(Home a)
        {
            InitializeComponent();
            home = a;
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
        private void frmTrailer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            home.Show();
        }

        private void frmTrailer_Load(object sender, EventArgs e)
        {

            Load1();
            sfTrailer.Movie = Link;

          
        }
    }
}
