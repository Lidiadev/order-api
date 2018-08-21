using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Order.Api.Infrastructure.Filters
{
    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
                return;

            var validationErrors = context.ModelState.Keys
                .SelectMany(i => context.ModelState[i].Errors)
                .Select(i => i.ErrorMessage)
                .ToArray();

            var jsonError = new JsonErrorResponse { Messages = validationErrors };

            context.Result = new BadRequestObjectResult(jsonError);
        }
    }
}
