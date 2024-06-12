using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using EmployeePayroll.WebAPI.Model;

namespace EmployeePayroll.WebAPI.Filters;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();

            var errorResponse = new ValidationErrorResponse
            {
                Errors = errors
            };

            context.Result = new BadRequestObjectResult(errorResponse);
            return;
        }

        await next();
    }
}
