﻿using System;
using System.Collections;
using System.Collections.Generic;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;
using EDeviceClaims.Repositories.Migrations;

namespace EDeviceClaims.Interactors
{
  public interface IGetPolicyInteractor
  {
    Policy GetById(Guid id);
    Policy GetByNumber(string number);
    ICollection<Policy> GetByCustomerEmailAdress(string email);
  }

  public class GetPolicyInteractor : IGetPolicyInteractor
  {
    private readonly IPolicyRepository _repo;

    public GetPolicyInteractor(IPolicyRepository policyRepo)
    {
      _repo = policyRepo;
    }

    public Policy GetById(Guid id)
    {
      return _repo.GetById(id);
    }

    public Policy GetByNumber(string number)
    {
      return _repo.GetByPolicyNumber(number);
    }

    public ICollection<Policy> GetByCustomerEmailAdress(string email)
    {
      throw new NotImplementedException();
    }
  }

  //public interface IGetContacts : IInteractor,
  //  ICommandWithReturn<List<ContactEntity>>,
  //  ICommandWithReturn<ContactEntity, Guid>,
  //  ICommandWithReturn<List<ContactEntity>, string>
  //{
  //  ContactEntity FindByEmail(string email);
  //  ContactEntity GetByProfileId(Guid profileId);
  //  ContactEntity FindByName(string firstName, string lastName);
  //  ContactEntity FindBySourceKey(string key);
  //}

  //public class GetContacts : IGetContacts
  //{
  //  private IContactRespository _repo;
  //  public ICollection<ValidationResult> ErrorMessages { get; set; }

  //  public GetContacts(IContactRespository policyRepo)
  //  {
  //    _repo = policyRepo;
  //  }

  //  public List<ContactEntity> Execute()
  //  {
  //    return _repo.GetAll().ToList();
  //  }

  //  public ContactEntity Execute(Guid id)
  //  {
  //    return _repo.GetById(id);
  //  }

  //  public List<ContactEntity> Execute(string id)
  //  {
  //    return _repo.FindByName(id);
  //  }

  //  public ContactEntity FindByEmail(string email)
  //  {
  //    if (email == null) return null;

  //    return _repo.FindByEmail(email);
  //  }

  //  public ContactEntity GetByProfileId(Guid profileId)
  //  {
  //    return _repo.GetByProfileId(profileId);
  //  }

  //  public ContactEntity FindByName(string firstName, string lastName)
  //  {
  //    return _repo.FindByName(firstName, lastName);
  //  }

  //  public ContactEntity FindBySourceKey(string key)
  //  {
  //    return _repo.FindBySourceSystemKey(key);
  //  }
  //}
}
