using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DbTask : IDbTask
    {
        /// <summary>
        /// Insert records in Db table
        /// </summary>
        /// <param name="Procedure">expects sql store procedure name</param>
        /// <param name="ConnectionString">expects db connection string</param>
        /// <param name="DbSqlParameters">expects sql parameters</param>
        /// <returns>if inserted the return true else false</returns>
        public bool Insert(string Procedure, string ConnectionString, List<SqlParameter> DbSqlParameters)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var oSqlCommand = new SqlCommand(Procedure, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (var Parameter in DbSqlParameters) { oSqlCommand.Parameters.Add(Parameter); }
                oSqlCommand.ExecuteNonQuery();
                var Value = oSqlCommand.Parameters["ReturnValue"].Value;
                sqlConnection.Close();
                return Convert.ToBoolean(Value);
            }
        }
        /// <summary>
        /// Insert records in Db table
        /// </summary>
        /// <param name="Procedure">expects sql store procedure name</param>
        /// <param name="ConnectionString">expects db connection string</param>
        /// <param name="DbSqlParameters">expects sql parameters</param>
        /// <returns>if inserted the return actual ReturnValue</returns>
        public string InsertAndGetReturnValue(string Procedure, string ConnectionString, List<SqlParameter> DbSqlParameters)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var oSqlCommand = new SqlCommand(Procedure, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (var Parameter in DbSqlParameters) { oSqlCommand.Parameters.Add(Parameter); }
                oSqlCommand.ExecuteNonQuery();
                var Value = oSqlCommand.Parameters["ReturnValue"].Value;
                sqlConnection.Close();
                return Convert.ToString(Value);
            }
        }
        /// <summary>
        /// updates records in Db table
        /// </summary>
        /// <param name="Procedure">expects sql store procedure name</param>
        /// <param name="ConnectionString">expects db connection string</param>
        /// <param name="DbSqlParameters">expects sql parameters</param>
        /// <returns>if inserted the return true else false</returns>
        public bool Update(string Procedure, string ConnectionString, List<SqlParameter> DbSqlParameters)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var oSqlCommand = new SqlCommand(Procedure, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (var Parameter in DbSqlParameters) { oSqlCommand.Parameters.Add(Parameter); }
                oSqlCommand.ExecuteNonQuery();
                var Value = oSqlCommand.Parameters["ReturnValue"].Value;
                sqlConnection.Close();
                return Convert.ToBoolean(Value);
            }
        }
        /// <summary>
        /// updates records in Db table
        /// </summary>
        /// <param name="Procedure">expects sql store procedure name</param>
        /// <param name="ConnectionString">expects db connection string</param>
        /// <param name="DbSqlParameters">expects sql parameters</param>
        /// <returns>if inserted the return actual ReturnValue</returns>
        public string UpdateAndGetReturnValue(string Procedure, string ConnectionString, List<SqlParameter> DbSqlParameters)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var oSqlCommand = new SqlCommand(Procedure, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (var Parameter in DbSqlParameters) { oSqlCommand.Parameters.Add(Parameter); }
                oSqlCommand.ExecuteNonQuery();
                var Value = oSqlCommand.Parameters["ReturnValue"].Value;
                sqlConnection.Close();
                return Convert.ToString(Value);
            }
        }
        /// <summary>
        /// delete records in Db table
        /// </summary>
        /// <param name="Procedure">expects sql store procedure name</param>
        /// <param name="ConnectionString">expects db connection string</param>
        /// <param name="DbSqlParameters">expects sql parameters</param>
        /// <returns>if inserted the return true else false</returns>
        public bool Delete(string Procedure, string ConnectionString, List<SqlParameter> DbSqlParameters)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var oSqlCommand = new SqlCommand(Procedure, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (var Parameter in DbSqlParameters) { oSqlCommand.Parameters.Add(Parameter); }
                oSqlCommand.ExecuteNonQuery();
                var Value = oSqlCommand.Parameters["ReturnValue"].Value;
                sqlConnection.Close();
                return Convert.ToBoolean(Value);
            }
        }
        /// <summary>
        /// Fetch the single matching record
        /// </summary>
        /// <param name="Procedure"></param>
        /// <param name="ConnectionString">db connection string</param>
        /// <param name="Attributes">expects the sql column list</param>
        /// <returns>return json serialized string</returns>
        public string Select(string Procedure, string ConnectionString, List<string> Attributes)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var oSqlCommand = new SqlCommand(Procedure, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var sqlDataReader = oSqlCommand.ExecuteReader(CommandBehavior.SingleResult);
                var ColumnList = new List<Dictionary<string, object>>();
                while (sqlDataReader.Read())
                {
                    var Columns = new Dictionary<string, object>();
                    foreach (var Column in Attributes)
                    {
                        Columns.Add(Column, sqlDataReader[Column]);
                    }
                    ColumnList.Add(Columns);
                }
                sqlConnection.Close();
                return JsonConvert.SerializeObject(ColumnList, Formatting.Indented);
            }
        }
        /// <summary>
        /// Fetch the single matching record
        /// </summary>
        /// <param name="Procedure"></param>
        /// <param name="ConnectionString">db connection string</param>
        /// <param name="Attributes">expects the sql column list</param>
        /// <param name="DbSqlParameters">expects sql parameters</param>
        /// <returns>return json serialized string</returns>
        public string Select(string Procedure, string ConnectionString, List<string> Attributes, List<SqlParameter> DbSqlParameters)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var oSqlCommand = new SqlCommand(Procedure, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (var Parameter in DbSqlParameters) { oSqlCommand.Parameters.Add(Parameter); }
                var sqlDataReader = oSqlCommand.ExecuteReader(CommandBehavior.SingleResult);
                var ColumnList = new List<Dictionary<string, object>>();
                while (sqlDataReader.Read())
                {
                    var Columns = new Dictionary<string, object>();
                    foreach (var Column in Attributes)
                    {
                        Columns.Add(Column, sqlDataReader[Column]);
                    }
                    ColumnList.Add(Columns);
                }
                sqlConnection.Close();
                return JsonConvert.SerializeObject(ColumnList, Formatting.Indented);
            }
        }
        /// <summary>
        /// used for validation and return a single result if record exist 
        /// </summary>
        /// <param name="ConnectionString">db connection string</param>
        /// <param name="Attributes">expects the sql column list</param>
        /// <returns>return json serialized string if match found</returns>
        public string Check(string Procedure, string ConnectionString, List<string> Attributes)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var oSqlCommand = new SqlCommand(Procedure, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var sqlDataReader = oSqlCommand.ExecuteReader(CommandBehavior.SingleResult);
                var Columns = new Dictionary<string, object>();
                if (sqlDataReader.Read())
                {
                    foreach (var Column in Attributes)
                    {
                        Columns.Add(Column, sqlDataReader[Column]);
                    }
                }
                sqlConnection.Close();
                return JsonConvert.SerializeObject(Columns, Formatting.Indented);
            }
        }
        /// <summary>
        /// used for validation and return a single result if record exist 
        /// </summary>
        /// <param name="ConnectionString">db connection string</param>
        /// <param name="Attributes">expects the sql column list</param>
        /// <param name="DbSqlParameters">expects sql parameters</param>
        /// <returns>return json serialized string if match found</returns>
        public string Check(string Procedure, string ConnectionString, List<string> Attributes, List<SqlParameter> DbSqlParameters)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var oSqlCommand = new SqlCommand(Procedure, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (var Parameter in DbSqlParameters) { oSqlCommand.Parameters.Add(Parameter); }
                var sqlDataReader = oSqlCommand.ExecuteReader(CommandBehavior.SingleResult);
                var Columns = new Dictionary<string, object>();
                if (sqlDataReader.Read())
                {
                    foreach (var Column in Attributes)
                    {
                        Columns.Add(Column, sqlDataReader[Column]);
                    }
                }
                sqlConnection.Close();
                return JsonConvert.SerializeObject(Columns, Formatting.Indented);
            }
        }
    }
}
