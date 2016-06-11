using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDD.Domain.Entities
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdPerfilUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string SenhaKey { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual PerfilUsuario PerfilUsuario { get; set; }
    }
}
