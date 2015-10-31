using System.Collections.Generic;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Domain.Models
{
  public class UserPolicies : List<PolicyDomainModel>
  {
    public UserPolicies(IEnumerable<Policy> policyEntities) : this()
    {
      foreach (var entity in policyEntities)
      {
        Add(new PolicyDomainModel(entity));
      }
    }

    public UserPolicies()
    {
      Addresses = new List<AddressDomainModel>();
    }

    public List<AddressDomainModel> Addresses { get; set; } 
  }
}