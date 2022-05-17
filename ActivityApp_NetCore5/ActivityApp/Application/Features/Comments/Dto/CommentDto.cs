using System;

namespace Application.Features.Comments.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Body { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Image { get; set; }
        

    }
}