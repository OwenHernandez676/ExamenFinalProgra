using FinalExamn.Data;
using FinalExamn.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalExamn.Services
{
    public class UsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listar todos los usuarios
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // Crear un nuevo usuario
        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        // Actualizar un usuario existente
        public async Task<Usuario?> UpdateAsync(Usuario usuario)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(usuario.Id);
            if (usuarioExistente == null)
                return null;

            usuarioExistente.Nombre = usuario.Nombre;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.Contrasena = usuario.Contrasena;

            _context.Usuarios.Update(usuarioExistente);
            await _context.SaveChangesAsync();
            return usuarioExistente;
        }

        // Eliminar un usuario por ID
        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
