using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Core;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Domain.Models
{
  public class PolicyDomainModel
  {
    public PolicyDomainModel(PolicyEntity policyEntity)
    {
      Id = policyEntity.Id;
      Number = policyEntity.Number;
      SerialNumber = policyEntity.SerialNumber;
      DeviceName = policyEntity.DeviceName;
    }

    public Guid Id { get; set; }

    public string Number { get; set; }

    public string DeviceName { get; set; }

    public string SerialNumber { get; set; }
  }

  public class PolicyWithClaimsDomainModel : PolicyDomainModel
  {
    public PolicyWithClaimsDomainModel(PolicyEntity policyEntity) : base(policyEntity)
    {
      LoadClaims(policyEntity.Claims);
    }

    private void LoadClaims(IReadOnlyCollection<ClaimEntity> claims)
    {
      if (claims == null) return;

      foreach (var claim in claims)
      {
        Claims.Add(new ClaimDomainModel(claim));
      }
    }

    public List<ClaimDomainModel> Claims { get; set; } = new List<ClaimDomainModel>();

    
  }
}
