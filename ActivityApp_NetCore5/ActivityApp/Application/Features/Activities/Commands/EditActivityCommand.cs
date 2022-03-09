using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Persistence.Contexts;

namespace Application.Features.Activities.Commands
{
    public class EditActivityCommand
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x=>x.Activity).SetValidator(new ActivityValidator());
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);

                _mapper.Map(request.Activity, activity);
                
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }

    }
}