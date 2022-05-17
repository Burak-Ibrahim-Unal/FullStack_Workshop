using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core.Result;
using Application.Core.Utilities;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Persistence.Contexts;

namespace Application.Features.Comments.Commands
{
    public class EditCommentCommand
    {
        public string Body { get; set; }
        public Guid ActivityId { get; set; }

        public class Command : IRequest<Result<Unit>>
        {
            public Comment Comment { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                // RuleFor(x => x.Body).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;


            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var Comment = await _context.Activities.FindAsync(request.Comment.Id);
                if (Comment == null) return null;

                _mapper.Map(request.Comment, Comment);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure(Messages.CommentUpdateFailed);
                return Result<Unit>.Success(Unit.Value); // Unit.Value equals nothing...It means our command is finished...
            }
        }

    }
}