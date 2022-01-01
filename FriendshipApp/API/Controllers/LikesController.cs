using System.Threading.Tasks;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class LikeController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly ILikeRepository _likeRepository;
        public LikeController(IUserRepository userRepository, ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
            _userRepository = userRepository;
        }

        [HttpPost("{username}")]
        public async Task<ActionResult> AddLike(string username)
        {
            var sourceUserId = User.GetUserId();
            var likedUser = await _userRepository.GetUserByNameAsync(username);
            var sourceUser = await _likeRepository.GetUserWithLikes(sourceUserId);

            if (likedUser == null) return NotFound();
            if (sourceUser.UserName == username) return BadRequest("You cant like yourself... :)");


        }
    }
}