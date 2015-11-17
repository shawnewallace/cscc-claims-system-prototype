﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Domain.Models
{
  public class PolicyDomainModel
  {

    public PolicyDomainModel(Policy policyEntity)
    {
      Id = policyEntity.Id;
      Number = policyEntity.Number;
      SerialNumber = policyEntity.SerialNumber;
      DeviceName = policyEntity.DeviceName;
      Claims = policyEntity.Claims;
    }

    public List<ClaimEntity> Claims { get; set; }

    public Guid Id { get; set; }

    public string Number { get; set; }

    public string DeviceName { get; set; }

    public string SerialNumber { get; set; }
  }
}
