using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Models
{
  public class DeviceViewModel
  {
    public DeviceViewModel(PolicyWithClaimsDomainModel policy)
    {
      PolicyId = policy.Id;
      PolicyNumber = policy.Number;
      SerialNumber = policy.SerialNumber;
      Name = policy.DeviceName;
      MostCurrentClaim = (policy.Claims.Any())
        ? new ClaimViewModel(policy.Claims.First())
        : null;

    }

    public ClaimViewModel MostCurrentClaim { get; set; }

    public string Name { get; set; }

    public string SerialNumber { get; set; }

    public string PolicyNumber { get; set; }

    public Guid PolicyId { get; set; }

    public bool ShowViewClaimButton()
    {
      return MostCurrentClaim != null;
    }
  }
}