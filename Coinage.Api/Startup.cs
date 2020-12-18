using System;
using System.Collections.Generic;
using System.Linq;
using Coinage.Api.Extensions.MemoryCache;
using Coinage.Api.Models;
using Coinage.Api.Services;
using Coinage.Core.Classes;
using Coinage.Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Coinage.Api
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
            services.AddControllersWithViews();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            //dataservice registration
            services.AddSingleton<IVolumeConstantsDataService>(new VolumeConstantsDataService<VolumeConstants>("Data/VolumeConstants.json"));
            services.AddSingleton<IDimensionDataService<ICircularCoinDimension>>(new DimensionsDataService<IEnumerable<CircularDimensions>>("Data/Dimensions.json", "US"));

            //Coin jar and coin factory service registration
            services.AddSingleton<ICoinFactory>(x => 
                new CircularCoinFactory(x.GetRequiredService<IDimensionDataService<ICircularCoinDimension>>()));
            services.AddSingleton<ICoinJar>(x => 
                new CoinJar(x.GetRequiredService<IMemoryCache>().Initialize(x.GetRequiredService<IVolumeConstantsDataService>())));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseMvc();
        }
    }
}
