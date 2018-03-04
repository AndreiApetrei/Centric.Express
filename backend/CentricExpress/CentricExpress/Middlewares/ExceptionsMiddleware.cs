using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CentricExpress.WebApi.Middlewares
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _env;

        public ExceptionsMiddleware(RequestDelegate next, IHostingEnvironment env)
	    {
            _next = next;
            _env = env;
	    }

	    public async Task Invoke(HttpContext context)
	    {
	        try
	        {
	            await _next(context);
	        }
	        catch (Exception)
            {
                if (_env.IsDevelopment()) {
                    throw;
                }

                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var response = new {
                        Message = "There was an internal error on the server. Try again later!",
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    };

                    var json = JsonConvert.SerializeObject(response);
                    await context.Response.WriteAsync(json);
                }
            }
	    }
	}

	public static class ExceptionsMiddlewareExtensions
    {
	    public static IApplicationBuilder UseExceptionsMiddleware(this IApplicationBuilder builder)
	    {
	        return builder.UseMiddleware<ExceptionsMiddleware>();
	    }
	}
}
