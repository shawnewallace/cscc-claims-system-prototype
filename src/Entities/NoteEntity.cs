using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeviceClaims.Entities
{
  [Table("notes", Schema = "app")]
  public class NoteEntity : EntityBase<Guid>
  {
    [Column("ClaimEntity_ID")] public Guid ClaimId { get; set; }
    public virtual ClaimEntity Claim { get; set; }
    [Column("AuthorizedUser_Id")] public string UserId { get; set; }
    public AuthorizedUser User { get; set; }
    public string Content { get; set; }
  }
}