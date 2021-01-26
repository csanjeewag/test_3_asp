using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_3.Models;

namespace test_3.IRepository
{
    public interface IUserRepository:IRepository<User>
    {
       public User IsValid(User user);
    }
}
