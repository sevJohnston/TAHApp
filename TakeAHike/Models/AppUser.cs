using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeAHike.Models
{
    public class AppUser : IdentityUser
    {
        //IdentityUser class contains Id, UserName, Clains, Email, etc
        //-- so you don't need to keep them here
    }
}
