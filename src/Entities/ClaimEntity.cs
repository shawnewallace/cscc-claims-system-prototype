using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EDeviceClaims.Core;

namespace EDeviceClaims.Entities
{
  [Table("claims", Schema = "app")]
  public class ClaimEntity : EntityBase<Guid>
  {
    public Guid PolicyId { get; set; }
    public virtual PolicyEntity Policy { get; set; }
    public ClaimStatus Status { get; set; } = ClaimStatus.Open;
    public virtual List<NoteEntity> Notes { get; set; } = new List<NoteEntity>();
  }
}