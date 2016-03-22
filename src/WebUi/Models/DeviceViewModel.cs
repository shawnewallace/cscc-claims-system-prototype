using System;
using System.Linq;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Models
{
  public class DeviceViewModel
  {
    public DeviceViewModel(PolicyDomainModel thing)
    {
      PolicyId = thing.Id;
      PolicyNumber = thing.Number;
      SerialNumber = thing.SerialNumber;
      Name = thing.DeviceName;
      HasExistingClaim = thing.Claims.Any();
    }

    public string Name { get; set; }

    public string SerialNumber { get; set; }

    public string PolicyNumber { get; set; }

    public Guid PolicyId { get; set; }

    public bool HasExistingClaim { get; set; }
  }
}