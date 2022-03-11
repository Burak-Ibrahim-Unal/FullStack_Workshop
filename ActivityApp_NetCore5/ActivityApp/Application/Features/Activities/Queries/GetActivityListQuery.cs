using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Result;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Features.Activities.Queries
{
    public class GetActivityListQuery
    {
        public class Query : IRequest<Result<List<Activity>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<Activity>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }

            public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Activity>>.Success(await _context.Activities.ToListAsync(cancellationToken));
            }
        }


    }
}