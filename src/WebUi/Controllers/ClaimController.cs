using System;
using System.Web.Mvc;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Models;

namespace EDeviceClaims.WebUi.Controllers
{
  public class ClaimController : AppController
  {
    private IClaimService _claimsService = new ClaimService();

    public ActionResult Create(Guid id)
    {
      var domainModel = _claimsService.StartClaim(id);
      var model = new ClaimViewModel(domainModel);
      return View(model);
    }

    public ActionResult Status(Guid id)
    {
      throw new NotImplementedException();
    }
  }
}