using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.Domain.Services
{
  public interface IClaimsService
  {
    ClaimDomainModel StartClaim(Guid policyId);
  }

  public class ClaimsService : IClaimsService
  {
    public ClaimDomainModel StartClaim(Guid policyId)
    {
      return new ClaimDomainModel();
    }
  }
}
