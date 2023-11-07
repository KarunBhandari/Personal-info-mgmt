using System.Data;
using System.Data.SqlClient;

namespace CoreAPIDemo.Utilities
{
    public static class Helper
    {
        public static string ExecuteProcedureReturnString<T>(string connString, string procName, params SqlParameter[] parameters)
        {
            string result = null;
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procName;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    sqlConnection.Open();
                    var ret = cmd.ExecuteScalar();
                    if (ret != null)
                    {
                        result = Convert.ToString(ret);
                    }
                }
            }
            return result;
        }


        public static TData ExecuteProcedureReturnData<TData>(string connstring, string procName, Func<SqlDataReader, TData> translator, params SqlParameter[] parameters)
        {
            using (var sqlConnection = new SqlConnection(connstring))
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = procName;
                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters);
                    }
                    sqlConnection.Open();
                    using (var ret = sqlCommand.ExecuteReader())
                    {
                        TData elements;
                        try
                        {
                            elements = translator(ret);

                        }
                        finally
                        {
                            while (ret.NextResult())
                            { }
                        }
                        return elements;
                    }

                }
            }
        }

        //methods to get values of individual columns
        #region Get Values from SQL Data Reader
        public static String GetNullableString(SqlDataReader reader, string colName) {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? null : Convert.ToString(reader[colName]);
        }

        public static int GetNullableInt32(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? 0: Convert.ToInt32(reader[colName]);
        }

        public static bool GetBoolean(SqlDataReader reader, string colName)
        {
            return !reader.IsDBNull(reader.GetOrdinal(colName)) && Convert.ToBoolean(reader[colName]);
        }

        //this method is to check wheater column exists or not in data reader
        public static bool IsColumnExists(this System.Data.IDataRecord dr, string colName)
        {
            try
            {
                return (dr.GetOrdinal(colName) >= 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

    }

}