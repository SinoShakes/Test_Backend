using Microsoft.AspNetCore.Mvc;
using Test_Back.DATA.DTOs;
using Test_Back.DATA.Interfaces;

namespace Test_Backend.Endpoints;

public static class TodosEndpoints
{
    public static void TodosEndpoint(this IEndpointRouteBuilder app)
    {
        var todos = app.MapGroup("todos");

        #region get todos
        todos.MapGet("/gettodos", GetTodos);
        todos.MapGet("/todo", GetTodo);

        // https://www.localhost.8080/todos/todo
        #endregion


        todos.MapPost("/upsert-todos", SaveTodo);
        todos.MapDelete("Delete", DeleteTodo);
    }

    #region get todos
    public async static Task<IResult> GetTodos([FromServices] ITodoService service)
    {
        try
        {
            var output = await service.GetTodos();
            return Results.Ok(output);
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async static Task<IResult> GetTodo([FromQuery] long todo_PK, [FromServices] ITodoService service)
    {
        try
        {
            var output = await service.GetTodo(todo_PK);
            return Results.Ok(output);
        }
        catch (Exception)
        {

            throw;
        }
    }
    #endregion
    public async static Task SaveTodo(HttpContext todosform,[FromServices] ITodoService service)
    {
        var formData = todosform.Request.Form;
        
        try
        {
            var todos = new UpsertTodoDTO
            {
                Task = formData["Task"].FirstOrDefault()
            };

            await service.SaveTodo(todos);
            Results.Ok();
        }
        catch (Exception)
        {

            throw;
        }
    } 
    public async static Task SaveTodos([FromBody] List<UpsertTodoDTO> todos,[FromServices] ITodoService service)
    {
        try
        {
            await service.SaveTodos(todos);
            Results.Ok();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async static Task<IResult> DeleteTodo([FromQuery] long todo_PK, [FromServices] ITodoService service)
    {
        try
        {
            await service.DeleteTodo(todo_PK);
            return Results.Ok();
        }
        catch (Exception)
        {

            throw;
        }
    }
}
