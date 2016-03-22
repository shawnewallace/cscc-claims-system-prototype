using System;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Interactors
{
  public interface ICreateClaimInteractor
  {
    ClaimEntity Execute(Guid id);
  }

  public class CreateClaimInteractor : ICreateClaimInteractor
  {
    public ClaimEntity Execute(Guid id)
    {
      return new ClaimEntity() { Id = Guid.NewGuid(), PolicyId = id };
    }
  }
}