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
      Claims = new List<ClaimDomainModel>();

      foreach (var claim in policyEntity.Claims)
      {
        Claims.Add(new ClaimDomainModel(claim));
      }
    }

    public List<ClaimDomainModel> Claims { get; set; }

    public Guid Id { get; set; }

    public string Number { get; set; }

    public string DeviceName { get; set; }

    public string SerialNumber { get; set; }
  }
}
