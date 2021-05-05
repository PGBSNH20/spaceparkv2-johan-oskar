using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Middleware
{
    public enum ApiRoles
    {
        User,
        Admin
    }

    public class ApiKey
    {
        public string Key { get; set; }
        public List<ApiRoles> Roles { get; set; }

        public ApiKey(string key, List<ApiRoles> roles)
        {
            Key = key;
            Roles = roles;
        }
    }
}
