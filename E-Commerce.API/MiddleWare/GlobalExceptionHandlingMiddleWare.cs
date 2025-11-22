using Domain.NotFoundException;
using Microsoft.AspNetCore.Http;
using Shared.ModelsErrorDto;
using System.Net;
using System.Text.Json;

namespace E_Commerce.API.MiddleWare;

public class GlobalExceptionHandlingMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleWare> _logger;

    public GlobalExceptionHandlingMiddleWare(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleWare> logger)
    {
        _next = next;
        _logger = logger;
    }


    public async Task InvokeAsync(HttpContext context)
    {

        try
        {
            await _next(context); 

        }
        catch (Exception ex)
        {
            _logger.LogError($"SomeThing Went Wrong  ===> {ex.Message}");
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
     
        //-Change Status Code
        // enum Has  All Satatus Code respnse 
        //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 

        context.Response.StatusCode = ex switch { 
        
        
           NotFound => StatusCodes.Status404NotFound,

           (_)=>StatusCodes.Status500InternalServerError
        
        
        
        
        
        };




        //-Write respone in body 

        var response = new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            ErrorMessage = ex.Message
           


        }.ToString();


       //await context.Response.WriteAsync(JsonSerializer.Serialize(response));
      // await context.Response.WriteAsJsonAsync(response);
      await context.Response.WriteAsync(response);  


        //-Change ContentType 
        context.Response.ContentType= "application/json";   






    }
}
