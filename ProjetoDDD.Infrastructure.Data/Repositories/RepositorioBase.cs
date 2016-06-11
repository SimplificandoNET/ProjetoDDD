using Microsoft.Practices.ServiceLocation;
using ProjetoDDD.Domain.Interfaces.Infrastructure;
using ProjetoDDD.Domain.Interfaces.Repositories;
using ProjetoDDD.Infrastructure.Data.Confinguration;
using ProjetoDDD.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjetoDDD.Infrastructure.Data.Repositories
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : class
    {
        protected readonly ContextoBanco _contexto;

        public RepositorioBase()
        {
            var gerenciador = (GerenciadorDeRepositorio)ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorio>();
            _contexto = gerenciador.Contexto;
        }

        public void Alterar(TEntidade obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
        }

        public void Inserir(TEntidade obj)
        {
            _contexto.Set<TEntidade>().Add(obj);
        }

        public TEntidade RecuperarPorID(int id)
        {
            return _contexto.Set<TEntidade>().Find(id);
        }

        public IList<TEntidade> RecuperarTodos()
        {
            return _contexto.Set<TEntidade>().ToList();
        }

        public void Remover(int id)
        {
            TEntidade obj = RecuperarPorID(id);
            Remover(obj);
        }

        public void Remover(TEntidade obj)
        {
            _contexto.Set<TEntidade>().Remove(obj);
        }        
    }
}
