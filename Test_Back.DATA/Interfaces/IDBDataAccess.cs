using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Back.DATA.Interfaces;

public interface IDBDataAccess
{
    Task DeleteRecord<T>(string sql, T parameter);
    Task SaveRecord<T>(string sql, T parameter);
    Task<T> QueryRecord<T, U>(string sql, U parameters);
    Task<List<T>> QueryData<T, U>(string StoredProcedure, U parameters);

}
