using MillionAndUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MillionAndUp.Helpers.Interfaces
{
    public interface IDBHelper
    {
        Task<List<T>> ExcecuteStoreProcedure<T>(
               string procedure,
               List<ExecuteParameter> objectParameters,
               string sconn
               );
    }
}
