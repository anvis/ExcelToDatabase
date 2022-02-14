using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ScreenerAPI
{
  public static class ExceptionMiddleWareExtension
  {
    public static void ConfigureException(this IApplicationBuilder applicationBuilder)
    {
      applicationBuilder.UseExceptionHandler(error =>
      {
        error.Run(async Context =>
        {
          Context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
          Context.Response.ContentType = "application/json";

        var contextFeature =  Context.Features.Get<IExceptionHandlerFeature>();

          if (contextFeature != null)
          {
            // errror ocres do some logging..,
          }

        });

        
      });
    }
  }
}
