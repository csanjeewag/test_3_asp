using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_3.Models;

namespace test_3.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        public IEnumerable<Student> SearchByName(String search);
    }
}
