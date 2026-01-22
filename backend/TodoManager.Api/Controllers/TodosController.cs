using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TodoManager.Api.Data;
using TodoManager.Api.Models;

namespace TodoManager.Api.Controllers;

[ApiController]
[Route("todos")]
public class TodosController : ControllerBase
{
    private readonly AppDbContext _context;

    public TodosController(AppDbContext context)
    {
        _context = context;
    }

    // LISTAR TODOS
    // GET http://localhost:5000/todos
    [HttpGet]
    public IActionResult GetTodos()
    {
        return Ok(_context.Todos.ToList());
    }

    // BUSCAR POR ID
    // GET http://localhost:5000/todos/1
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo == null) return NotFound();
        return Ok(todo);
    }

    // SINCRONIZAR COM API EXTERNA
    // POST http://localhost:5000/todos/sync
    [HttpPost("sync")]
    public async Task<IActionResult> SyncTodos()
    {
        using var http = new HttpClient();
        var response = await http.GetStringAsync(
            "https://jsonplaceholder.typicode.com/todos"
        );

        var todos = JsonSerializer.Deserialize<List<Todo>>(response);

        _context.Todos.AddRange(todos);
        await _context.SaveChangesAsync();

        return Ok("Sincronização concluída");
    }
}