using System;
using System.Collections.Generic;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repositories;
using System.Linq;

namespace ProjetoDDD.Infrastructure.Data.Repositories
{
    public class RepositorioDePerfilDeUsuario : RepositorioBase<PerfilUsuario>, IRepositorioDePerfilDeUsuario
    {
        public List<Usuario> RetornaUsuariosDoPerfil(int idPerfilUsuario)
        {
            var perfil = _contexto.PerfilUsuario.Where(x => x.IdPerfilUsuario == idPerfilUsuario).FirstOrDefault();
            return perfil.Usuarios.ToList();
        }
    }
}
