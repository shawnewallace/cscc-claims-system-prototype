using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;
using EDeviceClaims.Repositories.Contexts;
using NUnit.Framework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EDeviceClaims.Domain.Integration.Tests
{
  public class RepositoryTestBase<TContext> where TContext : EDeviceClaimsContext, new()
  {
    protected AuthorizedUser User;

    [TestFixtureSetUp]
    public void SetUp()
    { 
      Database.SetInitializer(new DropCreateDatabaseAlways<TContext>());

      using (var db = new EDeviceClaimsContext())
      {
        User = CreateUser("policyholder@company.com", "policyholder@company.com", db);
        AddPolicies(db, User);
      }
    }

    protected void AddPolicies(EDeviceClaimsContext db, AuthorizedUser user)
    {
        db.Policies.Add(new Policy { Id = Guid.NewGuid(), Number = "11121", SerialNumber = "MNOPQ", DeviceName = "iPhone 6+", CustomerEmail = "d@b.com", UserId = user.Id });
        db.Policies.Add(new Policy { Id = Guid.NewGuid(), Number = "11122", SerialNumber = "ABCDE", DeviceName = "iPhone 6+", CustomerEmail = "d@b.com", UserId = user.Id });
        db.Policies.Add(new Policy { Id = Guid.NewGuid(), Number = "11123", SerialNumber = "EDCBA", DeviceName = "iPhone 6+", CustomerEmail = "d@b.com" });

        db.SaveChanges();
    }

    protected AuthorizedUser CreateUser(string userName, string email, EDeviceClaimsContext context)
    {
      var userStore = new UserStore<AuthorizedUser>(context);
      var userManager = new UserManager<AuthorizedUser>(userStore);

      var user = userManager.FindByEmail(email);

      if (user != null) return user;

      user = new AuthorizedUser { UserName = userName, Email = email };
      userManager.Create(user, "password");

      context.SaveChanges();

      return user;
    }
  }
}
