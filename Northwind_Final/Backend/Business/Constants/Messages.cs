using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product is added succesfully";
        public static string ProductUpdated = "Product is updated succesfully";
        public static string ProductNameInvalid = "Product name is invalid";
        public static string MaintanceTime = "Maintance Time";
        public static string ProductsListed = "Products listed";
        public static string CategorysListed = "Categories listed";
        public static string ProductCountCategoryError = "You cant add this product.Category Limitation...";
        public static string ProductNameAlreadyExists = "Product name must be unique...It is already defined.";
        public static string CategoryLimitExceeded = "You cant add more categories...Max limit...";
        public static string AuthorizationDenied = "Access Denied.No Permission...";
        public static string UserRegistered = "User Registered.";
        public static string UserNotFound = "User is not found.";
        public static string PasswordError = "Password is not found.";
        public static string SuccessfulLogin = "Login is successful.";
        public static string UserAlreadyExists = "User is already defined.";
        public static string AccessTokenCreated = "Tokes is created successfuly.";
    }
}
