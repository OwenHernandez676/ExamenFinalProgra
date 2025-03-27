using FinalExamn.Models; // Asegúrate de tener definido el modelo Tarea y, si es necesario, Usuario.
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalExamn.Services
{
    public class TareaService
    {
        private readonly ApplicationDbContext _context;

        public TareaService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtiene todas las tareas, incluyendo la información del usuario relacionado.
        public async Task<IEnumerable<Tarea>> GetAllAsync()
        {
            return await _context.tareas
                .ToListAsync();
        }

        // Crea una nueva tarea y la guarda en la base de datos.
        public async Task<Tarea> CreateAsync(Tarea tarea)
        {
            _context.tareas.Add(tarea);
            await _context.SaveChangesAsync();
            return tarea;
        }

        // Actualiza una tarea existente.
        // Retorna la tarea actualizada o null si no se encontró.
        public async Task<Tarea?> UpdateAsync(Tarea tarea)
        {
            var tareaExistente = await _context.tareas.FindAsync(tarea.Id);
            if (tareaExistente == null)
                return null;

            // Actualiza las propiedades deseadas.
            tareaExistente.Descripcion = tarea.Descripcion;
            // Agrega aquí la actualización de otras propiedades si es necesario.
            
            _context.tareas.Update(tareaExistente);
            await _context.SaveChangesAsync();
            return tareaExistente;
        }

        // Elimina una tarea por su ID.
        // Retorna true si se eliminó correctamente, o false si no se encontró.
        public async Task<bool> DeleteAsync(int id)
        {
            var tarea = await _context.tareas.FindAsync(id);
            if (tarea == null)
                return false;

            _context.tareas.Remove(tarea);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
