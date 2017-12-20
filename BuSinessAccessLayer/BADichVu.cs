using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
namespace BuSinessAccessLayer
{
     public class BADichVu
    {
         DALayer db;
         public BADichVu()
        {
            db = new DALayer();
        }
        public DataSet LayDichVu( )
        {
            return db.ExecuteQueryDataSet(
                "select * from DichVu", CommandType.Text, null);

        }
        public DataSet DichVu(string MaDichVu)
        {
            //string q = string.Format("select * from DichVu('{0}')", MaDichVu);
            //return db.ExecuteQueryDataSet(q, CommandType.Text, null);
            return db.ExecuteQueryDataSet("Select * from DichVu where MaDichVu=N'" + MaDichVu + "'", CommandType.Text, null);

        }
        public bool ThemDichVu(ref string err, string MaDichVu, string TenDichVu, float GiaDV)
        {
            return db.MyExecuteNonQuery(
                "spThemDichVu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaDichVu", MaDichVu),
                new SqlParameter("@TenDichVu", TenDichVu),
                new SqlParameter("@GiaDV", GiaDV));

        }
        public bool XoaDichVu(ref string err, string MaDichVu)
        {
            return db.MyExecuteNonQuery(
                "spXoaDichVu", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaDichVu", MaDichVu));
        }
        public bool CapNhatDichVu(ref string err, string MaDichVu, string TenDichVu, float GiaDV)
        {
            return db.MyExecuteNonQuery(
                "spCapNhatDichVu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaDichVu", MaDichVu),
                new SqlParameter("@TenDichVu", TenDichVu),
                new SqlParameter("@GiaDV", GiaDV));

        }
    }
}
