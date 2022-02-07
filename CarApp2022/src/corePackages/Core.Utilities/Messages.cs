using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public class Messages
    {
        //Brand Messages
        public static string BrandNameExists = "Brand name already exists";
        public static string BrandNameDoesNotExist = "Brand name does not exist";

        public static string BrandAdded = "Brand is added successfuly";
        public static string BrandUpdated = "Brand is updated successfuly";
        public static string BrandDeleted = "Brand is deleted successfuly";

        public static string BrandIsNotDeleted = "Error occurred while deleting brand";
        public static string BrandIsNotUpdated = "Error occurred while updating brand";
        public static string BrandIsNotAdded = "Error occurred while adding brand";



        //Car Messages
        public static string CarPlateExists = "Car plate already exists";
        public static string CarModelIsNotValid = "Car plate already exists";
        public static string CarCanNotBeRentedWhenUnderMaintenance = "Car is under maintenance...Not available...";
        public static string CarCanNotBeRentedWhenAlreadyRented = "Car is already rented...Not available...";
        public static string CarDoesNotExist = "Car does not exist";

        public static string CarAdded = "Car is added successfuly";
        public static string CarUpdated = "Car is updated successfuly";
        public static string CarDeleted = "Car is deleted successfuly";

        public static string CarIsNotDeleted = "Error occurred while deleting car";
        public static string CarIsNotUpdated = "Error occurred while updating car";
        public static string CarIsNotAdded = "Error occurred while adding car";



        //Color Messages
        public static string ColorNameDoesNotExist = "Color name does not exist";

        //Model Messages

        //Transmission Messages

        //Fuel Messages
    }
}
