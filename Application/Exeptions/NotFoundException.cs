using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exeptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string entity, int id): base($"Entity {entity} of id={id} not found.") { }
    }
}
