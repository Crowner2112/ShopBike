using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public interface IRepository<T>
    {
        IEnumerable<T> ListAllPaging(string searchString, int page, int pageSize);
        T GetById(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
