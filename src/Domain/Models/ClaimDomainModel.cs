using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Domain.Models
{
  public class ClaimDomainModel
  {
    public ClaimDomainModel(ClaimEntity newClaim)
    {
      Id = newClaim.Id;
      Status = newClaim.Status;
      LastUpdated = newClaim.WhenLastModified;
      Notes = newClaim.Notes;
    }

    public Guid Id { get; set; }
    public string Status { get; set; }
    public DateTime? LastUpdated { get; set; }
    public string Notes { get; set; }
  }
}
