using LIBRARY_MANAGEMENT_SYSTEM__LMS_.Models;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.REPOs.Interface
{
    public interface IUnitOfWork 
    {
        IGenericRepo<Book> Books { get; }
        IGenericRepo<BorrowRecord> BorrowRecords { get; }
        IGenericRepo<Category> Categories { get; }
        IGenericRepo<Member> Members { get; }
        void Save();
    }
}
