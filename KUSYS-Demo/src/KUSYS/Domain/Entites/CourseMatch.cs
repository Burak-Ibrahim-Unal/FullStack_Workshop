﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CourseMatch : Entity
    {
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

        public CourseMatch()
        {
        }

        public CourseMatch(int id) : base(id)
        {
            Id= id;
        }
    }
}
