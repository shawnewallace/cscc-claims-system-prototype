using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Interactors;

namespace EDeviceClaims.Domain.Services
{
  public interface IPolicyService
  {
    UserPolicies GetByUserId(string userId);
  }

  public class PolicyService : IPolicyService
  {

    private IGetPolicyInteractor GetPolicyInteractor
    {
      get { return _getPolicyInteractor ?? (_getPolicyInteractor = new GetPolicyInteractor()); }
      set { _getPolicyInteractor = value; }
    }
    private IGetPolicyInteractor _getPolicyInteractor;

    private IGetAddressInteractor GetAddressesInteractor
    {
      get { return _getAddressesInteractor ?? (_getAddressesInteractor = new GetAddressInteractor()); }
      set { _getAddressesInteractor = value; }
    }
    private IGetAddressInteractor _getAddressesInteractor;

    public PolicyService()
    {
    }

    public PolicyService(IGetPolicyInteractor getPolicyInteractor, IGetAddressInteractor getAddressInteractor)
    {
      GetPolicyInteractor = getPolicyInteractor;
      GetAddressesInteractor = getAddressInteractor;
    }

    public UserPolicies GetByUserId(string userId)
    {
      var policyEntities = GetPolicyInteractor.GetByUserId(userId);
      var userAddresses = GetAddressesInteractor.GetByUserId(userId);

      var result = new UserPolicies(policyEntities);

      foreach (var address in userAddresses)
      {
        result.Addresses.Add(new AddressDomainModel(address));
      }

      return result;
    }
  }
}
