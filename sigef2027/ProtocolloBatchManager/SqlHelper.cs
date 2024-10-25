using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace ProtocolloBatchManager
{
    internal static class SqlHelper
    {
        internal delegate T GetItemFromReader<T>(SqlDataReader dataReader);
        internal delegate List<T> GetListFromReader<T>(SqlDataReader dataReader);

        internal static void AddWithValue2(this SqlParameterCollection parameters, string parameterName, object value)
        {
            parameters.AddWithValue(parameterName, value ?? DBNull.Value);
        }

        internal static List<T> ExecuteReaderCmd<T>(string connectionString, SqlCommand sqlCmd, GetItemFromReader<T> gifr)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw (new ArgumentNullException("ConnectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            List<T> temp = new List<T>();

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        T t = gifr(dr);
                        temp.Add(t);
                    }
                    dr.Close();
                }
            }
            return temp;
        }

        internal static T ExecuteReaderCmd<T>(GetItemFromReader<T> glfr, string connectionString, SqlCommand sqlCmd)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw (new ArgumentNullException("ConnectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            T temp = default(T);

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    if (dr.Read())
                        temp = glfr(dr);
                    dr.Close();
                }
            }
            return temp;
        }

        internal static object ExecuteScalarCmd(string connectionString, SqlCommand sqlCmd)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw (new ArgumentNullException("ConnectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            object result = null;


            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                result = sqlCmd.ExecuteScalar();
            }

            return result;
        }

        internal static void ExecuteNonQueryCmd(string connectionString, SqlCommand sqlCmd)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw (new ArgumentNullException("ConnectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                sqlCmd.ExecuteNonQuery();
            }

            return;
        }
    }
}
