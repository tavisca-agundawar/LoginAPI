using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPI.Model
{
    public class LoginResponseModel
    {
        public bool Success = false;
        public List<Error> Errors = null;

        public LoginResponseModel(bool success, List<Error> errors)
        {
            Success = success;
            if(errors.Count>0)
                Errors = errors;
        }
    }
}
