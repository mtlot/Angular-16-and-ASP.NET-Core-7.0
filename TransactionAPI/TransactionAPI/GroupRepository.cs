using Microsoft.EntityFrameworkCore;
using TransactionAPI.Context;
using TransactionAPI.Models;

namespace TransactionAPI.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDbContext _context;

        public GroupRepository(AppDbContext context)
        {
            _context = context;
        }
        public Group GetGroupWithEvents(int id)
        {
            return _context.Groups
                .Include(g => g.Events)
                .FirstOrDefault(g => g.Id == id);
        }

        public object Groups { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Group Add(Group group)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var group = _context.Groups.FirstOrDefault(g => g.Id == id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Group with ID {id} not found");
            }
        }


        public IEnumerable<Group> GetAll()
        {
            return _context.Groups.ToList();
        }

        public Group GetById(int id)
        {
            return _context.Groups.FirstOrDefault(g => g.Id == id);
        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await _context.Groups.FindAsync(id);
        }

        public object GetByName(string name)
        {
            throw new NotImplementedException();
        }

       

        // GroupRepository
        public Group Update(Group group)
        {
            var exists = _context.Groups.Any(x => x.Id == group.Id);
            if (!exists)
            {
                throw new InvalidOperationException();
            }

            // Update
            return group;
        }

        public object Update(object updatedGroup)
        {
            throw new NotImplementedException();
        }

        public async Task<Group> UpdateAsync(Group updatedGroup)
        {
            // Check if the group exists
            var existingGroup = await _context.Groups.FindAsync(updatedGroup.Id);

            if (existingGroup == null)
            {
                
                throw new InvalidOperationException("Group not found!");

            }

            // Update the group using EF's change tracker
            _context.Entry(existingGroup).CurrentValues.SetValues(updatedGroup);

            await _context.SaveChangesAsync();

            return existingGroup; // Return updated group
        }

        Task IGroupRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IGroupRepository.UpdateAsync(Group updatedGroup)
        {
            throw new NotImplementedException();
        }

    }
}
