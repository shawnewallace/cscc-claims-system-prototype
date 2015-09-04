using System;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Repositories
{
  public interface IPolicyRepository : IEfRepository<Policy, Guid>
  {
  }

  public class PolicyRepository : EfRepository<Policy, Guid>, IPolicyRepository
  {
  }
}