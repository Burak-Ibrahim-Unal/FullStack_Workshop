using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Dtos
{
    public class ColorDeleteDto
    {
        public int Id { get; set; }
        public string ModelId { get; set; }
        public string ColorId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public CarState CarState { get; set; }


    }
}
