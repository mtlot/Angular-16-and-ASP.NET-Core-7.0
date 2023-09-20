namespace TransactionAPI.Models
{
    public interface IGroupRepository
    {
        object Groups { get; set; }

        IEnumerable<Group> GetAll();
        Group GetById(int id);
        Group Add(Group group);
        Group Update(Group updatedGroup);
        void Delete(int id);
        object GetByName(string name);
        Task UpdateAsync(Group updatedGroup);
        Task GetByIdAsync(int id);
        object Update(object updatedGroup);
     
        Group GetGroupWithEvents(int id);
    }
}
