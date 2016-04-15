using System;
using EDeviceClaims.Core;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Domain.Models
{
  public class ClaimDomainModel
  {
    public ClaimDomainModel(ClaimEntity claim)
    {
      Id = claim.Id;
      WhenStarted = claim.WhenCreated;
      Policy = new PolicyDomainModel(claim.Policy);
      Status = claim.Status;
      UserId = claim.Policy.UserId;
    }

    public string UserId { get; set; }

    public DateTime WhenStarted { get; set; }

    public Guid Id { get; set; }
    public PolicyDomainModel Policy { get; set; }
    public ClaimStatus Status { get; set; }
  }
}