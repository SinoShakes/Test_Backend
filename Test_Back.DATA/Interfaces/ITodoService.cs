using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Back.DATA.DTOs;
using static System.Net.WebRequestMethods;

namespace Test_Back.DATA.Interfaces;

public interface ITodoService
{
    Task DeleteTodo(long todo_PK);
    Task<TodoDTO> GetTodo(long todo_PK);
    Task<List<TodoDTO>> GetTodos();
    Task SaveTodo(UpsertTodoDTO todos);
    Task SaveTodos(List<UpsertTodoDTO> todos);
}
