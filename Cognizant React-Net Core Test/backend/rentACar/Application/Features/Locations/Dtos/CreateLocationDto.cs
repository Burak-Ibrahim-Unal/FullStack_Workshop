﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Locations.Dtos
{
    public class CreateLocationDto
    {
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }


    }
}
