using System;
using System.Web.Mvc;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Models;

namespace EDeviceClaims.WebUi.Controllers
{
  public class ClaimController : AppController
  {
    private IClaimService _claimService = new ClaimService();

    public ActionResult Start(Guid id)
    {
      var claimDomainModel = _claimService.Start(id);
      var model = new ClaimViewModel(claimDomainModel);

      return View(model);
    }
  }
}