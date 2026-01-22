using Microsoft.EntityFrameworkCore;
using TodoManager.Api.Models;

namespace TodoManager.Api.Data;

public class AppDbContext : DbContext
{
    public DbSet<TodoItem> Todos => Set<TodoItem>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}