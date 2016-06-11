using Microsoft.Practices.ServiceLocation;
using ProjetoDDD.Domain.Interfaces.Infrastructure;

namespace ProjetoDDD.Domain.Services
{
    public class ServicoDeDominioBase
    {
        private IUnidadeDeTrabalho _unidadeDeTrabalho;

        public virtual void IniciarTransação()
        {
            _unidadeDeTrabalho = ServiceLocator.Current.GetInstance<IUnidadeDeTrabalho>();
            _unidadeDeTrabalho.Iniciar();
        }

        public virtual void PersistirTransação()
        {
            _unidadeDeTrabalho.Persistir();
        }
    }
}
