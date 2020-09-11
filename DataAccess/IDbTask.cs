using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public interface IDbTask
    {
        bool Insert(string Procedure, string ConnectionString, List<SqlParameter> DbSqlParameters);
        bool Update(string Procedure, string ConnectionString, List<SqlParameter> DbSqlParameters);
        bool Delete(string Procedure, string ConnectionString, List<SqlParameter> DbSqlParameters);
        string Select(string Procedure, string ConnectionString, List<string> Attributes);
        string Select(string Procedure, string ConnectionString, List<string> Attributes, List<SqlParameter> DbSqlParameters);
        string Check(string Procedure, string ConnectionString, List<string> Attributes);
        string Check(string Procedure, string ConnectionString, List<string> Attributes, List<SqlParameter> DbSqlParameters);
    }
}
