using EDeviceClaims.Domain.Models;
using EDeviceClaims.Interactors;

namespace EDeviceClaims.Domain.Services
{
  public interface IProfileService
  {
    ProfileDomainModel GetProfileByUserId(string userId);
  }

  public class ProfileService : IProfileService
  {
    private IGetProfileInteractor _getProfileInteractor;

    private IGetProfileInteractor GetProfileInteractor
    {
      get { return _getProfileInteractor ?? (_getProfileInteractor = new GetProfileInteractor()); }
      set { _getProfileInteractor = value; }
    }

    public ProfileDomainModel GetProfileByUserId(string userId)
    {
      var profileEntity = GetProfileInteractor.GetByUserId(userId);

      return new ProfileDomainModel(profileEntity);
    }
  }
}