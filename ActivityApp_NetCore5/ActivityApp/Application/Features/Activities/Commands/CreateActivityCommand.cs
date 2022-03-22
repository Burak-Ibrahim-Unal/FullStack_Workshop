using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Core.Result;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Features.Activities.Commands
{
    public class CreateActivityCommand
    {
        //we dont want to return anything after created activity. We used IRequest<Result<Unit>>
        public class Command : IRequest<Result<Unit>>
        {
            public Activity Activity { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;

            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                // Firstly ,we are not accessing db.We add our entity to memory. So we dont need to use AddAsync function.
                // At Task<Unit>, Unit returns noting.It just say to our api command is completed. AddSync = Add for this case
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.getUsername());
                var attendee = new ActivityAttendee
                {
                    AppUser = user,
                    Activity = request.Activity,
                    IsHost = true
                };

                request.Activity.Attendees.Add(attendee);

                _context.Activities.Add(request.Activity);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create activity...");
                return Result<Unit>.Success(Unit.Value); // Unit.Value equals nothing...It means our command is finished...
            }
        }

    }
}