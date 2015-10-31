using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeviceClaims.Entities
{
  [Table("addresses", Schema = "app")]
  public class AddressEntity : EntityWithUserBase<Guid>
  {
    public string Street1 { get; set; }
    public string Street2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
  }
}