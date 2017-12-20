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
    public class BAPhongChieu
    {
        DALayer db;
        public BAPhongChieu()
        {
            db = new DALayer();
        }
        public DataSet LayPhongChieu()
        {
            return db.ExecuteQueryDataSet(
                "select * from PhongChieu", CommandType.Text, null);

        }
        public bool ThemPhongChieu(ref string err, string MaPhongChieu, int SoCho, int SoDay, string MayChieu, string AmThanh, string DienTich,
            bool TinhTrang, string ThietBiKhac)
        {
            return db.MyExecuteNonQuery(
                "spThemPhongChieu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaPhongChieu", MaPhongChieu),
                new SqlParameter("@SoCho", SoCho),
                new SqlParameter("@SoDay", SoDay),
                new SqlParameter("@MayChieu", MayChieu),
                new SqlParameter("@AmThanh", AmThanh),
                new SqlParameter("@DienTich", DienTich),
                new SqlParameter("@TinhTrang", TinhTrang),
                new SqlParameter("@ThietBiKhac", ThietBiKhac));

        }
        public bool XoaPhongChieu(ref string err, string MaPhongChieu)
        {
            return db.MyExecuteNonQuery(
                "spXoaPhongChieu", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaPhongChieu", MaPhongChieu));
        }
        public bool CapNhatPhongChieu(ref string err, string MaPhongChieu, int SoCho, int SoDay, string MayChieu, string AmThanh, string DienTich,
            bool TinhTrang, string ThietBiKhac)
        {
            return db.MyExecuteNonQuery(
                "spCapNhatPhongChieu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaPhongChieu", MaPhongChieu),
                new SqlParameter("@SoCho", SoCho),
                new SqlParameter("@SoDay", SoDay),
                new SqlParameter("@MayChieu", MayChieu),
                new SqlParameter("@AmThanh", AmThanh),
                new SqlParameter("@DienTich", DienTich),
                new SqlParameter("@TinhTrang", TinhTrang),
                new SqlParameter("@ThietBiKhac", ThietBiKhac));

        }
    }
}
