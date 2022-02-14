//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;


namespace ScreenerAPI
{
     public static class CorsInfo
    {
      readonly static string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

      public static void ConfigureCors(IServiceCollection services, IConfiguration Configuration)
      {
        //var corsBuilder = new CorsPolicyBuilder();
        //corsBuilder.AllowAnyHeader();
        //corsBuilder.AllowAnyMethod();

        ////  corsBuilder.AllowAnyOrigin(); // For anyone access.

        //corsBuilder.WithOrigins("https://localhost:44342"); // for a specific url. Don't add a forward slash on the end!
        //corsBuilder.AllowCredentials();

        //services.AddCors(options =>
        //{
        //  options.AddPolicy(MyAllowSpecificOrigins,
        //    builder =>
        //    {
        //    //  builder.WithOrigins("https://localhost:44342");
        //    // builder.WithOrigins("*");
        //    // builder.AllowAnyOrigin();

        //    options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());

        //    });
        //});



      var corsBuilder = new CorsPolicyBuilder();
      corsBuilder.AllowAnyHeader();
      corsBuilder.AllowAnyMethod();
      corsBuilder.AllowAnyOrigin(); // For anyone access.
      // corsBuilder.WithOrigins("http://localhost:56573"); // anvi for a specific url. Don't add a forward slash on the end!
      //corsBuilder.AllowCredentials();

      services.AddCors(options =>
      {
        options.AddPolicy(MyAllowSpecificOrigins,
          builder =>
          {
            //  builder.WithOrigins("https://localhost:44342");
            // builder.WithOrigins("*");
            // builder.AllowAnyOrigin();

            options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());

          });
      });






    }
    
  }
}
