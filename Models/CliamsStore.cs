using System.Collections.Generic;
using System.Security.Claims;

namespace MVC_Start.Models
{
    public static class CliamsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Create Role","Create Role"),
            new Claim("Edit Role","Edit Role"),
            new Claim("Delete Role","Delete Role"),
            new Claim("EditStudent","EditStudent")
        };
    }
}
