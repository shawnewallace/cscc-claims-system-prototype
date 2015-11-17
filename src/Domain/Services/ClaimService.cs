using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Interactors;

namespace EDeviceClaims.Domain.Services
{
  public interface IClaimService
  {
    ClaimDomainModel StartClaim(Guid id);
  }
  public class ClaimService : IClaimService
  {
    private IGetPolicyInteractor _getPolicyInteractor = new GetPolicyInteractor();
    private ICreateClaimInteractor _createClaimInteractor = new CreateClaimInteractor();

    public ClaimDomainModel StartClaim(Guid id)
    {
      //get the policy
      var policy = _getPolicyInteractor.GetById(id);
      if (policy == null) return null;

      //check the business rules
      //create new claim
      _createClaimInteractor.PolicyId = policy.Id;
      _createClaimInteractor.UserId = policy.UserId;

      var newClaim = _createClaimInteractor.Execute();

      return new ClaimDomainModel(newClaim);
    }
  }
}
