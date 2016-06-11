using ProjetoDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDD.Domain.Interfaces.Domain
{
    public interface IServicoDeUsuarioDomain
    {
        Usuario LogaUsuario(string email, string senha);
        Usuario RecuperaUsuarioPorEmail(string email);
        List<Usuario> RecuperaUsuariosDoPerfil(int idPerfilUsuario);
        List<PerfilUsuario> RecuperaTodosPerfisAtivos();
        void CadastraUsuario(Usuario usuario);
    }
}
