using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CoreApi
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           // services.Configure<MySettingsModel>(Configuration.GetSection("MySettings"));
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000", "https://mymarathalagna.com", "https://www.mymarathalagna.com", "http://www.mymarathalagna.com", "http://mymarathalagna.com").AllowAnyHeader()
                                                  .AllowAnyMethod();
                                  });
            });
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>
            {

                options.AddPolicy("AllowAnyCorsPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


            });
            //services.AddCors(c =>  
            //{
            //   c.AddDefaultPolicy(
            //   builder =>
            //   {
            //       builder.WithOrigins("*", "*")
            //                           .AllowAnyHeader().AllowAnyOrigin()
            //                           .AllowAnyMethod();
            //   });
            //    c.AddPolicy("AllowOrigin", options => options
            //    .WithOrigins("*")
            //    .AllowAnyHeader()
            //    .AllowAnyMethod()
            //    .AllowAnyOrigin()
            //    );                  
            //});
            services.AddSwaggerGen();


            /* */
            services.AddControllers();
            var key = "This is my first Test Key";
           

          
            /* */

            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1", new Info
            //    {
            //        Version = "v1",
            //        Title = "Framework Automation"
            //    });
            //    options.OperationFilter<SecurityRequirementsOperationFilter>();
            //});
            //services.AddTransient<IDbConnection>(db => new SqlConnection(
            //          Configuration.GetConnectionString("AppConnectionString")));

            //services.AddTransient<IDbConnection>((sp) =>            
            //new NpgsqlConnection(this.Configuration.GetConnectionString("Dapper"))
           
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Login}/{action=Index}/{id?}");
            });
            // app.UseCors(options => options.AllowAnyOrigin());
            // app.UseCors("*");
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            //  app.UseSwaggerUI(c => c.SwaggerEndpoint("/Prod/swagger/v1/swagger.json", "MemberJWTDemo v1"));
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MemberJWTDemo v1"));
            //if (env.IsDevelopment())
            //{
              
            //}
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseHttpsRedirection();
            //  app.UseRouting();




            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // c.SwaggerEndpoint("/Prod/swagger/v1/swagger.json", "Framework Automation");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Framework Automation");
            });
            app.UseCors(options => options.WithOrigins("http://localhost:3000"));
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
        }
    }
}
