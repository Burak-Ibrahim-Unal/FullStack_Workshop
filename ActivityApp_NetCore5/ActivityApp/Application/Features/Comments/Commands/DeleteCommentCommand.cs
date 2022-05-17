using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core.Result;
using Application.Core.Utilities;
using Domain.Entities;
using MediatR;
using Persistence.Contexts;

namespace Application.Features.Comments.Commands
{
    public class DeleteCommentCommand
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;

            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var Comment = await _context.Activities.FindAsync(request.Id);
               // if (Comment == null) return null;

                _context.Remove(Comment);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure(Messages.FailedDeleteComment);
                return Result<Unit>.Success(Unit.Value); // Unit.Value equals nothing...It means our command is finished...
            }
        }

    }
}