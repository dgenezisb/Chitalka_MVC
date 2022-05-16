namespace ChitalkaMVC.Logic.Notes
{
    public interface INoteManager
    {
        Task Create(Note note);
        Task<IList<Note>> GetByUsername(string username);
        Task<Note> Find(int id);
        Task<bool> Update(Note note);
        Task Delete(int id);
    }
}
