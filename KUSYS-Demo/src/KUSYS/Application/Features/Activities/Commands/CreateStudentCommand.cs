using System.Threading;
using System.Threading.Tasks;
using Application.Core.Result;
using Application.Core.Utilities;
using Application.Interfaces;
using Domain.Entites;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Features.Activities.Commands
{
    public class CreateStudentCommand
    {
        //we dont want to return anything after created student. We used IRequest<Result<Unit>>
        public class Command : IRequest<Result<Unit>>
        {
            public Student Student { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Student).SetValidator(new StudentValidator());
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
                var attendee = new StudentAttendee
                {
                    AppUser = user,
                    Student = request.Student,
                    IsHost = true
                };

                request.Student.Attendees.Add(attendee);

                _context.Activities.Add(request.Student);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure(Messages.FailedCreateStudent);
                return Result<Unit>.Success(Unit.Value); // Unit.Value equals nothing...It means our command is finished...
            }
        }

    }
}