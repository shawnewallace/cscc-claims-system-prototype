using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Areas.Underwriter.Models;

namespace EDeviceClaims.WebUi.Areas.Underwriter.Controllers
{
  public class ClaimsController : UnderwriterAppController
  {
    private IPolicyService _policyService = new PolicyService();
    private IClaimService _claimService = new ClaimService();

    // GET: Underwriter/Device
    public ActionResult Index()
    {
      var claims = _claimService.GetAllOpen();

      var model = new ClaimsListViewModel(claims);

      return View("Index", model);
    }
  }
}