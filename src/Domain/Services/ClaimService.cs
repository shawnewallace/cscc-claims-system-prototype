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
    ClaimDomainModel Start(Guid id);
  }

  public class ClaimService : IClaimService
  {

    private IGetPolicyInteractor GetPolicyInteractor
    {
      get { return _getPolicyInteractor ?? (_getPolicyInteractor = new GetPolicyInteractor()); }
      set { _getPolicyInteractor = value; }
    }
    private IGetPolicyInteractor _getPolicyInteractor;

    public ICreateClaimInteractor CreateClaimInteractor
    {
      get { return _createClaimInteractor ?? (_createClaimInteractor = new CreateClaimInteractor()); }
      set { _createClaimInteractor = value; }
    }
    private ICreateClaimInteractor _createClaimInteractor;

    public ClaimDomainModel Start(Guid id)
    {
      var policy = GetPolicyInteractor.GetById(id);
      if (policy == null) throw new ArgumentException("Policy does not exist");

      var claim = CreateClaimInteractor.Execute(id);

      return new ClaimDomainModel(claim);
    }
  }
}
