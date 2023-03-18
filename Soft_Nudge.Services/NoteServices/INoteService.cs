using Soft_Nudge.Models.NoteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Services.NoteServices
{
    public interface INoteService
    {
        Task<bool> CreateNote(NoteCreate model);
        Task<bool> UpdateNote(NoteEdit model);
        Task<bool> DeleteNote(int id);
        Task<NoteDetail> GetNote(int id);
        Task<List<NoteDetail>> GetNotes();
        
    }
}
