using System;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Domain.Models
{
  public class NoteDomainModel
  {
    public NoteDomainModel(NoteEntity note)
    {
      WhenAdded = note.WhenCreated;
      UserId = note.UserId;
      Body = note.Content;
      CreatorFirstName = note.User.FirstName;
      CreatorLastName = note.User.LastName;
    }

    public string CreatorLastName { get; set; }

    public string CreatorFirstName { get; set; }

    public string Body { get; set; }

    public string UserId { get; set; }

    public DateTime WhenAdded { get; set; }
  }
}