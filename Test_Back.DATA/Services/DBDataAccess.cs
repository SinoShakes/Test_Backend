using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Back.DATA.Interfaces;

namespace Test_Back.DATA.Services;

public class DBDataAccess(IConfiguration config) : IDBDataAccess
{
    private readonly string? connectionString = config.GetConnectionString("Default");
    public async Task<List<T>> QueryData<T, U>(string StoredProcedure, U parameters)
    {
        using IDbConnection connection = new SqlConnection(connectionString);
        var data = await connection.QueryAsync<T>(StoredProcedure, parameters, commandType: CommandType.StoredProcedure);
        return data.AsList();
    }

    public async Task<T> QueryRecord<T, U>(string sql, U parameters)
    {
        using IDbConnection connection = new SqlConnection(connectionString);
        var data = await connection.QueryFirstOrDefaultAsync<T>(sql, parameters, commandType: CommandType.StoredProcedure);
        return data;
    }

    public async Task SaveRecord<T>(string sql, T parameter)
    {
        using IDbConnection connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sql, parameter, commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteRecord<T>(string sql, T parameter)
    {
        using IDbConnection connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sql, parameter, commandType: CommandType.StoredProcedure);
    }
}
