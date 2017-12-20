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
    public class BADangNhap
    {
        DALayer db;
        public BADangNhap()
        {
            db = new DALayer();
        }
        public DataSet LayTaiKhoan()
        {
            return db.ExecuteQueryDataSet(
                "select * from TaiKhoan", CommandType.Text, null);

        }
        public DataSet Layquyen()
        {
            return db.ExecuteQueryDataSet(
                "select Quyen from TaiKhoan", CommandType.Text, null);

        }
        public DataSet Layquyen1(string TaiKhoan)
        {
            return db.ExecuteQueryDataSet("select Quyen from TaiKhoan where TaiKhoan = '" + TaiKhoan + "'", CommandType.Text, null);
        }
        public bool ThemTaiKhoan(ref string err, string TaiKhoan, string MatKhau, string Quyen)
        {
            return db.MyExecuteNonQuery(
                "spThemTaiKhoan",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@TaiKhoan", TaiKhoan),
                new SqlParameter("@MatKhau", MatKhau),
                new SqlParameter("@Quyen", Quyen));

        }
        public bool XoaTaiKhoan(ref string err, string TaiKhoan)
        {
            return db.MyExecuteNonQuery(
                "spXoaTaiKhoan", CommandType.StoredProcedure, ref err,
                new SqlParameter("@TaiKhoan", TaiKhoan));
        }
        public bool CapNhatTaiKhoan(ref string err, string TaiKhoan, string MatKhau, string Quyen)
        {
            return db.MyExecuteNonQuery(
                "spCapNhatTaiKhoan",
                CommandType.StoredProcedure,ref err,
                new SqlParameter("@TaiKhoan",TaiKhoan),
                new SqlParameter("@MatKhau", MatKhau),
                new SqlParameter("@Quyen",Quyen));
        }
        public bool KiemTraTaiKhoan(string TaiKhoan, string MatKhau)
        {
            bool f = false;
            try
            {
                //int result = db.CheckUserLogin
                

                int result = db.CheckUserLogin(CommandType.StoredProcedure,
                    "spCheckDangNhap", new SqlParameter("@TaiKhoan", TaiKhoan),
                    new SqlParameter("@MatKhau", MatKhau));
                if (result > 0)
                    f = true;
            }
            catch (SqlException)
            {
                f = false;
            }
            return f;
        }

    }
}
