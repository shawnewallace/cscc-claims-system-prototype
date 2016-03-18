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

    public PolicyDomainModel(PolicyEntity policyEntityEntity)
    {
      Id = policyEntityEntity.Id;
      Number = policyEntityEntity.Number;
      SerialNumber = policyEntityEntity.SerialNumber;
      DeviceName = policyEntityEntity.DeviceName;
    }

    public Guid Id { get; set; }

    public string Number { get; set; }

    public string DeviceName { get; set; }

    public string SerialNumber { get; set; }
  }
}
