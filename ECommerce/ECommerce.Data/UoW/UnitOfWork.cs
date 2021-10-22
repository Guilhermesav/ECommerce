using ECommerce.Model.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.UoW
{
    public class UnitOfWork: IUnitOfWork,IDisposable
    {
        private readonly ECommerceContext _eCommerceContext;
        private bool _disposed;

        public UnitOfWork(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public async Task CommitAsync()
        {
            await _eCommerceContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _eCommerceContext.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
