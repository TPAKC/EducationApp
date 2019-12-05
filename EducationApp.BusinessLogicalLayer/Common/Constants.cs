namespace EducationApp.BusinessLogicalLayer.Common
{
    public class Constants
    {
        public class ServiceValidationErrors
        {
            public const string UserIsExist = "User is exist";
            public const string UserCantBeRegistered = "User can't be registered";
            public const string UserCantBeAddedToRole = "User can't be added to role";
            public const string WrongInputData = "Wrong input data";
            public const string UserNotFound = "User not found";
            public const string UserNotConfirmed = "User not confirmed";
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
    }
}
