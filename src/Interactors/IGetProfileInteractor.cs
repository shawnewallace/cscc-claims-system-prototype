using EDeviceClaims.Core;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

namespace EDeviceClaims.Interactors
{
  public interface IGetProfileInteractor
  {
    IProfile GetByUserId(string userId);
  }

  public class GetProfileInteractor : IGetProfileInteractor
  {
    private IProfileRepository Repo
    {
      get { return _repo ?? (_repo = new ProfileRepository()); }
      set { _repo = value; }
    }
    private IProfileRepository _repo;


    public GetProfileInteractor() { }

    public GetProfileInteractor(IProfileRepository profileRepo)
    {
      _repo = profileRepo;
    }

    public IProfile GetByUserId(string userId)
    {
      return Repo.GetById(userId);
    }
  }
}