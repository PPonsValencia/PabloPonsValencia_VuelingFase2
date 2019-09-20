using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence
{
    public class PersistenceRepository<TEntity> : IPersistenceRepository<TEntity> where TEntity : class
    {
        private readonly GoliathDbContext _context;
        private readonly ILogger _logger;

        public PersistenceRepository(GoliathDbContext context, ILogger<PersistenceRepository<TEntity>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            var entitiesList = entities.ToList();

            try
            {
                _context.Database.EnsureCreated();
                _context.RemoveRange(_context.Set<TEntity>());
                _context.AddRange(entitiesList);
                _context.SaveChanges();
            }
            catch (Exception err)
            {
                _logger?.LogError("Persistence repository exception: " + err.Message);
            }
        }

        public IEnumerable<TEntity> Get()
        {
            IEnumerable<TEntity> entities;

            try
            {
                entities = _context.Set<TEntity>();
            }
            catch (Exception err)
            {
                _logger?.LogError("Persistence repository exception: " + err.Message);

                return null;
            }

            return entities;
        }
    }
}
