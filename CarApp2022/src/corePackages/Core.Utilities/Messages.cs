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
        public static string BrandExists = "Brand already exists";
        public static string BrandDoesNotExist = "Brand does not exist";

        public static string BrandAdded = "Brand is added successfuly";
        public static string UpdateBrandd = "Brand is updated successfuly";
        public static string DeleteBrandd = "Brand is deleted successfuly";

        public static string BrandIsNotDeleted = "Error occurred while deleting brand";
        public static string BrandIsNotUpdated = "Error occurred while updating brand";
        public static string BrandIsNotAdded = "Error occurred while adding brand";



        //Car Messages
        public static string CarPlateExists = "Car plate already exists";
        public static string CarModelIsNotValid = "Car plate already exists";
        public static string CarCanNotBeRentedWhenUnderMaintenance = "Car is under maintenance...Not available...";
        public static string CarCanNotBeRentedWhenAlreadyRented = "Car is already rented...Not available...";
        public static string CarDoesNotExist = "Car does not exist";
        public static string CarMaintenance = "Car is under maintenance";
        public static string CarPlateIsNotValid= "Car plate must be between 1-81";

        public static string CarAdded = "Car is added successfuly";
        public static string CarUpdated = "Car is updated successfuly";
        public static string CarDeleted = "Car is deleted successfuly";

        public static string CarIsNotDeleted = "Error occurred while deleting car";
        public static string CarIsNotUpdated = "Error occurred while updating car";
        public static string CarIsNotAdded = "Error occurred while adding car";



        //Color Messages
        public static string ColorExists = "Color already exists";
        public static string ColorDoesNotExist = "Color does not exist";

        public static string ColorAdded = "Color is added successfuly";
        public static string ColorUpdated = "Color is updated successfuly";
        public static string ColorDeleted = "Color is deleted successfuly";

        public static string ColorIsNotDeleted = "Error occurred while deleting color";
        public static string ColorIsNotUpdated = "Error occurred while updating color";
        public static string ColorIsNotAdded = "Error occurred while adding color";


        //Model Messages
        public static string ModelExists = "Model already exists";
        public static string ModelDoesNotExist = "Model does not exist";
        public static string ModelDailyPriceMustBeHigherThan0 = "Model Daily Price Must Be Higher Than 0";

        public static string ModelAdded = "Model is added successfuly";
        public static string ModelUpdated = "Model is updated successfuly";
        public static string ModelDeleted = "Model is deleted successfuly";

        public static string ModelIsNotDeleted = "Error occurred while deleting model";
        public static string ModelIsNotUpdated = "Error occurred while updating model";
        public static string ModelIsNotAdded = "Error occurred while adding model";


        //Transmission Messages
        public static string TransmissionExists = "Transmission already exists";
        public static string TransmissionDoesNotExist = "Transmission does not exist";

        public static string TransmissionAdded = "Transmission is added successfuly";
        public static string TransmissionUpdated = "Transmission is updated successfuly";
        public static string TransmissionDeleted = "Transmission is deleted successfuly";

        public static string TransmissionIsNotDeleted = "Error occurred while deleting transmission";
        public static string TransmissionIsNotUpdated = "Error occurred while updating transmission";
        public static string TransmissionIsNotAdded = "Error occurred while adding transmission";


        //Fuel Messages
        public static string FuelExists = "Fuel already exists";
        public static string FuelDoesNotExist = "Fuel does not exist";

        public static string FuelAdded = "Fuel is added successfuly";
        public static string FuelUpdated = "Fuel is updated successfuly";
        public static string FuelDeleted = "Fuel is deleted successfuly";

        public static string FuelIsNotDeleted = "Error occurred while deleting fuel";
        public static string FuelIsNotUpdated = "Error occurred while updating fuel";
        public static string FuelIsNotAdded = "Error occurred while adding fuel";


        //Maintenance Messages
        public static string MaintenanceExists = "Maintenance already exists";
        public static string MaintenanceDoesNotExist = "Maintenance does not exist";

        public static string MaintenanceAdded = "Maintenance is added successfuly";
        public static string MaintenanceUpdated = "Maintenance is updated successfuly";
        public static string MaintenanceDeleted = "Maintenance is deleted successfuly";

        public static string MaintenanceIsNotDeleted = "Error occurred while deleting maintenance";
        public static string MaintenanceIsNotUpdated = "Error occurred while updating maintenance";
        public static string MaintenanceIsNotAdded = "Error occurred while adding maintenance";


        //Invoice Messages
        public static string InvoiceExists = "Invoice already exists";
        public static string InvoiceDoesNotExist = "Invoice does not exist";

        public static string InvoiceAdded = "Invoice is added successfuly";
        public static string InvoiceUpdated = "Invoice is updated successfuly";
        public static string InvoiceDeleted = "Invoice is deleted successfuly";

        public static string InvoiceIsNotDeleted = "Error occurred while deleting Invoice";
        public static string InvoiceIsNotUpdated = "Error occurred while updating Invoice";
        public static string InvoiceIsNotAdded = "Error occurred while adding Invoice";



        //Customer Messages
        public static string CustomerExists = "Customer already exists";
        public static string CustomerDoesNotExist = "Customer does not exist";

        public static string CustomerAdded = "Customer is added successfuly";
        public static string CustomerUpdated = "Customer is updated successfuly";
        public static string CustomerDeleted = "Customer is deleted successfuly";

        public static string CustomerIsNotDeleted = "Error occurred while deleting customer";
        public static string CustomerIsNotUpdated = "Error occurred while updating customer";
        public static string CustomerIsNotAdded = "Error occurred while adding customer";



        //Findex Score Messages
        public static string FindeksCreditRateNameExists = "Findeks Credit Rate name already exists";
        public static string FindeksCreditRateNameDoesNotExist = "Findeks Credit Rate name does not exist";

        public static string FindeksCreditRateAdded = "Findeks Credit Rate is added successfuly";
        public static string FindeksCreditRateUpdated = "Findeks Credit Rate is updated successfuly";
        public static string FindeksCreditRateDeleted = "Findeks Credit Rate is deleted successfuly";

        public static string FindeksCreditRateIsNotDeleted = "Error occurred while deleting findeks Credit Rate";
        public static string FindeksCreditRateIsNotUpdated = "Error occurred while updating findeks Credit Rate";
        public static string FindeksCreditRateIsNotAdded = "Error occurred while adding findeks Credit Rate";


        //User Messages
        public static string UserExists = "User already exists";
        public static string UserEmailExists = "User mail already exists";
        public static string UserDoesNotExist = "User does not exist";
        public static string PasswordError = "User password does not match";

        public static string UserAdded = "User is added successfuly";
        public static string UserUpdated = "User is updated successfuly";
        public static string UserDeleted = "User is deleted successfuly";

        public static string UserIsNotDeleted = "Error occurred while deleting user";
        public static string UserIsNotUpdated = "Error occurred while updating user";
        public static string UserIsNotAdded = "Error occurred while adding user";



        //CarDamage Messages
        public static string CarDamageExists = "Car Damage already exists";
        public static string CarDamageDoesNotExist = "Car Damage does not exist";

        public static string CarDamageAdded = "Car Damage is added successfuly";
        public static string CarDamageUpdated = "Car Damage is updated successfuly";
        public static string CarDamageDeleted = "Car Damage is deleted successfuly";

        public static string CarDamageIsNotDeleted = "Error occurred while deleting Car Damage";
        public static string CarDamageIsNotUpdated = "Error occurred while updating Car Damage";
        public static string CarDamageIsNotAdded = "Error occurred while adding Car Damage";

    }
}
