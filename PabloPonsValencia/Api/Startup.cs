using Application.Interfaces;
using Application.Services;
using Domain.Algorithms.Interfaces;
using Domain.Algorithms.Services;
using Domain.Interfaces;
using Domain.Services;
using Infrastructure.External;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.AddScoped<IRatesService, RatesService>();
            services.AddScoped<ITransactionsService, TransactionsService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ITransactionFilterService, TransactionFilterService>();
            services.AddScoped<ITransactionBusinessService, TransactionBusinessService>();
            services.AddScoped<IGraphSolver, GraphSolver>();
            services.AddScoped<IAmountService, AmountService>();

            services.AddScoped(typeof(IExternalRepository<>), typeof(ExternalRepository<>));
            services.AddScoped(typeof(IPersistenceRepository<>), typeof(PersistenceRepository<>));
            services.AddScoped<HttpClient, HttpClient>();
            services.AddScoped<GoliathDbContext, GoliathDbContext>();

            services.AddDbContext<GoliathDbContext>(opt => {
                opt.UseSqlServer(Configuration.GetValue<string>("ConnectionString"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
