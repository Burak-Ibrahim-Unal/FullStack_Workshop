using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Dtos
{
    public class UpdateCarDto
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public int FindexScore { get; set; }
        public int Kilometer { get; set; }
        public City City { get; set; }
        public CarState CarState { get; set; }


    }
}
