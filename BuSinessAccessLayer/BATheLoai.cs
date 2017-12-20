using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;


namespace BuSinessAccessLayer
{

     public  class BATheLoai
    {
         DALayer db;
         public BATheLoai()
        {
            db = new DALayer();
        }
        public DataSet LayTheLoai()
        {
            return db.ExecuteQueryDataSet(
                "select * from TheLoai", CommandType.Text, null);

        }
        public bool ThemTheLoai(ref string err,string MaTheLoai,  string TenTheLoai)
        {
            return db.MyExecuteNonQuery(
                "spThemTheLoai",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaTheLoai", MaTheLoai),
                new SqlParameter("@TenTheLoai", TenTheLoai));
                
        }
        public bool XoaTheLoai(ref string err, string MaTheLoai)
        {
            return db.MyExecuteNonQuery(
                "spXoaTheLoai", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaTheLoai", MaTheLoai));
        }
        public bool CapNhatTheLoai(ref string err, string MaTheLoai,  string TenTheLoai)
        {
            return db.MyExecuteNonQuery(
                "spCapNhatTheLoai",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaTheLoai", MaTheLoai),
                new SqlParameter("@TenTheLoai", TenTheLoai));
                
        }

        public DataSet Find_NgayChieu(string NgayChieu)
        {
            return db.ExecuteQueryDataSet(
                "select * from LichChieu where NgayChieu like '" + NgayChieu + "%'",
                CommandType.Text,
                null);
        }
    }
}
