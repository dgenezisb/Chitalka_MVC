namespace ChitalkaMVC.Logic.Notes
{
    public class NoteManager : INoteManager
    {
        private readonly ChitalkaContext _context;

        public NoteManager(ChitalkaContext context)
        {
            _context = context;
        }
        public async Task Create(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = _context.Notes.FirstOrDefault(item => item.Id == id);
            if (item != null)
            {
                _context.Notes.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Note>> GetByUsername(string username)
        {
            var notes = await _context.Notes.Where(n => n.Username == username).ToListAsync();
            return notes;
        }

        public async Task<Note> Find(int id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public async Task<bool> Update(Note note)
        {
            try
            {
                _context.Update(note);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = Find(note.Id);
                if (item == null)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }
    }
}
