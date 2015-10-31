using System;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Domain.Models
{
  public class AddressDomainModel
  {
    public AddressDomainModel(AddressEntity addressEntity)
    {
      Id = addressEntity.Id;
      Street1 = addressEntity.Street1;
      Street2 = addressEntity.Street2;
      City = addressEntity.City;
      State = addressEntity.State;
      ZipCode = addressEntity.ZipCode;
    }

    public AddressDomainModel()
    {
    }

    public Guid Id { get; set; }
    public string Street1 { get; set; }
    public string Street2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
  }
}