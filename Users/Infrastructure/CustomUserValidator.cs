using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Users.Models;

namespace Users.Infrastructure
{
    public class CustomUserValidator : UserValidator<AppUser>
    {
        public CustomUserValidator(AppUserManager manager)
            : base(manager)
        { }

        public override async Task<IdentityResult> ValidateAsync(AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            if (!user.Email.ToLower().EndsWith("@mail.com"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Любой email-адрес, отличный от mail.com запрещен");
                result = new IdentityResult(errors);
            }

            return result;
        }
    }
}