using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Brands.Commands.CreateBrand;

namespace WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        // Same with dependency injection

    }
}
