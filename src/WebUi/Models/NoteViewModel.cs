using System;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Models
{
  public class NoteViewModel
  {
    public NoteViewModel()
    {
    }

    public NoteViewModel(NoteDomainModel note)
    {
      Content = note.Body;
      WhenCreated = note.WhenAdded;
      CreatedBy = $"{note.CreatorFirstName} {note.CreatorLastName}";
    }

    public string Content { get; set; }
    public DateTime? WhenCreated { get; set; }
    public string CreatedBy { get; set; }
  }
}