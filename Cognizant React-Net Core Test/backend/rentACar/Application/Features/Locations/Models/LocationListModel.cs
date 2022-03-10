using Application.Features.Locations.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Locations.Models
{
    public class LocationListModel : BasePageableModel
    {
        public IList<LocationListDto> Items { get; set; }


    }
}
