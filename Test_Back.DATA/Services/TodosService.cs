using Test_Back.DATA.DTOs;
using Test_Back.DATA.Interfaces;

namespace Test_Back.DATA.Services;

public class TodosService(IDBDataAccess db) : ITodoService
{
    private readonly IDBDataAccess db = db;

    public async Task<List<TodoDTO>> GetTodos()
    {
        string sql = "dbo.ToDo";

        var res = await db.QueryData<TodoDTO, dynamic>(sql, new { Proc_Option = "Get_ToDos" });

        return res;
    }

    public async Task DeleteTodo(long todo_PK)
    {
        string sql = "dbo.ToDo";

        await db.QueryData<TodoDTO, dynamic>(sql, new { Proc_Option = "Delete", ToDo_FK = todo_PK });
    }

    public async Task<TodoDTO> GetTodo(long todo_PK)
    {
        string sql = "dbo.ToDo";

        var res = await db.QueryRecord<TodoDTO, dynamic>(sql, new {Proc_Option = "Get_ToDo",ToDo_FK = todo_PK });

        return res;
    }

    public async Task SaveTodo(UpsertTodoDTO todos)
    {
        string sql = "dbo.ToDo";

        await db.SaveRecord(sql, todos);
    }

    public async Task SaveTodos(List<UpsertTodoDTO> todos)
    {
        string sql = "dbo.ToDo";

        await db.SaveRecord(sql, todos);
    }
}
