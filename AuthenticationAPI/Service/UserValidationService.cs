using AuthenticationAPI.Database;
using AuthenticationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPI.Service
{
    public class UserValidationService
    {
        public static bool ValidateUserDetails(User user, out List<Error> errors)
        {
            bool valid = true;
            errors = null;
            List<Error> _errors = new List<Error>();

            if(user.Username.IsBlankOrWhiteSpace())
            {
                Error error = new Error(ErrorCode.MissingUsername,ErrorMessage.MissingUsername);
                _errors.Add(error);
                valid = false;
            }
            if (user.Password.IsBlankOrWhiteSpace())
            {
                Error error = new Error(ErrorCode.MissingPassword, ErrorMessage.MissingPassword);
                _errors.Add(error);
                valid = false;
            }
            if (user.UserType.IsBlankOrWhiteSpace())
            {
                Error error = new Error(ErrorCode.MissingUserType, ErrorMessage.MissingUserType);
                _errors.Add(error);
                valid = false;
            }
            if (_errors != null)
                errors = _errors;
            return valid;
        }
    }
}
