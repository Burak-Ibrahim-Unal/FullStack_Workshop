using  MediatR;
using Application.Core.Result;

namespace Application.Features.Followers
{
    public class FollowToggle
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string  TargetUsername { get; set; }

        }

        public class Handler : IRequestHandler<Command,Result<Unit>>
        {
            new System.NotImplementedException();
            
        }


    }
}