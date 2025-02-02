﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Senai.Optus.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion
                (Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
                   c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                   {
                       Title = "Optus API",
                       Version = "v1"
                   })
            );

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                // definir as opcoes
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // quem esta solicitando
                    ValidateIssuer = true,
                    // quem esta validando
                    ValidateAudience = true,
                    // tempo de expiracao
                    ValidateLifetime = true,
                    // forma de criptografia
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Optus-chave-autenticacao")),
                    // tempo de expiracao
                    ClockSkew = TimeSpan.FromMinutes(30),
                    // quem esta enviando
                    ValidIssuer = "Optus.WebApi",
                    ValidAudience = "Optus.WebApi"
                };
            });
        }
    


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Optus API V1");
            }
                );
            app.UseMvc();
            app.UseAuthentication();
        }
    }
}
