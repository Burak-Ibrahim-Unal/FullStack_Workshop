using System;
using System.Collections.Generic;
using Application.Profiles;

namespace Application.Features.Activities.Dto
{
    public class ActivityDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public string HostUsername { get; set; }
        public ICollection<Profile> Profiles { get; set; }
    }
}