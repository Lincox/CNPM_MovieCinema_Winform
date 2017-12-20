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
    public class BALoaiVe
    {
        DALayer db;
        public BALoaiVe()
        {
            db = new DALayer();
        }
        public DataSet LayLoaiVe()
        {
            return db.ExecuteQueryDataSet(
                "select * from LoaiVe", CommandType.Text, null);

        }
        public bool ThemLoaiVe(ref string err, string MaLoaiVe, string TenLoai, string HangGhe, string NgayBan, string DoiTuong, float Gia)
        {
            return db.MyExecuteNonQuery(
                "spThemLoaiVe",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaLoaiVe", MaLoaiVe),
                new SqlParameter("@TenLoai", TenLoai),
                new SqlParameter("@HangGhe", HangGhe),
                new SqlParameter("@NgayBan", NgayBan),
                new SqlParameter("@DoiTuong", DoiTuong),
                new SqlParameter("@Gia",Gia));

        }
        public bool XoaLoaiVe(ref string err, string MaLoaiVe)
        {
            return db.MyExecuteNonQuery(
                "spXoaLoaiVe", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaLoaiVe", MaLoaiVe));
        }
        public bool CapNhatLoaiVe(ref string err, string MaLoaiVe, string TenLoai, string HangGhe, string NgayBan, string DoiTuong, float Gia)
        {
            return db.MyExecuteNonQuery(
                "spCapNhatLoaiVe",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaLoaiVe", MaLoaiVe),
                new SqlParameter("@TenLoai", TenLoai),
                new SqlParameter("@HangGhe", HangGhe),
                new SqlParameter("@NgayBan", NgayBan),
                new SqlParameter("@DoiTuong", DoiTuong),
                new SqlParameter("@Gia", Gia));

        }
    }
}
