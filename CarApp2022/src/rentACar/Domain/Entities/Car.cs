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

        public Car()
        {
            CarDamages = new HashSet<CarDamage>();
        }

        public Car(int id, int colorId, int modelId, CarState carState, int kilometer,short modelYear,string plate,short minFindeksCreditRate) : this()
        {
            Id = id;
            ColorId = colorId;
            ModelId = modelId;
            Plate = plate;
            ModelYear = modelYear;
            CarState = carState;
            Kilometer = kilometer;
            ModelYear = modelYear;
            Plate = plate;
            MinFindeksCreditRate = minFindeksCreditRate;
        }


        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public int Kilometer { get; set; }
        public int FindexScore { get; set; }
        public short MinFindeksCreditRate { get; private set; }


        public CarState CarState { get; set; }
        public virtual Color Color { get; set; }
        public virtual Model Model { get; set; }
        public virtual ICollection<CarDamage> CarDamages { get; set; }


    }
}
