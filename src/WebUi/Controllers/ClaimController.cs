using System;
using System.Web.Mvc;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Models;

namespace EDeviceClaims.WebUi.Controllers
{
  [Authorize]
  public class ClaimController : AppController
  {
    private IClaimsService _claimsService = new ClaimsService();

    public ActionResult Start(Guid id)
    {
      var domainModel = _claimsService.StartClaim(id);
      var model = new ClaimViewModel(domainModel);
      return View("Details", model);
    }

    public ActionResult Details(Guid id)
    {
      throw new NotImplementedException();
    }
  }
}