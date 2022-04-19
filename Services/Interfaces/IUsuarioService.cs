using DAL.Models;
using DAL.Repository;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUsuarioService
    {
        public bool Add(UsuarioCreateModel usuario);
        public bool Update(UsuarioEditModel usuario);
        public bool Remove(int id);
        public Usuario? GetById(int id);
        public IEnumerable<Usuario> GetAll();
        public IEnumerable<Usuario> Get(Expression<Func<Usuario, bool>> predicate);
    }
}
