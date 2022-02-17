using Core.Persistence.Repositories;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car : Entity
    {
        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public int RentalOfficeId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public int Kilometer { get; set; }
        public short FindexScore { get; private set; }


        public CarState CarState { get; set; }
        public virtual Color Color { get; set; }
        public virtual Model Model { get; set; }
        public virtual RentalOffice RentalOffice { get; set; }
        public virtual ICollection<CarDamage> CarDamages { get; set; }


        public Car()
        {
            CarDamages = new HashSet<CarDamage>();
        }

        public Car(int id, int colorId, int modelId, int rentalOfficeId, CarState carState, int kilometer,
               short modelYear, string plate, short minFindeksCreditRate) : base(id)
        {
            Id = id;
            ColorId = colorId;
            ModelId = modelId;
            RentalOfficeId = rentalOfficeId;
            Plate = plate;
            ModelYear = modelYear;
            CarState = carState;
            Kilometer = kilometer;
            ModelYear = modelYear;
            Plate = plate;
            FindexScore = minFindeksCreditRate;
        }

    }
}
