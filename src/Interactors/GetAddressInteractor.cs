using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

namespace EDeviceClaims.Interactors
{
  public interface IGetAddressInteractor
  {
    List<AddressEntity> GetByUserId(string userId);
  }

  public class GetAddressInteractor : IGetAddressInteractor
  {
    private IAddressRepository AddressRepo
    {
      get { return _addressRepo ?? (_addressRepo = new AddressRepository()); }
      set { _addressRepo = value; }
    }
    private IAddressRepository _addressRepo;

    public GetAddressInteractor()
    {
    }

    public GetAddressInteractor(IAddressRepository addressRepo)
    {
      AddressRepo = addressRepo;
    }

    public List<AddressEntity> GetByUserId(string userId)
    {
      return AddressRepo.GetByUserId(userId);
    }
  }
}
