using System;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Domain.Models
{
  public class ClaimDomainModel
  {
    public ClaimDomainModel(ClaimEntity claim)
    {
      Id = claim.Id;
      WhenStarted = claim.WhenCreated;
    }

    public DateTime WhenStarted { get; set; }

    public Guid Id { get; set; }
  }
}