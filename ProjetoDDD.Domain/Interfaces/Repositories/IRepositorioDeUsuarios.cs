using ProjetoDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDD.Domain.Interfaces.Repositories
{
    public interface IRepositorioDeUsuarios : IRepositorioBase<Usuario>
    {
        Usuario RecuperarUsuarioPorEmail(string email);
        Usuario LogaUsuario(string email, string senha);
        Usuario CadastraUsuario(Usuario user);
    }
}
