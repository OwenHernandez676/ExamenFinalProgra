using FinalExamn.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Usuario> usuarios { get; set; }
    public DbSet<Tarea> tareas { get; set; }
}
