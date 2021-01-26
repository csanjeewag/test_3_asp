using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_3.IRepository
{
    public interface IRepository<T>
    {
        public bool Create(T model);
        public bool Update(T model);
        public bool Delete(int id);
        public IEnumerable<T> GetAll();
        public T GetById(int id);


    }
}
