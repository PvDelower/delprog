using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalonDel.Model;

namespace API
{
    public class UnitOfWork : IDisposable
    {
        private readonly SalonJDMContext context;
        private bool disposed;
        private Dictionary<string, object> repositories;

        public UnitOfWork(SalonJDMContext context)
        {
            this.context = context;
        }

        public UnitOfWork()
        {
            context = new SalonJDMContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        public Repository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(TEntity).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (Repository<TEntity>)repositories[type];
        }
    }

}
