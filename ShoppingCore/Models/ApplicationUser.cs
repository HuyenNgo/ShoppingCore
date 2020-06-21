using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoppingCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(256)]
        public string FullName { set; get; }

        [MaxLength(256)]
        public string Address { set; get; }

        public DateTime? BirthDay { set; get; }

        public async Task<IdentityResult> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager,string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentityResult = await manager.CreateAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentityResult;
        }

        public virtual IEnumerable<Order> Orders { set; get; }
    }
}