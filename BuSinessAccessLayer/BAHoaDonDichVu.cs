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
    public class BAHoaDonDichVu
    {
         DALayer db;
         public BAHoaDonDichVu()
        {
            db = new DALayer();
        }
        public DataSet LayHoaDonDichVu()
        {
            return db.ExecuteQueryDataSet(
                "select * from HoaDonDichVu ", CommandType.Text, null);

        }
        public DataSet LoadHoaDon(string MaHoaDonDichVu)
        {
            return db.ExecuteQueryDataSet(
                    "select HoaDonDichVu.MaHoaDonDichVu,HoaDonDichVu.MaNhanVien,HoaDonDichVu.MaDichVu,HoaDonDichVu.SoLuong,HoaDonDichVu.DonGia,HoaDonDichVu.ThanhTien from HoaDonDichVu where HoaDonDichVu.MaHoaDonDichVu='" + MaHoaDonDichVu + "'", CommandType.Text, null);
        }
        public bool ThemHoaDonDichVu(ref string err, string MaHoaDonDichVu, string MaNhanVien, string MaDichVu, int SoLuong, float DonGia,float ThanhTien)
        {
            return db.MyExecuteNonQuery(
                "spThemHoaDonDichVu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaHoaDonDichVu", MaHoaDonDichVu),
                new SqlParameter("@MaNhanVien", MaNhanVien),
                new SqlParameter("@MaDichVu", MaDichVu),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@DonGia", DonGia),
                new SqlParameter("@ThanhTien",ThanhTien));
         }
        public bool XoaHoaDonDichVu( string MaHoaDonDichVu, ref string err)
        {
            return db.MyExecuteNonQuery(
                "spXoaHoaDonDichVu", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaHoaDonDichVu", MaHoaDonDichVu));
        }
        public bool CapNhatHoaDonDichVu(ref string err, string MaHoaDonDichVu, string MaNhanVien, string MaDichVu, int SoLuong, float DonGia, float ThanhTien)
        {
            return db.MyExecuteNonQuery(
                "spCapNhatHoaDonDichVu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaHoaDonDichVu", MaHoaDonDichVu),
                new SqlParameter("@MaNhanVien", MaNhanVien),
                new SqlParameter("@MaDichVu", MaDichVu),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@DonGia", DonGia),
                new SqlParameter("@ThanhTien",ThanhTien));
        }
        public DataSet DanhSachHoaDonTheoDichVu()
        {
            return db.ExecuteQueryDataSet("Select HoaDonDichVu.MaHoaDonDichVu,HoaDonDichVu.MaNhanVien,HoaDonDichVu.MaDichVu,HoaDonDichVu.SoLuong,HoaDonDichVu.DonGia, DichVu.GiaDV  from HoaDonDichVu join DichVu on HoaDonDichVu.MaDichVu=DichVu.MaDichVu", CommandType.Text, null);
        }
    }
}
