using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Soft_Nudge.Data.Entites;
using Soft_Nudge.Data.Soft_NudgeContext;
using Soft_Nudge.Models.NoteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Services.NoteServices
{
    public class NoteService : INoteService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        private string _ownerId;

        public void SetOwnerId(string ownerId)
        { _ownerId = ownerId; }

        public NoteService(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;

            var userClaims = httpContext.HttpContext!.User.Identity as ClaimsIdentity;
            var value = userClaims!.Claims.FirstOrDefault();

            _ownerId = value!.Value;
            if (_ownerId is null)
            {
                throw new Exception("User is not signed in.");
            }
        }

        public async Task<bool> CreateNote(NoteCreate model)
        {
            var note = _mapper.Map<Note>(model);
            note.OwnerId = _ownerId;
            note.NoteCreatedDate = DateTime.Now;

            await _context.Notes.AddAsync(note);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteNote(int id)
        {
            var note = await _context.Notes.Where(x => x.OwnerId == _ownerId).SingleOrDefaultAsync(y => y.Id == id);

            if (note?.OwnerId != _ownerId) 
            { return false; }

            if (note is null)
            { return false; }

            _context.Notes.Remove(note);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<NoteDetail> GetNote(int id)
        {
            var note = await _context.Notes.Where(x => x.OwnerId == _ownerId).FirstOrDefaultAsync(y => y.Id == id);

            if (note?.OwnerId != _ownerId)
            { return null; }

            if (note is null)
            { return new NoteDetail(); }

            return _mapper.Map<NoteDetail>(note);
        }

        public async Task<List<NoteDetail>> GetNotes()
        {
            var notes = await _context.Notes
                .Include(n => n.ToDo)
                .Where(x => x.OwnerId == _ownerId).ToListAsync();
            foreach (var note in notes)
            {
                if (note?.OwnerId != _ownerId)
                { return null; }
            }

            var ownerHasNoNotes = notes.Any(x => x.OwnerId != _ownerId);
            if (ownerHasNoNotes)
            { return null; }
            else
            { return _mapper.Map<List<NoteDetail>>(notes); }
        }

        public async Task<bool> UpdateNote(NoteEdit model)
        {
            var note = await _context.Notes.FindAsync(model.Id);
            if (note is null)
            { return false; }

            note.Entry = model.Entry;
            note.DifficultyLevel = model.DifficultyLevel;
            note.NoteModifiedDate = DateTimeOffset.Now;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
