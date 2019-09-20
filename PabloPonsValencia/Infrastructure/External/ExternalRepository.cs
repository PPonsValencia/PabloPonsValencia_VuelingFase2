using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.External
{
    public class ExternalRepository<TEntity> : IExternalRepository<TEntity>
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        private readonly IConfiguration _config;

        private string url;

        public ExternalRepository(HttpClient client, ILogger<ExternalRepository<TEntity>> logger, IConfiguration config)
        {
            _client = client;
            _logger = logger;
            _config = config;
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            IEnumerable<TEntity> entities = null;

            try
            {
                url = _config.GetValue<string>(typeof(TEntity).Name + "URL");

                var response = await _client.GetAsync(url).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    entities = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(json);
                }
            }
            catch (Exception err)
            {
                _logger?.LogWarning("External repository exception: " + err.Message);

                return null;
            }

            return entities;
        }
    }
}
