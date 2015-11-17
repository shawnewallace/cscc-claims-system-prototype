using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Repositories
{
  public interface IClaimsRepository : IEfRepository<ClaimEntity, Guid>
  {
  }

  public class ClaimsRepository : EfRepository<ClaimEntity, Guid>, IClaimsRepository
  {
    public ClaimsRepository() : base(new EDeviceClaimsUnitOfWork())
    {
    }

    public ClaimsRepository(IEfUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
  }
}
