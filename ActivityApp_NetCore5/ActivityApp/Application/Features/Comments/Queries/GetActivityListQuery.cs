using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core.Result;
using Application.Features.Comments.Dto;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq;
using System;

namespace Application.Features.Comments.Queries
{
    public class GetCommentListQuery
    {

        public class Query : IRequest<Result<List<CommentDto>>>
        {
            public Guid ActivityId { get; set; } // we use this prop to get all comments of activity
        }

        public class Handler : IRequestHandler<Query, Result<List<CommentDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;


            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }

            public async Task<Result<List<CommentDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Comments = await _context.Comments
                .Where(x => x.Activity.Id == request.ActivityId)
                .OrderBy(x => x.CreatedDate)
                .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

                return Result<List<CommentDto>>.Success(Comments);
            }
        }


    }
}