using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDeviceClaims.Entities
{
  [Table("addresses", Schema = "app")]
  public class AddressEntity : EntityBaseWithUser<Guid>
  {
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
  }

  public abstract class EntityBaseWithUser<T> : EntityBase<T>
  {
    [Column("AuthorizedUser_Id")]
    public string UserId { get; set; }
    public AuthorizedUser User { get; set; }
  }
}
