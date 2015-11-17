using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeviceClaims.Entities
{
  [Table("policies", Schema = "app")]
  public class Policy : EntityBaseWithUser<Guid>
  {
    [Required, StringLength(20)] public string Number { get; set; }
    [Required, StringLength(50)] public string SerialNumber { get; set; }
    [Required, StringLength(30)] public string DeviceName { get; set; }
    [Required, StringLength(255)] public string CustomerEmail { get; set; }
    public virtual List<ClaimEntity> Claims { get; set; } 
  }


}