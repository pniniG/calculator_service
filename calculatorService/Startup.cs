using BLL;
using DLL;

using calculatorService.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.HttpOverrides;

namespace calculatorService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped(typeof(ICalculator), typeof(Calculator));
            services.AddScoped(typeof(IListCalc), typeof(ListCalc));
            //services.AddDbContext<AuthDBContext>();
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //                .AddEntityFrameworkStores<AuthDBContext>()
            //                .AddDefaultTokenProviders();
            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<WorldContext>();
                            //services.Configure<IdentityOptions>(options =>
            //options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);

            services.AddSingleton<DB>();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("localhost",
                        "http://localhost:3000",
                        "http://localhost/44307",
                        "http://localhost/44394"
                        )
                    //.SetIsOriginAllowed(isOriginAllowed: _ => true)
                    .AllowAnyHeader().AllowAnyMethod().AllowCredentials()
                    .WithExposedHeaders("X-Pagination");
                });
            });


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
           ForwardedHeaders.XForwardedProto
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors("AllowAll");
        }
    }
}
