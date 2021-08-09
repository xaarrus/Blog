using Blog.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Client.Services.NoteService
{
    public interface INoteService
    {
        event Action OnChange;
        Task AddNoteToStorage(Note note);
        Task NoteStatusChange(int id, bool status);
        Task DeleteNote(Note note);
        Task<List<Note>> GetAllNotes();
    }
}
