using Microsoft.AspNetCore.Mvc;
using Shared.ModelsErrorDto;

namespace E_Commerce.API.Factories;

public class ApiResponseFactory
{
    public static IActionResult  CustomeValidation (ActionContext context)
    {



        var errors = context.ModelState
            .Where(error => error.Value?.Errors.Any() == true)
            .Select(Error => new ValidaionError()
            {
                Field = Error.Key,
                Errors = Error.Value?.Errors.Select(error => error.ErrorMessage).ToList() ?? new List<string>()



            });


        var response = new ValidationErrorResponse()
        {
            StatusCode = StatusCodes.Status400BadRequest,
            Errors = errors,
            ErrorMessage = "one or more validation Error Happend"
        };




        return  new BadRequestObjectResult(response);    
             
    }


       
    }

