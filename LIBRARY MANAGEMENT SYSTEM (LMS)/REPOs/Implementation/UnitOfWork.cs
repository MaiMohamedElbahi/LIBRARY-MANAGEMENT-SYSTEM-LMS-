using LIBRARY_MANAGEMENT_SYSTEM__LMS_.Data;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.Models;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.REPOs.Interface;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.REPOs.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGenericRepo<Book> Books { get; }

        public IGenericRepo<BorrowRecord> BorrowRecords { get; }

        public IGenericRepo<Category> Categories { get; }

        public IGenericRepo<Member> Members { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            BorrowRecords = new GenericRepo<BorrowRecord>(context);
            Books = new GenericRepo<Book>(context);
            Categories = new GenericRepo<Category>(context);
            Members = new GenericRepo<Member>(context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
