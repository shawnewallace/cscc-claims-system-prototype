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
    ClaimDomainModel GetById(Guid id);
    List<ClaimDomainModel> GetAllOpen();
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

    public IGetClaimInteractor GetClaimInteractor
    {
      get { return _getClaimInteractor ?? (_getClaimInteractor = new GetClaimInteractor()); }
      set { _getClaimInteractor = value; }
    }
    private IGetClaimInteractor _getClaimInteractor;

    public ClaimDomainModel Start(Guid id)
    {
      var policy = GetPolicyInteractor.GetById(id);
      if (policy == null) throw new ArgumentException("Policy does not exist");

      var claim = CreateClaimInteractor.Execute(id);

      if (claim.Policy == null) claim.Policy = GetPolicyInteractor.GetById(claim.PolicyId);

      return new ClaimDomainModel(claim);
    }

    public ClaimDomainModel GetById(Guid id)
    {
      var claim = GetClaimInteractor.Execute(id);
      if(claim == null) throw new ArgumentException("Claim does not exist");

      return new ClaimDomainModel(claim);
    }

    public List<ClaimDomainModel> GetAllOpen()
    {
      var openClaims = GetClaimInteractor.GetAllOpen();

      return openClaims
        .Select(claim => new ClaimDomainModel(claim))
        .ToList();
    }
  }
}
