using ProjetoDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoDDD.Domain.Interfaces.Repositories
{
    public interface IRepositorioDePerfilDeUsuario : IRepositorioBase<PerfilUsuario>
    {
        List<Usuario> RetornaUsuariosDoPerfil(int idPerfilUsuario);
    }
}
