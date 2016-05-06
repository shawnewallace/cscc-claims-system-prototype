using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Core;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Repositories
{
  public interface IClaimRepository : IEfRepository<ClaimEntity, Guid>
  {
    List<ClaimEntity> GetAllOpen();
    ClaimEntity GetByIdWithNotes(Guid id);
  }

  public class ClaimRepository : EfRepository<ClaimEntity, Guid>, IClaimRepository
  {
    public ClaimRepository() : base(new EDeviceClaimsUnitOfWork())
    {
    }

    public ClaimRepository(IEfUnitOfWork unitOfWork) : base(unitOfWork) { }

    public new ClaimEntity GetById(Guid id)
    {
      return ObjectSet.Where(c => c.Id == id)
        .Include(c => c.Policy)
        .FirstOrDefault();
    }

    public List<ClaimEntity> GetAllOpen()
    {
      return ObjectSet.Where(c => c.Status == ClaimStatus.Open)
        .Include(c => c.Policy)
        .Include(c => c.Policy.User)
        .ToList();
    }

    public ClaimEntity GetByIdWithNotes(Guid id)
    {
      return ObjectSet.Where(c => c.Id == id)
              .Include(c => c.Notes.Select(n => n.User))
              .FirstOrDefault();
    }
  }
}
