using EDeviceClaims.Core;

namespace EDeviceClaims.Domain.Models
{
  public class ProfileDomainModel
  {
    public ProfileDomainModel(IProfile profileEntity)
    {
      FirstName = profileEntity.FirstName;
      LastName = profileEntity.LastName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}