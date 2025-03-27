using FinalExamn.Data;
using FinalExamn.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalExamn.Services
{
    public class TareaService
    {
        private readonly ApplicationDbContext _context;

        public TareaService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listar todas las tareas
        public async Task<IEnumerable<Tarea>> GetAllAsync()
        {
            return await _context.Tareas.ToListAsync();
        }

        // Crear una nueva tarea
        public async Task<Tarea> CreateAsync(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
            return tarea;
        }

        // Actualizar una tarea existente
        public async Task<Tarea?> UpdateAsync(Tarea tarea)
        {
            var tareaExistente = await _context.Tareas.FindAsync(tarea.Id);
            if (tareaExistente == null) 
                return null;

            tareaExistente.Descripcion = tarea.Descripcion;

            _context.Tareas.Update(tareaExistente);
            await _context.SaveChangesAsync();
            return tareaExistente;
        }

        // Eliminar una tarea por ID
        public async Task<bool> DeleteAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
                return false;

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
