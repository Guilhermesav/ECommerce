using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Model.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task CommitAsync();
    }
}
