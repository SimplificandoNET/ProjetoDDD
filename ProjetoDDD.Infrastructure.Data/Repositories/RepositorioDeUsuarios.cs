using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repositories;
using ProjetoDDD.Infrastructure.Data.Security;
using System.Linq;
using System;

namespace ProjetoDDD.Infrastructure.Data.Repositories
{
    public class RepositorioDeUsuarios : RepositorioBase<Usuario>, IRepositorioDeUsuarios
    {
        public Usuario CadastraUsuario(Usuario user)
        {
            user.Senha = Crypto.EncryptStringAES(user.Senha, user.SenhaKey);
            return _contexto.Usuarios.Add(user);
        }

        public Usuario LogaUsuario(string email, string senha)
        {
            var usuario = _contexto.Usuarios.Where(u => u.Email == email).FirstOrDefault();
            if (usuario == null)
                return null;

            string passDecrypt = Crypto.DecryptStringAES(usuario.Senha, usuario.SenhaKey);

            if (passDecrypt == senha)
                return usuario;
                else return null;
        }

        public Usuario RecuperarUsuarioPorEmail(string email)
        {
            var usuario = _contexto.Usuarios.Where(u => u.Email == email).FirstOrDefault();
            return usuario;
        }
    }
}
