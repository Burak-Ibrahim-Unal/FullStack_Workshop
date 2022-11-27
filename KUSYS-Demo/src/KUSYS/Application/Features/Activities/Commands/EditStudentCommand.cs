using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities;
using FluentValidation;
using MediatR;
using Persistence.Contexts;

namespace Application.Features.Activities.Commands
{
    public class EditStudentCommand
    {
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
            private readonly BaseDbContext _context;
            private readonly IMapper _mapper;


            public Handler(BaseDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var student = await _context.Activities.FindAsync(request.Student.Id);
                if (student == null) return null;

                _mapper.Map(request.Student, student);

                var result = await _context.SaveChangesAsync() > 0;

                if(!result) return Result<Unit>.Failure(Messages.StudentUpdateFailed);
                return Result<Unit>.Success(Unit.Value); // Unit.Value equals nothing...It means our command is finished...
            }
        }

    }
}