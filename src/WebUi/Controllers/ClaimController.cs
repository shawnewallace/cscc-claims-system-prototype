using System;
using System.Web.Mvc;
using EDeviceClaims.Core;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Models;

namespace EDeviceClaims.WebUi.Controllers
{
  [Authorize(Roles = ApplicationRoles.PolicyHolder )]
  public class ClaimController : AppController
  {
    private IClaimService _claimService = new ClaimService();

    public ActionResult Start(Guid id)
    {
      var claimDomainModel = _claimService.Start(id);
      var model = new ClaimViewModel(claimDomainModel);

      return View(model);
    }

    public ActionResult Edit(Guid id)
    {
      try
      {
        var claimDomainModel = _claimService.GetById(id);
        var model = new ClaimViewModel(claimDomainModel);
        return View(model);
      }
      catch (ArgumentException)
      {
        return View(new ClaimViewModel());
      }
    }
  }
}