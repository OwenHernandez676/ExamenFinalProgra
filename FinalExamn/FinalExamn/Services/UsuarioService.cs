using FinalExamn.Models; // Asegúrate de tener definido el modelo Usuario
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalExamn.Services
{
    public class UsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtiene todos los usuarios
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.usuarios.ToListAsync();
        }

        // Crea un nuevo usuario y lo guarda en la base de datos
        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _context.usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        // Actualiza un usuario existente
        // Retorna el usuario actualizado o null si no se encuentra
        public async Task<Usuario?> UpdateAsync(Usuario usuario)
        {
            var usuarioExistente = await _context.usuarios.FindAsync(usuario.Id);
            if (usuarioExistente == null)
                return null;

            // Actualiza las propiedades deseadas
            usuarioExistente.Nombre = usuario.Nombre;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.Contrasena = usuario.Contrasena;
            // Actualiza otras propiedades si es necesario

            _context.usuarios.Update(usuarioExistente);
            await _context.SaveChangesAsync();
            return usuarioExistente;
        }

        // Elimina un usuario por su ID
        // Retorna true si se eliminó correctamente, o false si no se encontró
        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.usuarios.FindAsync(id);
            if (usuario == null)
                return false;

            _context.usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
