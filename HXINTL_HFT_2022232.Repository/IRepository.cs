using System.Linq;

namespace HXINTL_HFT_2022232.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T obj);
        T Read(int id);
        IQueryable<T> ReadAll();
        void Update(T obj);
        void Delete(int id);
    }
}