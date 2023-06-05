using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public interface IDbTask
    {
        /// <summary>
        /// Insert records in Db table
        /// </summary>
        /// <param name="Procedure">expects sql store procedure name</param>
        /// <param name="ConnectionString">expects db connection string</param>
        /// <param name="DbSqlParameters">expects sql parameters</param>
        /// <returns>if inserted the return true else false</returns>
        bool Insert(string Procedure, string ConnectionString, List<SqlParameter> DbSqlParameters);
        /// <summary>
        /// Insert records in Db table
        /// </summary>
        /// <param name="Procedure">expects sql store procedure name</param>
        /// <param name="ConnectionString">expects db connection string</param>
        /// <param name="DbSqlParameters">expects sql parameters</param>
        /// <returns>if inserted the return actual ReturnValue</returns>
        string InsertAndGetReturnValue(string Procedure, string ConnectionString, List<SqlParameter> DbSqlParameters);
        /// <summary>
        /// updates records in Db table
        /// </summary>
        /// <param name="Procedure">expects sql store procedure name</param>
        /// <param name="ConnectionString">expects db connection string</param>
        /// <param name="DbSqlParameters">expects sql parameters</param>
        /// <returns>if inserted the return true else false</returns>
        bool Update(string Procedure, string ConnectionString, List<SqlParameter> DbSqlParameters);
        /// <summary>
        /// updates records in Db table
        /// </summary>
        /// <param name="Procedure">expects sql store procedure name</param>
        /// <param name="ConnectionString">expects db connection string</param>
        /// <param name="DbSqlParameters">expects sql parameters</param>
        /// <returns>if inserted the return actual ReturnValue</returns>
        string UpdateAndGetReturnValue(string Procedure, string ConnectionString, List<SqlParameter> DbSqlParameters);
        /// <summary>
        /// delete records in Db table
        /// </summary>
        /// <param name="Procedure">expects sql store procedure name</param>
        /// <param name="ConnectionString">expects db connection string</param>
        /// <param name="DbSqlParameters">expects sql parameters</param>
        /// <returns>if inserted the return true else false</returns>
        bool Delete(string Procedure, string ConnectionString, List<SqlParameter> DbSqlParameters);
        /// <summary>
        /// Fetch the single matching record
        /// </summary>
        /// <param name="Procedure"></param>
        /// <param name="ConnectionString">db connection string</param>
        /// <param name="Attributes">expects the sql column list</param>
        /// <returns>return json serialized string</returns>
        string Select(string Procedure, string ConnectionString, List<string> Attributes);
        /// <summary>
        /// Fetch the single matching record
        /// </summary>
        /// <param name="Procedure"></param>
        /// <param name="ConnectionString">db connection string</param>
        /// <param name="Attributes">expects the sql column list</param>
        /// <param name="DbSqlParameters">expects sql parameters</param>
        /// <returns>return json serialized string</returns>
        string Select(string Procedure, string ConnectionString, List<string> Attributes, List<SqlParameter> DbSqlParameters);

        /// <summary>
        /// used for validation and return a single result if record exist 
        /// </summary>
        /// <param name="ConnectionString">db connection string</param>
        /// <param name="Attributes">expects the sql column list</param>
        /// <returns>return json serialized string if match found</returns>string Check(string Procedure, string ConnectionString, List<string> Attributes);
        string Check(string Procedure, string ConnectionString, List<string> Attributes, List<SqlParameter> DbSqlParameters);
    }
}
