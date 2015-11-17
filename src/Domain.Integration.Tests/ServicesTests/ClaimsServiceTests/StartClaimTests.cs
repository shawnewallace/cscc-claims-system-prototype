using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories.Contexts;
using EDeviceClaims.Repositories.Migrations;
using NUnit.Framework;

namespace EDeviceClaims.Domain.Integration.Tests.ServicesTests.ClaimsServiceTests
{
  [TestFixture]
  public class StartClaimTests : RepositoryTestBase<EDeviceClaimsContext>
  {
    private ClaimService _service;
    private ClaimDomainModel _claim;
    private Policy _policy;

    [SetUp]
    public void SetUpFixture()
    {
      _service = new ClaimService();

      using (var db = new EDeviceClaimsContext())
      {
        _policy = db.Policies.FirstOrDefault(p => p.UserId == User.Id);
      }

      _claim = _service.StartClaim(_policy.Id);
    }

    [Test]
    public void it_assigns_an_id()
    {
      Assert.AreNotEqual(Guid.Empty, _claim.Id);
    }

    [Test]
    public void it_saves_in_the_database()
    {
      ClaimEntity claim;
      using (var db = new EDeviceClaimsContext())
      {
        claim = db.Claims.Find(_claim.Id);
      }

      Assert.IsNotNull(claim);
    }

    [Test]
    public void it_has_the_correct_user_and_policy()
    {
      ClaimEntity claim;
      using (var db = new EDeviceClaimsContext())
      {
        claim = db.Claims.Find(_claim.Id);
      }
      Assert.AreEqual(User.Id, claim.UserId);
      Assert.AreEqual(_policy.Id, claim.PolicyId);
    }
  }
}
