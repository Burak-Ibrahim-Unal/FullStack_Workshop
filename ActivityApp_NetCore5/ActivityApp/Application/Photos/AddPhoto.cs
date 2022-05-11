using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Core.Result;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Photos
{
    public class AddPhoto
    {
        public class AddPhotoCommand : IRequest<Result<Photo>>
        {
            public IFormFile File { get; set; }

        }

        public class Handler : IRequestHandler<AddPhotoCommand, Result<Photo>>
        {
            private readonly DataContext _context;
            private readonly IPhotoAccessor _photoAccessor;
            private readonly IUserAccessor _userAccessor;


            public Handler(DataContext context, IPhotoAccessor photoAccessor, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _photoAccessor = photoAccessor;
                _context = context;

            }


            public async Task<Result<Photo>> Handle(AddPhotoCommand request, CancellationToken cancellationToken)
            {
                //include = Ef says bring users with photos
                // For include, it means select * from Users left outer join Photos

                var user = await _context.Users
                                        .Include(p => p.Photos)
                                        .FirstOrDefaultAsync(x => x.UserName == _userAccessor.getUsername());

                if (user == null) return null;

                var photoUploadResult = await _photoAccessor.AddPhoto(request.File);

                var photo = new Photo
                {
                    Url = photoUploadResult.Url,
                    Id = photoUploadResult.PublicId
                };

                if (!user.Photos.Any(x => x.IsMain)) photo.IsMain = true;

                user.Photos.Add(photo);

                var result = await _context.SaveChangesAsync() > 0;

                if (result) return Result<Photo>.Success(photo);
                
                return Result<Photo>.Failure("Problem occured while adding Photo");
            }
        }
    }
}