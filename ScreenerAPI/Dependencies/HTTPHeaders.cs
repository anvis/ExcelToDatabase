using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenerAPI
{
  public static class HTTPHeaders
  {
    public static void Read(this IApplicationBuilder applicationBuilder)
    {
      applicationBuilder.Use(async (context, next) =>
      {

        if (!context.Request.Headers.Keys.Contains("user-key"))
        {
          context.Response.StatusCode = 400;
        }       

        await next();

        if (!context.Request.Headers.Keys.Contains("user-key"))
        {
          context.Response.StatusCode = 400;
        }
        //Response header manipulation logic
      });
    }
  }
}
