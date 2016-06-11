using ProjetoDDD.Domain.Interfaces.Infrastructure;
using ProjetoDDD.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProjetoDDD.Infrastructure.Data.Confinguration
{
    public class GerenciadorDeRepositorio : IGerenciadorDeRepositorio
    {
        public const string ContextoHttp = "ContextoHttp";

        public ContextoBanco Contexto
        {
            get
            {
                if (HttpContext.Current.Items[ContextoHttp] == null)
                    HttpContext.Current.Items[ContextoHttp] = new ContextoBanco();
                return HttpContext.Current.Items[ContextoHttp] as ContextoBanco;
            }
        }

        public void Finalizar()
        {
            if (HttpContext.Current.Items[ContextoHttp] != null)
                (HttpContext.Current.Items[ContextoHttp] as ContextoBanco).Dispose();
        }
    }
}
