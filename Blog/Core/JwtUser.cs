using DataAccess;

namespace Api.Core
{
    public class JwtUser : IApplicationUser
    {
        public int Id { get; set; }

        public string Identity { get; set; }

        public string Email { get; set; }

        public IEnumerable<int> PermissionsIds { get; set; } = new List<int>(); 
    }

    public class UnauthorizedUser : IApplicationUser
    {
        public int Id => 0;

        public string Identity => "Anonymous";

        public string Email => "";

        public IEnumerable<int> PermissionsIds => new List<int> { 1 };
    }
}
