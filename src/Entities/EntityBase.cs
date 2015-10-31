using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EDeviceClaims.Core;

namespace EDeviceClaims.Entities
{
  public class EntityBase<TKey> : IEntity<TKey>
  {
    [Key]
    public TKey Id { get; set; }

    public DateTime WhenCreated
    {
      get { return _whenCreated; }
      set { _whenCreated = value; }
    }
    private DateTime _whenCreated = DateTimeHelper.UtcNow;

    public DateTime? WhenLastModified { get; set; }
  }

  public abstract class EntityWithUserBase<TKey> : EntityBase<TKey>
  {
    [Column("AuthorizedUser_Id")]
    public string UserId { get; set; }
    public AuthorizedUser User { get; set; }
  }
}