﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SisifoNotes.Lib.Core.Interfaces;
using SisifoNotes.Lib.DA.EFCore;
using SisifoNotes.Lib.DA.EFCore.ModelsDbSets;
using SisifoNotes.Lib.Models;
using SisifoNotes.Web.Helpers;
using SisifoNotes.Lib.DAL;
using SisifoNotes.Lib.Core;
using SisifoNotes.Lib.Server.Services;
using SisifoNotes.Lib.Services.Interfaces;
using SisifoNotes.Web.Security;
using SisifoNotes.Web.Controllers;


namespace SisifoNotes.Web
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
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddDbContext<SisifoNotesContext>(options => options.UseSqlServer(appSettings.DbConnection,
                b => b.MigrationsAssembly("SisifoNotes.Web")));

            InjectDependencies(services);

            // configure jwt authentication
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void InjectDependencies (IServiceCollection services)
        {
            // DbSets
            services.AddScoped<IDbSet<Client>, ClientsDbSet>();
            services.AddScoped<IDbSet<Note>, NotesDbSet>();
            services.AddScoped<IDbSet<User>, UsersDbSet>();
            services.AddScoped<IDbSet<Event>, EventsDbSet>();

            // Repositories
            services.AddScoped<IRepository<Client>, GenericRepository<Client>>();
            services.AddScoped<IRepository<Note>, GenericRepository<Note>>();
            services.AddScoped<IRepository<User>, GenericRepository<User>>();
            services.AddScoped<IRepository<Event>, GenericRepository<Event>>();

            // Crud Services
            services.AddScoped<ICrudService<Client>, GenericCrudService<Client>>();
            services.AddScoped<ICrudService<Note>, GenericCrudService<Note>>();
            services.AddScoped<ICrudService<User>, GenericCrudService<User>>();
            services.AddScoped<ICrudService<Event>, GenericCrudService<Event>>();

            // Other Services

            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, JwtLoginService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
