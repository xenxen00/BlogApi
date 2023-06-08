using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exeptions
{
    public class UserWithGivenCredentialsExists : Exception
    {
        public UserWithGivenCredentialsExists(string credentialString) 
            : base($"User with the given credentials already exists: {credentialString}")
        {
        }
    }
}
