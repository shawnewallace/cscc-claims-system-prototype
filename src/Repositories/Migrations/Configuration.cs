using EDeviceClaims.Core;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories.Contexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EDeviceClaims.Repositories.Migrations
{
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<EDeviceClaims.Repositories.Contexts.EDeviceClaimsContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(EDeviceClaims.Repositories.Contexts.EDeviceClaimsContext context)
    {
      var roleStore = new RoleStore<IdentityRole>(context);
      var roleManager = new RoleManager<IdentityRole>(roleStore);

      roleManager.Create(new IdentityRole { Name = ApplicationRoles.Admin });
      roleManager.Create(new IdentityRole { Name = ApplicationRoles.Underwriter });
      roleManager.Create(new IdentityRole { Name = ApplicationRoles.PolicyHolder });

      var policyHolder = CreateUser("user@personal.com", "user@personal.com", context, ApplicationRoles.PolicyHolder, "Policy", "Holder" );
      CreateUser("admin@company.com", "admin@company.com", context, ApplicationRoles.Admin, "Admin", "Istrator");
      CreateUser("callcenter@company.com", "callcenter@company.com", context, ApplicationRoles.Underwriter, "Under", "Writer");

      var p1 = new PolicyEntity
      {
        Id = Guid.NewGuid(),
        Number = "12345",
        SerialNumber = "ABCDEF",
        DeviceName = "iPhone 6+",
        CustomerEmail = "user@personal.com",
        UserId = policyHolder.Id
      };
      var p2 = new PolicyEntity
      {
        Id = Guid.NewGuid(),
        Number = "67890",
        SerialNumber = "GHIJKL",
        DeviceName = "Android",
        CustomerEmail = "user@personal.com",
        UserId = policyHolder.Id
      };


      context.Policies.AddOrUpdate(
              p => p.Number,
              p1,
              p2,
              new PolicyEntity { Id = Guid.NewGuid(), Number = "11121", SerialNumber = "MNOPQ", DeviceName = "iPhone 6+", CustomerEmail = "d@b.com" },
              new PolicyEntity { Id = Guid.NewGuid(), Number = "31415", SerialNumber = "RSTUV", DeviceName = "iPhone 6+", CustomerEmail = "e@b.com" },
              new PolicyEntity { Id = Guid.NewGuid(), Number = "16171", SerialNumber = "WXYZA", DeviceName = "iPhone 6+", CustomerEmail = "f@b.com" },
              new PolicyEntity { Id = Guid.NewGuid(), Number = "81920", SerialNumber = "BCDEF", DeviceName = "iPhone 6+", CustomerEmail = "g@b.com" },
              new PolicyEntity { Id = Guid.NewGuid(), Number = "21222", SerialNumber = "GHIJK", DeviceName = "iPhone 6+", CustomerEmail = "h@b.com" },
              new PolicyEntity { Id = Guid.NewGuid(), Number = "32425", SerialNumber = "LMNOP", DeviceName = "iPhone 6+", CustomerEmail = "i@b.com" },
              new PolicyEntity { Id = Guid.NewGuid(), Number = "26272", SerialNumber = "QRSTU", DeviceName = "iPhone 6+", CustomerEmail = "j@b.com" }
            );

      //policyHolder.UserPolicies.Add(p1);
      //policyHolder.UserPolicies.Add(p2);
      //context.SaveChanges();
    }

    public AuthorizedUser CreateUser(string userName, 
                                     string email, 
                                     EDeviceClaimsContext context, 
                                     string role = ApplicationRoles.PolicyHolder,
                                     string firstName = "",
                                     string lastName = "")
    {
      var userStore = new UserStore<AuthorizedUser>(context);
      var userManager = new UserManager<AuthorizedUser>(userStore);

      var user = userManager.FindByEmail(email);

      if (user != null) return user;

      user = new AuthorizedUser { UserName = userName, Email = email, FirstName = firstName, LastName = lastName};
      userManager.Create(user, "password");
      userManager.AddToRole(user.Id, role);
      return user;
    }
  }
}
