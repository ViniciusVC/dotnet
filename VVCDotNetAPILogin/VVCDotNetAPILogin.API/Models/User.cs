using Microsoft.AspNetCore.Identity;


namespace VVCDotNetAPILogin.API.Models
{

    public class User : IdentityUser
    {
        public string avatar {get; set;} = string.Empty;
    }

}