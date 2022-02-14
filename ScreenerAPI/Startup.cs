using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;

namespace ScreenerAPI
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
      CorsInfo.ConfigureCors(services, Configuration);

      services.AddAutoMapper(typeof(Startup));
      services.AddControllers();
      services.Configure<MarketCapitalization>(Configuration.GetSection("MarketCap"));
      services.AddServiceDependencies();
      //ServiceDependencies.EnableMapping();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseCors("SiteCorsPolicy");
      if (env.IsDevelopment())
      { 
        app.UseDeveloperExceptionPage();
      }

      app.Read();

       app.ConfigureException();
     // app.UseDeveloperExceptionPage();

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
