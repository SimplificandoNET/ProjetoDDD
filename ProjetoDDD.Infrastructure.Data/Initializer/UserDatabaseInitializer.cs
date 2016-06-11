using ProjetoDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDD.Infrastructure.Data.Initializer
{
    public class UserDatabaseInitializer
    {
        public static List<ModulosAcesso> GetModulosAcesso()
        {
            var modulos = new List<ModulosAcesso>
            {
                new ModulosAcesso
                {
                    IdModulo = 1,
                    FlAtivo = true,
                    NomeMenuAcesso = "Administração",
                    NomeModulo = "Admin",
                    UrlMenu = "#",
                    DataCadastro = DateTime.Now

                },
                new ModulosAcesso
                {
                    IdModulo = 2,
                    FlAtivo = true,
                    NomeMenuAcesso = "Cadastro",
                    NomeModulo = "Cadastro",
                    UrlMenu = "#",
                    DataCadastro = DateTime.Now,
                    IdModuloPai = 1
                },
                new ModulosAcesso
                {
                    IdModulo = 3,
                    FlAtivo = true,
                    NomeMenuAcesso = "Perfil de Usuário",
                    NomeModulo = "Perfil de Usuário",
                    UrlMenu = "#",
                    DataCadastro = DateTime.Now,
                    IdModuloPai = 2
                }
            };

            return modulos;
        }
        public static List<PerfilUsuario> GetPerfisUsuarios()
        {
            var perfisUsuario = new List<PerfilUsuario>
            {
                new PerfilUsuario
                {
                    IdPerfilUsuario = 1,
                    DataCadastro = DateTime.Now,
                    FlAdminMaster =true,
                    FlAtivo = true,
                    NomPerfil = "Administrador Master",
                    ModulosAcesso = GetModulosAcesso()
                }
            };
            return perfisUsuario;
        }
    }
}
