using System.Collections.Generic;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Models
{
  public class DeviceListViewModel : List<DeviceViewModel>
  {
    public List<AddressViewModel> Addresses { get; set; }

    public DeviceListViewModel(UserPolicies domainModel)
    {
      foreach (var thing in domainModel)
      {
        Add(new DeviceViewModel(thing));
      }

      Addresses = new List<AddressViewModel>();
      foreach (var address in domainModel.Addresses)
      {
        Addresses.Add(new AddressViewModel(address));
      }
    }

  }

  public class AddressViewModel : AddressDomainModel
  {
    public AddressViewModel(AddressDomainModel address) : base()
    {
      Id = address.Id;
      Street1 = address.Street1;
      Street2 = address.Street2;
      City = address.City;
      State = address.State;
      ZipCode = address.ZipCode;
    }
  }
}