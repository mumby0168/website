using Microsoft.AspNetCore.Mvc;
using Website.Shared;

namespace Website.Functions.Abstractions
{
    public abstract class BaseFunction
    {
        protected IActionResult Ok() => new OkResult();
        protected IActionResult Ok<T>(T data) => new OkObjectResult(data);

        protected IActionResult NotFound() => new NotFoundResult();

        protected IActionResult NotFound(string message) => new NotFoundObjectResult(new ApiError {Message = message});
        
        protected IActionResult BadRequest(string message) => new NotFoundObjectResult(new ApiError {Message = message});
    }
}