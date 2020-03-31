using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using WebMotors.Domain.Business.Implementations;
using WebMotors.Domain.Business.Interfaces;
using WebMotors.Domain.Data.Converter;
using WebMotors.Repository;
using WebMotors.Repository.Implementations;
using WebMotors.Repository.Interfaces;

namespace TesteWebMotors
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
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddXmlSerializerFormatters();
              
            services.AddDbContext<ContextDB>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
             
            services.AddMvc(option => option.EnableEndpointRouting = false);
             
            #region Dependency Injections

            services.AddScoped<IAnuncioRepository, AnuncioRepository>();
            services.AddScoped<IAnuncioBusiness, AnuncioBusiness>();

            #endregion

            #region Auto Mapper Configurations

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
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

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //}); 

            app.UseMvc();
        }



    }
}
