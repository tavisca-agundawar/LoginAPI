using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPI.Database
{
    public class ErrorCode
    {
        public const int IncorrectUsername = 1401;
        public const int IncorrectPassword = 1402;
        public const int IncorrectUserType = 1403;

        public const int MissingUsername = 1411;
        public const int MissingPassword = 1412;
        public const int MissingUserType = 1413;
    }
}
