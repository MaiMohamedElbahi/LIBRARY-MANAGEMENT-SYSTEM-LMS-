
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.Data;
using Microsoft.EntityFrameworkCore;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.REPOs
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _db;
        public GenericRepo(AppDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();

        }
        public void Add(T item)
        {
            _db.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _db.Find(id);
            if (entity != null)
            {
                _db.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            return _db.ToList();
        }

        public T GetById(int id)
        {
            var entity = _db.Find(id);
            if (entity != null)
            {
                return entity;
            }
            return null;
        }

        
        public void Update(T item)
        {
            _db.Update(item);
            _context.SaveChanges();
        }

    }
}
