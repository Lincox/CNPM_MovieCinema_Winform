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
    public class BATaiKhoan
    {
        DALayer db;
        public BATaiKhoan()
        {
            db = new DALayer();
        }
        public DataSet LayTaiKhoan()
        {
            return db.ExecuteQueryDataSet(
                "select * from TaiKhoan", CommandType.Text, null);

        }
        public bool ThemTaiKhoan(ref string err,string TaiKhoan,  string PassWord, string Quyen)
        {
            return db.MyExecuteNonQuery(
                "spThemLichChieu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@TaiKhoan", TaiKhoan),
                new SqlParameter("@PassWord", PassWord),
                new SqlParameter("@Quyen", Quyen));
               
        }

        //public bool XoaLichChieu(ref string err, string MaLichChieu)
        //{
        //    return db.MyExecuteNonQuery(
        //        "spXoaLichChieu", CommandType.StoredProcedure, ref err,
        //        new SqlParameter("@MaPhim", MaLichChieu));
        //}
        //public bool CapNhatLichChieu(ref string err, string MaLichChieu, DateTime NgayChieu, string GioChieu, string MaPhongChieu, string MaPhim)
        //{
        //    return db.MyExecuteNonQuery(
        //        "spCapNhatLichChieu",
        //        CommandType.StoredProcedure, ref err,
        //        new SqlParameter("@MaLichChieu", MaLichChieu),
        //        new SqlParameter("@NgayChieu", NgayChieu),
        //        new SqlParameter("@GioChieu", GioChieu),
        //        new SqlParameter("@MaPhongChieu", MaPhongChieu),
        //        new SqlParameter("@MaPhim", MaPhim));

        //}
    
    }
}
