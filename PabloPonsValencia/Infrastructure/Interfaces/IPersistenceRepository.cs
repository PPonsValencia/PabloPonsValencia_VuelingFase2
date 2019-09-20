using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces
{
    public interface IPersistenceRepository<TEntity>
    {
        void AddRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> Get();
    }
}
