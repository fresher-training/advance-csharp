using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace advance_csharp
{
    /// <summary>
    /// Action filter
    /// https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.filters.actionfilterattribute?view=aspnetcore-7.0
    /// </summary>
    public class MyAppAuthenticationAttribute : ActionFilterAttribute
    {
        public string Role { get; set; }

        public MyAppAuthenticationAttribute(string role)
        {
            Role = role;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (!string.IsNullOrEmpty(Role))
            {
                if (Role == "Admin")
                {
                    return;
                }
                context.Result = new UnauthorizedObjectResult("user is unauthorized");
            }
        }
    }
}
