using API.Interfaces;

namespace API.Controllers
{
    public class LikeController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly ILikeRepository _likeRepository;
        public LikeController(IUserRepository userRepository, ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
            _userRepository = userRepository;
        }
    }
}