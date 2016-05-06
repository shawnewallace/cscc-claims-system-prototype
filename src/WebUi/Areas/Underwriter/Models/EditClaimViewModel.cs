using System;
using System.Collections.Generic;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Web;
using System.Web.ClientServices.Providers;
using EDeviceClaims.Core;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.WebUi.Models;

namespace EDeviceClaims.WebUi.Areas.Underwriter.Models
{
  public class EditClaimViewModel
  {

    public EditClaimViewModel(ClaimDomainModel claim)
    {
      Id = claim.Id;
      FirstName = claim.FirstName;
      LastName = claim.LastName;
      PolicyId = claim.Policy.Id;
      Status = claim.Status;
      WhenStarted = claim.WhenStarted;

      Notes = new List<NoteViewModel>();
      foreach(var note in claim.Notes)
        Notes.Add(new NoteViewModel(note));
    }

    public List<NoteViewModel> Notes { get; set; }
    public DateTime WhenStarted { get; set; }
    public ClaimStatus Status { get; set; }
    public Guid PolicyId { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public Guid Id { get; set; }
  }
}