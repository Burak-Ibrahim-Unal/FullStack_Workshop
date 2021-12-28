using System;
using System.Threading.Tasks;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var contextResult = await next();

            if (!contextResult.HttpContext.User.Identity.IsAuthenticated) return;

            var username = contextResult.HttpContext.User.GetUsername();
            var repo = contextResult.HttpContext.RequestServices.GetService<IUserRepository>();
            var user = await repo.GetUserByNameAsync(username);
            user.LastActive = DateTime.Now;
            await repo.SaveAllAsync();

        }
    }
}