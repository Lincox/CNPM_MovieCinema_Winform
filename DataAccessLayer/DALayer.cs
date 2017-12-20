using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DataAccessLayer
{
    public class DALayer
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataAdapter adp;

        string strConnect = "Data Source=workstation id=NguyenThanhThai.mssql.somee.com;packet size=4096;user id=nguyentthai96_SQLLogin_1;pwd=t4b3uwkq6o;data source=NguyenThanhThai.mssql.somee.com;persist security info=False;initial catalog=NguyenThanhThai";
          //  ";Integrated Security=True";

        public DALayer()
        {
            try
            {
                cnn = new SqlConnection(strConnect);
                cmd = cnn.CreateCommand();
            }
            catch (SqlException)
            {

            }

        }
        // Select query
        public DataSet ExecuteQueryDataSet(
            string strSQL, CommandType ct,
            params SqlParameter[] p)
        {
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }

        public string ExecuteQueryXML(string strSQL, CommandType ct, params SqlParameter[] p)
        {
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds.GetXml();
        }

        public int CheckUserLogin(CommandType type,
           string comdText, params SqlParameter[] param)
        {
            int result = -1;
            //
            cmd.Parameters.Clear();
            cmd.CommandType = type;
            cmd.CommandText = comdText;
            foreach (SqlParameter p in param)
                cmd.Parameters.Add(p);
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
            cnn.Open();
            try
            {
                // Aggregate Function
                result = (int)cmd.ExecuteScalar();
            }
            catch (SqlException)
            {

            }
            finally
            {
                cnn.Close();
            }
            //
            return result;
        }
        // action query
        public bool MyExecuteNonQuery(string strSQL,
            CommandType ct, ref string error,
            params SqlParameter[] param)
        {
            bool f = false;
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
            cnn.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            foreach (SqlParameter p in param)
                cmd.Parameters.Add(p);
            try
            {
                cmd.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                cnn.Close();
            }
            return f;
        }
    }
}
