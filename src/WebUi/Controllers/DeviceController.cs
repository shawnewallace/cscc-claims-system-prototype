﻿using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDeviceClaims.Core;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Models;

namespace EDeviceClaims.WebUi.Controllers
{
  [Authorize(Roles = ApplicationRoles.PolicyHolder)]
  public class DeviceController : AppController
  {
    private IPolicyService _policyService = new PolicyService();

    public ActionResult Index()
    {
      var domainModel = _policyService.GetByUserId(CurrentUserId);
      var model = new DeviceListViewModel(domainModel);

      return View(model);
    }
  }
}