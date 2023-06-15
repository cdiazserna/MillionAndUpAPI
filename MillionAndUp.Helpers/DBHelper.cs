using Dapper;
using Microsoft.Data.SqlClient;
using MillionAndUp.Helpers.Interfaces;
using MillionAndUp.Models;
using System.Data;
using System.Data.Common;

namespace MillionAndUp.Helpers
{
    public class DBHelper : IDBHelper
    {
        public async Task<List<T>> ExcecuteStoreProcedure<T>(
               string procedure,
               List<ExecuteParameter> objectParameters,
               string sconn
               )
        {
            var result = Activator.CreateInstance<List<T>>();

            using (DbConnection connection = new SqlConnection(sconn))
            {
                using (DbCommand cmd = connection.CreateCommand())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    foreach (var item in objectParameters)
                    {
                        parameters.Add(item.Name, item.Value);

                    }
                    result = (await connection.QueryAsync<T>(procedure, parameters, commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            return result;
        }


    }
}
