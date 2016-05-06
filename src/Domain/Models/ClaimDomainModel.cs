using System;
using System.Collections.Generic;
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

      if (claim.Policy?.User == null) return;

      FirstName = claim.Policy.User.FirstName;
      LastName = claim.Policy.User.LastName;

      foreach (var note in claim.Notes)
      {
        Notes.Add(new NoteDomainModel(note));
      }
    }

    public List<NoteDomainModel> Notes { get; set; } = new List<NoteDomainModel>();
    public string UserId { get; set; }
    public DateTime WhenStarted { get; set; }
    public Guid Id { get; set; }
    public PolicyDomainModel Policy { get; set; }
    public ClaimStatus Status { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}