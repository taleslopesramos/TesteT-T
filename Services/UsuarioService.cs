using DAL.Models;
using DAL.Repository;
using Services.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public bool Add(UsuarioCreateModel usuario)
        {
            if (usuario == null) return false;
            if (usuario.Senha != usuario.SenhaConfirmacao) return false;

            Usuario usuarioInsert = new Usuario()
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha),
                Nome = usuario.Nome,
                RG = usuario.RG,
            };

            try
            {
                _usuarioRepository.Add(usuarioInsert);
                return true;
            }
            catch (Exception ex)
            {
                _usuarioRepository.LogError(usuarioInsert, ex.Message);
                return false;
            }
        }

        public IEnumerable<Usuario> Get(Expression<Func<Usuario, bool>> predicate)
        {
            return _usuarioRepository.Get(predicate);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepository.GetAll();
        }

        public Usuario? GetById(int id)
        {
            return _usuarioRepository.GetById(id);
        }

        public bool Remove(int id)
        {
            Usuario? usuario = _usuarioRepository.GetById(id);
            if(usuario == null)     
                return false;
            try
            {
                _usuarioRepository.Delete(usuario);
            }
            catch(Exception ex)
            {
                _usuarioRepository.LogError(usuario, ex.Message);
                return false;
            }
            return true;
        }

        public bool Update(UsuarioEditModel usuario)
        {
            if (usuario == null) return false;
            if (usuario.Senha != usuario.SenhaConfirmacao) return false;
            
            Usuario? usuarioBanco = _usuarioRepository.GetById(usuario.Id);
            
            if (usuarioBanco == null) return false;

            if(!BCrypt.Net.BCrypt.Verify(usuario.SenhaAntiga, usuarioBanco.Senha)) return false;
            usuarioBanco.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            usuarioBanco.RG = usuario.RG;
            usuarioBanco.Nome = usuario.Nome;   
            
            try
            {
                _usuarioRepository.Edit(usuarioBanco);
            }
            catch (Exception ex)
            {
                _usuarioRepository.LogError(usuarioBanco, ex.Message);
                return false;
            }
            
            return true;
        }
    }
}
