using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Core.IService;
using TechademyEmployeeManagement.Core.Service;
using TechademyEmployeeManagement.Data;

namespace TechademyEmployeeManagement
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
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                }
                );
            });

            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("myDbConnection")));
            //services.AddDbContext<RegistrationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("myDbConnection")));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "localhost",
                    ValidAudience = "localhost",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwtConfig:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddSwaggerGen(); 
            //services.AddControllers();

            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddMvc();
           // services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            //services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IWorkingHourManagement, WorkingHourManagement>();
            services.AddScoped<IRequestLeaveRepository, RequestLeaveRepository>();

            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<ILeaveStatusRepository, LeaveStatusRepository>();
            services.AddScoped<IPaymentRulesRepository, PaymentRulesRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
                c.RoutePrefix = "";
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseRouting();

            app.UseCors("AllowOrigin");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
//-		Data	{System.Collections.ListDictionaryInternal}	System.Collections.IDictionary {System.Collections.ListDictionaryInternal}

