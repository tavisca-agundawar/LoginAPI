using AuthenticationAPI.Database;
using AuthenticationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPI.Service
{
    public class LoginService
    {
        private static readonly UserDatabase _userDatabase = new UserDatabase();
        private static List<Error> _errors = new List<Error>();

        public LoginResponseModel GetLoginResponse(User user)
        {
            _errors.Clear();
            bool valid = UserValidationService.ValidateUserDetails(user, out _errors);
            if (!valid)
            {
                return new LoginResponseModel(valid, _errors);
            }
            LoginResponseModel authenticationResult = AuthenticateUser(user);

            return authenticationResult;
            

        }

        protected LoginResponseModel AuthenticateUser(User user)
        {
            User storedUser = _userDatabase.GetUserByUsername(user.Username);
            bool valid = true;
            if (storedUser != null)
            {
                _errors.Clear();
                
                if(storedUser.Password != user.Password)
                {
                    Error error = new Error(ErrorCode.IncorrectPassword, ErrorMessage.IncorrectPassword);
                    _errors.Add(error);
                    valid = false;
                }
                if (storedUser.UserType != user.UserType)
                {
                    Error error = new Error(ErrorCode.IncorrectUserType, ErrorMessage.IncorrectUserType);
                    _errors.Add(error);
                    valid = false;
                }

                return new LoginResponseModel(valid, _errors);

            }
            else
            {
                valid = false;
                Error error = new Error(ErrorCode.IncorrectUsername, ErrorMessage.IncorrectUsername);
                _errors.Add(error);
                return new LoginResponseModel(valid, _errors);
            }
        }
    }
}
