using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Blog.Shared.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Client.Services.NoteService
{
    public class NoteService : INoteService
    {
        private readonly ILocalStorageService _localstorage;
        private readonly IToastService _toastservice;

        public event Action OnChange;

        public NoteService(ILocalStorageService localstorage, IToastService toastservice)
        {
            _localstorage = localstorage;
            _toastservice = toastservice;
        }

        public async Task AddNoteToStorage(Note newnote)
        {
            if (newnote.Title == null || newnote.Title == "" || newnote.Description == null || newnote.Description == "")
            {
                _toastservice.ShowInfo("Задача должна содержать заголовок и описание!", "Важно");
                return;
            }
            var notes = await GetAllNotes();
            Note addnote = new Note
            {
                Id = notes.Count + 1,
                Title = newnote.Title,
                Description = newnote.Description,
                Status = false,
                DateCreate = DateTime.Now
            };
            var noteEdit = notes.Find(x => x.DateCreate == newnote.DateCreate);
            if (noteEdit != null)
            {
                noteEdit.Title = newnote.Title;
                noteEdit.Description = newnote.Description;
                _toastservice.ShowSuccess($"Задача изменена", noteEdit.Title);
                await _localstorage.SetItemAsync("notes", notes);
                OnChange.Invoke();
                return;
            }
            if (notes.Exists(x => x.Title == newnote.Title) == true)
            {
                _toastservice.ShowWarning(newnote.Title, "Такая заметка уже существует");
                return;
            }
            else
            {
                notes.Add(addnote);
                await _localstorage.SetItemAsync("notes", notes);
                _toastservice.ShowSuccess(addnote.Title, "Задача добавлена!");
            }
            OnChange.Invoke();
        }
        public async Task NoteStatusChange(int id, bool status)
        {
            var notes = await GetAllNotes();
            if (notes.Count <= 0) { return; }
            var noteItem = notes.Find(x => x.Id == id);
            if (noteItem.Status != status)
            {
                noteItem.Status = !noteItem.Status;
                string newstatus = noteItem.Status == true ? "выполнено" : "не выполнено";
                _toastservice.ShowSuccess($"Статус задачи изменен на {newstatus}", noteItem.Title);
                await _localstorage.SetItemAsync("notes", notes);
                OnChange.Invoke();
            }
            else
            {
                _toastservice.ShowSuccess($"Не удалось изменить статус задачи {noteItem.Title} : {noteItem.Status} на {status}.");
                return;
            }
        }
        public async Task DeleteNote(Note note)
        {
            var notes = await GetAllNotes();
            if (notes.Count <= 0) { return; }
            var noteItem = notes.Find(x => x.Title == note.Title);
            _toastservice.ShowSuccess(note.Title, "Задача удалена");
            notes.Remove(noteItem);
            await _localstorage.SetItemAsync("notes", notes);
            OnChange.Invoke();
        }
        public async Task<List<Note>> GetAllNotes()
        {
            List<Note> Notes = await _localstorage.GetItemAsync<List<Note>>("notes");
            if (Notes == null)
            {
                Notes = new List<Note>();
            }
            return Notes;
        }
    }
}
