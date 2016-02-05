using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Interactors;

namespace EDeviceClaims.Domain.Services
{
  public interface IClaimsService
  {
    ClaimDomainModel StartClaim(Guid policyId);
  }

  public class ClaimsService : IClaimsService
  {

    private IGetPolicyInteractor GetPolicyInteractor
    {
      get { return _getPolicyInteractor ?? (_getPolicyInteractor = new GetPolicyInteractor()); }
      set { _getPolicyInteractor = value; }
    }
    private IGetPolicyInteractor _getPolicyInteractor;

    private IGetClaimsInteractor GetClaimsInteractor
    {
      get { return _getClaimsInteractor ?? (_getClaimsInteractor = new GetClaimsInteractor()); }
      set { _getClaimsInteractor = value; }
    }
    private IGetClaimsInteractor _getClaimsInteractor;


    public ClaimDomainModel StartClaim(Guid policyId)
    {
      // get a policy
      var policy = _getPolicyInteractor.GetById(policyId);
      if (policy == null) throw new ArgumentException("Policy for that Policy Id does not exist.");

      // if the policy does not have a claim, create a claim and return the claim
      var existingClaim = _getClaimsInteractor.GetByPolicyId(policyId);

      // if the policy has a claim, reutrn the claim
      
      return new ClaimDomainModel();
    }
  }
}
