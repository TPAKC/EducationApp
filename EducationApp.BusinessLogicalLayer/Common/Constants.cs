namespace EducationApp.BusinessLogicalLayer.Common
{
    public class Constants
    {
        public class ServiceValidationErrors
        {
            public const string UserIsExist = "User is exist";
            public const string UserCantBeRegistered = "User can't be registered";
            public const string PrintingEditionNotCreated = "Printing edition not created";
            public const string UserCantBeAddedToRole = "User can't be added to role";
            public const string WrongInputData = "Wrong input data";
            public const string UserNotFound = "User not found";
            public const string UserNotConfirmed = "User not confirmed";
            public const string FailedToChangePassword = "Failed to change password";
            public const string FailedToRemoveUser = "Failed to remove user";
            public const string FailedToUpdateUser = "Failed to update user";
            public const string UserListIsEmpty = "User list is empty";
            public const string AuthorListIsEmpty = "Author list is empty";
            public const string FailedToResetPassword = "Failed to reset password";
            public const string UserWithThisMailNotFound = "User with this mail not found";
            public const string FailedToCreateAuthor = "Failed to create author";
            public const string ThisEmailAddressIsNotRegistered = "This email address is not registered";
            public const string ThisAccountIsBlocked = "This account is blocked";
            public const string ThisAccountIsRemoved = "This account is removed";
            public const string ThisEmailIsNotVerified = "This email is not verified";
            public const string PasswordIsIncorrect = "Password is incorrect";
            public const string ModelIsNotValid = "Model is not valid";
            public const string PrintingEditionIsNotFound = "User is not found";
        }

        public class AccountRole
        {
            public const string NameAdminRole = "admin";
            public const string NameUserRole = "user";
        }

        public class UserData
        {
            public const string NameMailboxAddress = "Site administration";
            public const string AdressMailboxAddress = "alex1bakay@gmail.com";
            public const string HostConnectAsync = "smtp.gmail.com";
            public const string UserNameAuthenticateAsync = "alex1bakay@gmail.com";
            public const string PasswordAuthenticateAsync = "dota212310";
        }
        public class TemplateText
        {
            public const string ResetPasswordText = "You reset your password, your new password: ";
        }
    }
}
