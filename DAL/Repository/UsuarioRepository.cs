using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<Usuario> _logger;
        public UsuarioRepository(AppDbContext dbContext)
        {
            _context = dbContext;
            _logger = new DbLogger<Usuario>(_context);
        }

        public void Add(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.Ativo = true;
            _context.Add<Usuario>(usuario);
            _logger.LogAdd(usuario);
            _context.SaveChanges();
        }

        public void Delete(Usuario usuario)
        {
            _context.Remove<Usuario>(usuario);
            _logger.LogRemove(usuario);
            _context.SaveChanges();
        }

        public void Edit(Usuario usuario)
        {
            _context.Entry<Usuario>(usuario).State = EntityState.Modified;
            _logger.LogUpdate(usuario);
            _context.SaveChanges();
        }

        public IQueryable<Usuario> Get(Expression<Func<Usuario, bool>> predicate)
        {
            return _context.Usuarios.Where(predicate);
        }

        public IQueryable<Usuario> GetAll() => _context.Usuarios.AsQueryable();

        public Usuario? GetById(int id) => _context.Usuarios.Find(id);

        public void LogError(Usuario usuario, string message)
        {
            _logger.LogError(usuario, message);
        }
    }
}
