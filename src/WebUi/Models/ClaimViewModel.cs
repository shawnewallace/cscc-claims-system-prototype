using System;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Models
{
  public class ClaimViewModel
  {
    public ClaimViewModel()
    {
    }

    public ClaimViewModel(ClaimDomainModel domainModel)
    {
      Id = domainModel.Id;
    }

    public Guid Id { get; set; }
  }
}