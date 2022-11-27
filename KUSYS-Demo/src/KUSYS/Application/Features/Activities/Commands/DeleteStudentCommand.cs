using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities;
using MediatR;
using Persistence.Contexts;

namespace Application.Features.Activities.Commands
{
    public class DeleteStudentCommand
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly BaseDbContext _context;

            public Handler(BaseDbContext context)
            {
                _context = context;

            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Students.FindAsync(request.Id);
               // if (activity == null) return null;

                _context.Remove(activity);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure(Messages.FailedDeleteActivity);
                return Result<Unit>.Success(Unit.Value); // Unit.Value equals nothing...It means our command is finished...
            }
        }

    }
}