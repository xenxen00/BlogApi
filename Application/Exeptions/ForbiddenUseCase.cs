using Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exeptions
{
    public class ForbiddenUseCase : Exception
    {
        public ForbiddenUseCase() : base("User is not authorized for requested action.")
        {
        }
    }
}
