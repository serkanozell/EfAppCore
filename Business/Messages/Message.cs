using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Messages
{
    public static class Message
    {
        public static string Added = "Added!!";
        public static string Deleted = "Deleted!!";
        public static string Updated = "Updated!!";
        public static string ProductsListed = "Products Listed!!";
        public static string AuthorizationDenied = "Authorization Error!!!";
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;

        public static string UserRegistered { get; internal set; }
    }
}
