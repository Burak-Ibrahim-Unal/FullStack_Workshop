using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Model : Entity
    {
        public Model()
        {

        }

        public Model(int id, string name, double dailyPrice, int transmissionTypeId, int fuelTypeId, int brandId, string imageUrl)
        {
            Id = id;
            Name = name;
            DailyPrice = dailyPrice;
            TransmissionTypeId = transmissionTypeId;
            FuelTypeId = fuelTypeId;
            BrandId = brandId;
            ImageUrl = imageUrl;
        }


        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public int TransmissionTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int BrandId { get; set; }
        public string ImageUrl { get; set; }

        public virtual Brand Brand { get; set; }

    }
}
