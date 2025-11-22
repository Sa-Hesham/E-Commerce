using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ModelsErrorDto;
public class ValidationErrorResponse
{
    public int StatusCode { get; set; } 

    public string ErrorMessage { get; set; } = string.Empty;



    public IEnumerable<ValidaionError> Errors { get; set; } = [];

}

public class ValidaionError
{
    public string Field { get; set; } = string.Empty;   
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();

}