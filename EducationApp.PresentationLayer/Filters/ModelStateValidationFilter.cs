using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationApp.PresentationLayer.Filters
{
    public class ModelStateValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid && context.HttpContext.Request.Path.Value.ToLower().Contains("/api/"))
            {
                var errors = GetErrors(context.ModelState);
                context.Result = new BadRequestObjectResult(errors);
            }
        }

        private string GetErrors(ModelStateDictionary modelState)
        {
            string messages = string.Join("\n", modelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));
            return messages;
        }

    }
}
