using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IExternalRepository<TEntity> _external;
        private readonly IPersistenceRepository<TEntity> _persistence;
        private readonly ILogger _logger;

        public Repository(IExternalRepository<TEntity> external, IPersistenceRepository<TEntity> persistence, ILogger<Repository<TEntity>> logger)
        {
            _external = external;
            _persistence = persistence;
            _logger = logger;
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            IEnumerable<TEntity> entities = null;

            entities = await _external.GetAsync().ConfigureAwait(false);
            if (entities != null)
            {
                _persistence.AddRange(entities);
            }
            else
            {
                entities = _persistence.Get();
            }

            return entities;
        }
    }
}
