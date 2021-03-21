using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TransportExercise.Database
{
    public class DbOperations
    {
        private string connString;

        public DbOperations(string connectionString)
        {
            connString = connectionString;
        }

        //Select Single Row By Id
        public DataTable SelectSingleById(string stProc, int id)
        {
            const string idKey = "@id";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    var cmd = new SqlCommand(stProc, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(idKey, id);

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                DataTable dt = new DataTable();
                                dt.Load(reader);
                                return dt;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //log the error
                        return null;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return null;
        }

        public int InsertSingle(string stProc, Dictionary<string, object> parameterValues)
        {
            const string returnParmName = "@id";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    var cmd = new SqlCommand(stProc, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (var item in parameterValues)
                    {
                        cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }
                    cmd.Parameters.Add(returnParmName, SqlDbType.Int).Direction = ParameterDirection.Output;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return Convert.ToInt32(cmd.Parameters[returnParmName].Value);
                    }
                    catch(Exception ex)
                    {
                        //log the error
                        return 0;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return 0;
        }

    }
}
