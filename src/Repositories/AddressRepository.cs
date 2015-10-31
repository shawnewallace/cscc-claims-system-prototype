using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Repositories
{
  public interface IAddressRepository : IEfRepository<AddressEntity, Guid>
  {
    List<AddressEntity> GetByUserId(string userId);
  }

  public class AddressRepository : EfRepository<AddressEntity, Guid>, IAddressRepository
  {
    public AddressRepository() : base(new EDeviceClaimsUnitOfWork())
    {
    }

    public AddressRepository(IEfUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public List<AddressEntity> GetByUserId(string userId)
    {
      return ObjectSet.Where(a => a.UserId == userId).ToList();
    }
  }
}
