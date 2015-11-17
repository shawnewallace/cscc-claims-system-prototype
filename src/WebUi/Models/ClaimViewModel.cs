using System;
using System.Runtime.InteropServices.ComTypes;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Models
{
  public class ClaimViewModel
  {
    public ClaimViewModel(ClaimDomainModel domainModel)
    {
      Id = domainModel.Id;
      Status = domainModel.Status;
      LastUpdated = domainModel.LastUpdated;
      Notes = domainModel.Notes;
    }

    public string Notes { get; set; }

    public DateTime? LastUpdated { get; set; }

    public Guid Id { get; set; }
    public string Status { get; set; }
  }
}