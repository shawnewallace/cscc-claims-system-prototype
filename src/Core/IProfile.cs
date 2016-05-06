using System.Security.Cryptography.X509Certificates;

namespace EDeviceClaims.Core
{
  public interface IProfile
  {
    string FirstName { get; set; }
    string LastName { get; set; }
    string Nickname { get; set; }
  }
}