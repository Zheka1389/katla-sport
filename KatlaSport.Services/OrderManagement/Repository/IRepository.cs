using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.OrderManagement.Repository
{
    public interface IRepository<T, V>
    {
        Task<T> Add(V t);

        Task Remove(int id);

        Task<T> Update(V t);

        Task<T> GetOne(int id);

        Task<List<T>> GetAll();
    }
}
