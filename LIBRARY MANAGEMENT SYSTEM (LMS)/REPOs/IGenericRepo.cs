namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.REPOs
{
    public interface IGenericRepo<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Delete(int id);
        void Update(T item);
    }
}
