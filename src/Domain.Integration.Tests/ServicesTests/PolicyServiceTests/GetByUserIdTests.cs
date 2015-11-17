using System;
using System.Data.Entity;
using System.Linq;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories.Contexts;
using NUnit.Framework;

namespace EDeviceClaims.Domain.Integration.Tests.ServicesTests.PolicyServiceTests
{
  [TestFixture]
  public class GetByUserIdTests : RepositoryTestBase<EDeviceClaimsContext>
  {
    private PolicyService _service;

    [SetUp]
    public void SetUpFixture()
    {
      _service = new PolicyService();
    }

    [Test]
    public void it_returns_the_policies_for_the_user()
    {
      var result = _service.GetByUserId(User.Id);
      Assert.GreaterOrEqual(result.Count(), 2);
    }

    [Test]
    public void it_returnes_zerp_policies_when_the_user_id_does_not_exist()
    {
      var result = _service.GetByUserId("NOT FOUND");
      Assert.IsEmpty(result);
    }
  }
}
