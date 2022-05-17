using System;

namespace Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public AppUser Author { get; set; }
        public Activity Activity { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        

    }
}