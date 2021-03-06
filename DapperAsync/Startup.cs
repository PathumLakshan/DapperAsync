﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.GenericRepository.Classes;
using DapperAsync.Repositories;
using DapperAsync.Repositories.IRepositories;
using GenericRepository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DapperAsync
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
            services.AddTransient<IRepoPayment, PaymentRepo>();
            services.AddTransient<IRepoCandidate, CandidateRepo>();
            services.AddTransient<IRepoOwner, OwnerRepo>();
            services.AddTransient<IRepoVehicle, VehicleRepo>();

           services.AddTransient<IRepoTrainee, TraineeRepo>();
           /*  services.AddTransient<IRepoCandidate, CandidateRepo>();
            services.AddTransient<IRepoCandidate, CandidateRepo>();*/


            //services.AddTransient<IRepository<T>, Repository<T>>() where T: class;


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
