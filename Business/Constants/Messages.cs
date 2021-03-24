using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constant
{
    public class Messages
    {

        //--------------------------------------Product--------------------------------------

        public static string ProductNameAlreadyExists  = "Product name already exists.";

        public static string TheProductHasBeenSuccessfullyAdded = "The product has been successfully added.";

        public static string TheProductHasBeenSuccessfullyDeleted = "The product has been successfully deleted.";

        public static string TheProductsHaveBeenSuccessfullyListed = "The products have been successfully listed.";

        public static string TheProductHasBeenSuccessfullyUpdated = "The product has been successfully updated.";

        //-------------------------------------Category-------------------------------------------------------------

        public static string CategoryNameAlreadyExists = "Category name already exists.";

        public static string TheCategoryHasBeenSuccessfullyAdded = "The category has been successfully added.";

        public static string TheCategoryHasBeenSuccessfullyDeleted = "The category has been deleted successfully.";

        public static string TheCategoriesHaveBeenSuccessfullyListed = "The categories have been successfully listed.";

        public static string TheCategoryHasBeenSuccessfullyUpdated = "The category has been successfully updated.";

        //----------------------------------------Customer----------------------------------------------------------

        public static string TheCustomerHasBeenSuccessfullyAdded = "The customer has been successfully added.";

        public static string TheCustomerHasBeenSuccessfullyDeleted = "The customer has been successfully deleted.";

        public static string TheCustomersHaveBeenSuccessfullyListed = "The customers have been successfully listed.";

        public static string TheCustomerHasBeenSuccessfullyUpdated = "The customer has been successfully updated.";

        //-------------------------------------------Order-----------------------------------------------------------

        public static string OrderNameAlreadyExists = "Order name already exists.";

        public static string TheOrderHasBeenSuccessfullyAdded = "The order has been successfully added.";

        public static string TheOrderHasBeenSuccessfullyDeleted = "The order has been successfully deleted.";

        public static string TheOrdersHaveBeenSuccessfullyListed = "The orders have been successfully listed.";

        public static string TheOrderHasBeenSuccessfullyUpdated = "The order has been updated successfully.";

        //---------------------------------------------Supplier------------------------------------

        public static string TheSupplierHasBeenSuccessfullyAdded = "The supplier has been successfully added.";

        public static string TheSupplierHasBeenSuccessfullyDeleted = "The supplier has been successfully deleted.";

        public static string TheSuppliersHaveBeenSuccessfullyListed = "The suppliers have been successfully listed.";

        public static string TheSupplierHasBeenSuccessfullyUpdated = "The supplier has been successfully updated.";

        //-----------------------------------------------Auth/User-------------------------------------------------------

        public static string AuthorizationDenied = "Authorizated denied.";

        public static string AccessTokenCreated = "Access Token created.";

        public static string UserRegistered = "User registered.";

        public static string UserNotFound = "User not found.";

        public static string PasswordError = "Wrong password.";

        public static string SuccessfulLogin = "Successful login.";

        public static string UserAlreadyExists = "User already exists.";

        //----------------------------------------------ProductImage---------------------------------------------

        public static string AboveImageAddingLimit = "You exceeded the image limit.";

        public static string ProductImageNotFound = "Product image not found.";

        public static string TheImageHasBeenSuccessfullyAdded = "The image has been successfully added.";

        public static string TheImageHasBeenSuccessfullyDeleted = "The image has been successfully deleted.";

        public static string TheImageHasBeenSuccessfullyUpdated = "The image has been successfully updated.";

        public static string IncorrectFileExtension = "Incorrect file extensions.";

        //------------------------------------------------ImageUploads--------------------------------------

        public static string ProductImageLimitExceeded = "Product image limit exceeded.";//business
    }
}
