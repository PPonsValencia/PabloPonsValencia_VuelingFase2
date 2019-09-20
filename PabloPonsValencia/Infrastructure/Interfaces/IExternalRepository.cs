using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IExternalRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync();
    }
}
