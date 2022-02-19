using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Persistence.Contexts;

namespace Application.Features.Activities.Commands
{
    public class CreateActivityCommand
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;

            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity); 
                // we are not accessing db.We add our entity to memory. So we dont need to use AddAsync function
                // At Task<Unit>, Unit returns noting.It just say to our api command is completed. 

                await _context.SaveChangesAsync();

                return Unit.Value; // it equals nothing...It means our command is finished...
            }
        }

    }
}