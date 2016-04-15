﻿using System.Collections.Generic;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Models
{
  public class DeviceListViewModel : List<DeviceViewModel>
  {
    public DeviceListViewModel(IEnumerable<PolicyWithClaimsDomainModel> domainModel)
    {
      foreach (var thing in domainModel)
      {
        Add(new DeviceViewModel(thing));
      }
    }
  }
}