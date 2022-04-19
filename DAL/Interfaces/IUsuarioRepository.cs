using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IUsuarioRepository
    {
        Usuario? GetById(int id);
        IQueryable<Usuario> GetAll();
        IQueryable<Usuario> Get(Expression<Func<Usuario, bool>> predicate);
        void Add(Usuario usuario);
        void Delete(Usuario usuario);
        void Edit(Usuario usuario);
        void LogError(Usuario usuario, string message);
    }
}
