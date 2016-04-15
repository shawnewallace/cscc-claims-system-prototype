using System;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

namespace EDeviceClaims.Interactors
{
  public interface ICreateClaimInteractor
  {
    ClaimEntity Execute(Guid id);
  }

  public class CreateClaimInteractor : ICreateClaimInteractor
  {
    private IClaimRepository Repo {
      get { return _repo ?? (_repo = new ClaimRepository()); }
      set { _repo = value; }
    }
    private IClaimRepository _repo;

    public CreateClaimInteractor() { }

    public CreateClaimInteractor(IClaimRepository claimRepo)
    {
      _repo = claimRepo;
    }

    public ClaimEntity Execute(Guid id)
    {
      var newClaim = new ClaimEntity() { Id = Guid.NewGuid(), PolicyId = id };
      newClaim = Repo.Create(newClaim);

      return newClaim;
    }
  }
}