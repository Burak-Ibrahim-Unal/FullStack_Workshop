using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Features.Activities.Queries
{
    public class GetActivityListQuery
    {
        public class Query : IRequest<List<Activity>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }

            public Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _context.Activities.ToListAsync();
            }
        }


    }
}