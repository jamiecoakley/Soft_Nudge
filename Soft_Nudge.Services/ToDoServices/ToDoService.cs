using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Soft_Nudge.Data.Entites;
using Soft_Nudge.Data.Soft_NudgeContext;
using Soft_Nudge.Models.ToDoModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Services.ToDoServices
{
    public class ToDoService : IToDoService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        private string _ownerId;

        public ToDoService(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;

            var userClaims = httpContext.HttpContext!.User.Identity as ClaimsIdentity;
            var value = userClaims!.Claims.FirstOrDefault();

            _ownerId = value!.Value;
            if(_ownerId is null)
            {
                throw new Exception("User is not signed in");
            }
        }

        public void SetOwnerId(string ownerId)
        { _ownerId = ownerId; }

        public async Task<bool> CreateToDo(ToDoCreate model)
        {
            var todo = _mapper.Map<ToDo>(model);
            todo.OwnerId = _ownerId;

            await _context.ToDos.AddAsync(todo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteToDo(int id)
        {
            var todo = await _context.ToDos.Where(x => x.OwnerId == _ownerId).SingleOrDefaultAsync(y => y.Id == id);

            if (todo?.OwnerId != _ownerId)
            { return false; }

            if (todo is null) 
            { return false; }

            _context.ToDos.Remove(todo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ToDoDetail> GetToDo(int id)
        {
            var todo = await _context.ToDos.Include(x => x.Category).Where(x => x.OwnerId == _ownerId).SingleOrDefaultAsync(y => y.Id == id);

            if (todo?.OwnerId != _ownerId) 
            { return null; }

            if (todo is null)
                return new ToDoDetail();

            return _mapper.Map<ToDoDetail>(todo);
        }

        public async Task<List<ToDoDetail>> GetToDosList()
        {
            var todos = await _context.ToDos.Include(x => x.Category).Include(x => x.ToDoEntries).Where(x => x.OwnerId == _ownerId).ToListAsync();

            foreach (var todo in todos)
            {
                if (todo?.OwnerId != _ownerId)
                { return null; }
            }

            var ownerHasNoList = todos.Any(x => x.OwnerId != _ownerId);
            if (ownerHasNoList)
            { return null; }
            else
            { return _mapper.Map<List<ToDoDetail>>(todos); }
        }

        public async Task<bool> UpdateToDo(ToDoEdit model)
        {
            var todo = await _context.ToDos.FindAsync(model.Id);
            if (todo is null)
            { return false; }

            todo.Action = model.Action;
            todo.CategoryId = model.CategoryId;
            
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ToDoListItem> GetRandomToDo()
        {
            var cacheInt = new List<int>();
            var values = await _context.ToDos.Where(x => x.OwnerId == _ownerId).ToListAsync();

            foreach (var todo in values)
            {
                cacheInt.Add(todo.Id);
            }

            ToDoListItem todoListItem = null;
            do
            {
                var randomValue = GetRandomValue(cacheInt);
                var todo = await _context.ToDos.FindAsync(randomValue);
                if (todo != null)
                {
                    todoListItem = new ToDoListItem();
                    todoListItem.Action = todo.Action;
                    return todoListItem;
                }
            } 
            while (todoListItem == null);
            { return null; }
        }

        private int GetRandomValue(List<int> cacheInt)
        {
            var cachedMaxValue = cacheInt.Count();
            var cachedMinValue = 0;
            var rnd = new Random();
            var randomValue = rnd.Next(cachedMinValue, cachedMaxValue);

            return cacheInt[randomValue];
        }
    }
}
