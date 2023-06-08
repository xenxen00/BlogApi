using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IApplicationUser
    {
        public int Id { get; }
        public string Identity { get; }
        public string Email { get; }
        public IEnumerable<int> PermissionsIds { get; }
    }
}
