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
    public class BAPhim
    {
        DALayer db;
        public BAPhim()
        {
            db = new DALayer();
        }
        public DataSet LayPhim()
        {
            return db.ExecuteQueryDataSet(
                "select * from Phim", CommandType.Text, null);

        }
        public bool ThemPhim(ref string err, string MaPhim, string TenPhim, string DaoDien, string MaTheLoai, string DienVien, string NoiDung,
            byte[] Hinh, string Trailer, int NamSanXuat, string QuocGia, string ThoiLuong)
        {
            return db.MyExecuteNonQuery(
                "spThemPhim",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaPhim", MaPhim),
                new SqlParameter("@TenPhim", TenPhim),
                new SqlParameter("@DaoDien", DaoDien),
                new SqlParameter("@MaTheLoai", MaTheLoai),
                new SqlParameter("@DienVien", DienVien),
                new SqlParameter("@NoiDung", NoiDung),
                new SqlParameter("@Hinh", Hinh),
                new SqlParameter("@Trailer", Trailer),
                new SqlParameter("@NamSanXuat", NamSanXuat),
                new SqlParameter("@QuocGia", QuocGia),
                new SqlParameter("@ThoiLuong", ThoiLuong));

        }
        public bool XoaPhim(ref string err, string MaPhim)
        {
            return db.MyExecuteNonQuery(
                "spXoaPhim", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaPhim", MaPhim));
        }
        public bool CapNhatPhim(ref string err, string MaPhim, string TenPhim, string DaoDien, string MaTheLoai, string DienVien, string NoiDung,
            byte[] Hinh, string Trailer, int NamSanXuat, string QuocGia, string ThoiLuong)
        {
            return db.MyExecuteNonQuery(
                "spCapNhatPhim",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaPhim", MaPhim),
                new SqlParameter("@TenPhim", TenPhim),
                new SqlParameter("@DaoDien", DaoDien),
                new SqlParameter("@MaTheLoai", MaTheLoai),
                new SqlParameter("@DienVien", DienVien),
                new SqlParameter("@NoiDung", NoiDung),
                new SqlParameter("@Hinh", Hinh),
                new SqlParameter("@Trailer", Trailer),
                new SqlParameter("@NamSanXuat", NamSanXuat),
                new SqlParameter("@QuocGia", QuocGia),
                new SqlParameter("@ThoiLuong", ThoiLuong));

        }
    }
}
