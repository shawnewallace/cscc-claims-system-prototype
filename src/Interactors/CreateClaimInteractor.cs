using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

namespace EDeviceClaims.Interactors
{
  public interface ICreateClaimInteractor
  {
    Guid PolicyId { get; set; }
    string UserId { get; set; }
    ClaimEntity Execute();
  }

  public class CreateClaimInteractor : ICreateClaimInteractor
  {
    private IClaimsRepository _claimsRepo = new ClaimsRepository();

    public Guid PolicyId { get; set; }
    public string UserId { get; set; }
    public ClaimEntity Execute()
    {
      var newClaim = new ClaimEntity
      {
        Id = Guid.NewGuid(),
        Status = "NEW",
        PolicyId = PolicyId,
        UserId = UserId
      };

      var result = _claimsRepo.Create(newClaim);
      _claimsRepo.EfUnitOfWork.Context.SaveChanges();
      return result;
    }
  }
}
