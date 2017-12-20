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
    public class BALichChieu
    {
        DALayer db;
        public BALichChieu()
        {
            db = new DALayer();
        }
        public DataSet LayLichChieu()
        {
            return db.ExecuteQueryDataSet(
                "select * from LichChieu", CommandType.Text, null);

        }
        public bool ThemLichChieu(ref string err,string MaLichChieu, DateTime NgayChieu, string GioChieu,
            string MaPhongChieu, string MaPhim)
        {
            return db.MyExecuteNonQuery(
                "spThemLichChieu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaLichChieu", MaLichChieu),
                new SqlParameter("@NgayChieu", NgayChieu),
                new SqlParameter("@GioChieu", GioChieu),
                new SqlParameter("@MaPhongChieu", MaPhongChieu),
                new SqlParameter("@MaPhim", MaPhim));

        }
        public bool XoaLichChieu(ref string err, string MaLichChieu)
        {
            return db.MyExecuteNonQuery(
                "spXoaLichChieu", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaLichChieu", MaLichChieu));
        }
        public bool CapNhatLichChieu(ref string err, string MaLichChieu, DateTime NgayChieu, string GioChieu, 
            string MaPhongChieu, string MaPhim)
        {
            return db.MyExecuteNonQuery(
                "spCapNhatLichChieu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaLichChieu", MaLichChieu),
                new SqlParameter("@NgayChieu", NgayChieu),
                new SqlParameter("@GioChieu", GioChieu),
                new SqlParameter("@MaPhongChieu", MaPhongChieu),
                new SqlParameter("@MaPhim", MaPhim));

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
