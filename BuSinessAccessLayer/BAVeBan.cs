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
    public class BAVeBan
    {
        DALayer db;
        public BAVeBan()
        {
            db = new DALayer();
        }
        public DataSet LayVeBan()
        {
            return db.ExecuteQueryDataSet(
                "select * from VeBan", CommandType.Text, null);

        }
        public DataSet LayMaLichChieu(string MaLichChieu)
        {
            return db.ExecuteQueryDataSet(
                         "select MaLichChieu from VeBan", CommandType.Text, null);
        }
        public bool ThemVeBan(ref string err, string MaVe, string MaLichChieu, string MaLoaiVe, int SoLuong, string MaGhe,
            string MaNhanVien, float Gia)
        {
            return db.MyExecuteNonQuery(
                "spThemVeBan",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaVe", MaVe),
                new SqlParameter("@MaLichChieu", MaLichChieu),
                new SqlParameter("@MaLoaiVe", MaLoaiVe),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@MaGhe", MaGhe),
                new SqlParameter("@MaNhanVien", MaNhanVien),
                new SqlParameter("@Gia", Gia));

        }
        public bool XoaVeBan(ref string err, string MaVe)
        {
            return db.MyExecuteNonQuery(
                "spXoaVeBan", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaVe", MaVe));
        }
        public bool CapNhatVeBan(ref string err, string MaVe, string MaLichChieu, string MaLoaiVe, int SoLuong, string MaGhe,
               string MaNhanVien, float Gia)
        {
            return db.MyExecuteNonQuery(
                "spCapNhatVeBan",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaVe", MaVe),
                new SqlParameter("@MaLichChieu", MaLichChieu),
                new SqlParameter("@MaLoaiVe", MaLoaiVe),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@MaGhe", MaGhe),
                new SqlParameter("@MaNhanVien", MaNhanVien),
                new SqlParameter("@Gia", Gia));

        }

        public DataSet LayMaGheCuaVe(string MaGhe, string MaLichChieu)
        {
            return db.ExecuteQueryDataSet("select MaVe from VeBan where MaGhe = '" + MaGhe + "'and MaLichChieu ='" + MaLichChieu + "'", CommandType.Text, null);
        }
        public DataSet lichchieu(string NgayChieu)
        {
            return db.ExecuteQueryDataSet("Select * from  LichChieu where NgayChieu=N'" + NgayChieu + "'", CommandType.Text, null);
        }
        public DataSet loaive(string TenLoai)
        {
            return db.ExecuteQueryDataSet("Select * from  LoaiVe where TenLoai=N'" + TenLoai + "'", CommandType.Text, null);
        }
        //public DataSet LoadHoaDon(string MaHoaDonDichVu)
        //{
        //    return db.ExecuteQueryDataSet(
        //            "select HoaDonDichVu.MaHoaDonDichVu,HoaDonDichVu.MaNhanVien,HoaDonDichVu.MaDichVu,HoaDonDichVu.SoLuong,HoaDonDichVu.DonGia,HoaDonDichVu.ThanhTien from HoaDonDichVu where HoaDonDichVu.MaHoaDonDichVu='" + MaHoaDonDichVu + "'", CommandType.Text, null);
        //}
        public DataSet LoadVe(string MaVe)
        {
            return db.ExecuteQueryDataSet(
                "select VeBan.MaVe, VeBan.MaLichChieu, VeBan.MaLoaiVe, VeBan.SoLuong, VeBan.MaGhe, VeBan.MaNhanVien, VeBan.Gia from VeBan where Veban.MaVe= '"+ MaVe +"'",CommandType.Text,null);
        }
    }

}
