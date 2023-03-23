using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Provider
{

    public class MyProvider
    {
        SqlCommand cmd = null;
        public SqlConnection conn = null;

        public MyProvider()
        {

        }
        public MyProvider(string cmdText, string appConnectionString = "server=.;Database=AssetDB;Integrated Security=True")
        {
            conn = new SqlConnection(appConnectionString);
            cmd = new SqlCommand(cmdText, conn);
        }
        public MyProvider(string cmdText, CommandType type, SqlTransaction tran, string appConnectionString = "server=.;Database=AssetDB;Integrated Security=True")
        {
            conn = new SqlConnection(appConnectionString);

            cmd = new SqlCommand(cmdText, conn, tran);
            cmd.CommandType = type;

        }

        public MyProvider(string[] cmdText, List<SqlParameter[]> myParameters, SqlTransaction tran, string appConnectionString = "server=.;Database=AssetDB;Integrated Security=True")
        {
            conn = new SqlConnection(appConnectionString);
            try
            {
                conn.Open();
                tran = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(cmdText[0], conn, tran);
                AddParameter(cmd, myParameters[0]);
                int query = cmd.ExecuteNonQuery();
                cmd = new SqlCommand(cmdText[1], conn, tran);
                AddParameter(cmd, myParameters[1]);
                int query1 = cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception )
            {
                // handle exception
            }
            finally
            {
                CloseConnection();
            }
        }
        public void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public SqlDataReader ExecuteReader()
        {
            SqlDataReader rdr = null;
            try
            {
                OpenConnection();
                rdr = cmd.ExecuteReader();
            }
            catch (Exception)
            {


            }
            finally
            {
                //CloseConnection();
            }
            return rdr;

        }

        public int ExecuteNonQuery()
        {
            int result = 0;

            try
            {
                OpenConnection();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception )
            {

                result = 0;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public object ExecuteScalar()
        {
            object result = null;

            try
            {
                OpenConnection();
                result = cmd.ExecuteScalar();

            }
            catch (Exception )
            {


            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
        public void AddParameter(SqlCommand cmd, SqlParameter[] sqlParameters)
        {

            cmd.Parameters.AddRange(sqlParameters);

        }
        public void AddParameter(SqlParameter[] sqlParameters)
        {

            cmd.Parameters.AddRange(sqlParameters);

        }




    }
}
