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
    public class BANhanVien
    {
        DALayer db;
        public BANhanVien()
        {
            db = new DALayer();
        }
        public DataSet LayNhanVien()
        {
            return db.ExecuteQueryDataSet(
                "select * from NhanVien", CommandType.Text, null);

        }
        public bool ThemNhanVien(ref string err, string MaNhanVien, string HoTenNhanVien, DateTime NgaySinh, bool GioiTinh, string CMND,
            string SDT, byte[] HinhAnh, string ChucVu, string DiaChi)
        {
            return db.MyExecuteNonQuery(
                "spThemNhanVien",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNhanVien", MaNhanVien),
                new SqlParameter("@HoTenNhanVien", HoTenNhanVien),
                new SqlParameter("@NgaySinh", NgaySinh),
                new SqlParameter("@GioiTinh", GioiTinh),
                new SqlParameter("@CMND", CMND),
                new SqlParameter("@SDT", SDT),
                new SqlParameter("@HinhAnh", HinhAnh),
                new SqlParameter("@ChucVu", ChucVu),
                new SqlParameter("@DiaChi", DiaChi));

        }
        public bool XoaNhanVien(ref string err, string MaNhanVien)
        {
            return db.MyExecuteNonQuery(
                "spXoaNhanVien", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNhanVien", MaNhanVien));
        }
        public bool CapNhatNhanVien(ref string err, string MaNhanVien, string HoTenNhanVien, DateTime NgaySinh, bool GioiTinh, string CMND,
        string SDT, byte[] HinhAnh, string ChucVu, string DiaChi)
        {
            return db.MyExecuteNonQuery(
                "spCapNhatNhanVien",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNhanVien", MaNhanVien),
                new SqlParameter("@HoTenNhanVien", HoTenNhanVien),
                new SqlParameter("@NgaySinh", NgaySinh),
                new SqlParameter("@GioiTinh", GioiTinh),
                new SqlParameter("@CMND", CMND),
                new SqlParameter("@SDT", SDT),
                new SqlParameter("@HinhAnh", HinhAnh),
                new SqlParameter("@ChucVu", ChucVu),
                new SqlParameter("@DiaChi", DiaChi));

        }
    }
}
