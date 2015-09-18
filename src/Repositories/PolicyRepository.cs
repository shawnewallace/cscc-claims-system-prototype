using System;
using System.Linq;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Repositories
{
  public interface IPolicyRepository : IEfRepository<Policy, Guid>
  {
    Policy GetByPolicyNumber(string number);
  }

  public class PolicyRepository : EfRepository<Policy, Guid>, IPolicyRepository
  {
    public Policy GetByPolicyNumber(string number)
    {
      return ObjectSet
        .FirstOrDefault(p => p.Number.ToLower() == number.ToLower());
    }
  }
}