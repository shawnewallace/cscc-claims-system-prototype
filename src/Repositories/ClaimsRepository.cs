using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Repositories
{
  public interface IClaimsRepository : IEfRepository<ClaimEntity, Guid>
  {
    ClaimEntity GetByPolicyId(Guid policyId);
  }

  public class ClaimsRepository : EfRepository<ClaimEntity, Guid>, IClaimsRepository
  {
    public ClaimEntity GetByPolicyId(Guid policyId)
    {
      return ObjectSet
        .FirstOrDefault(c => c.PolicyId == policyId);
    }
  }
}
