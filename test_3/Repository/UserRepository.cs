using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_3.Models;

namespace test_3.Repository
{
    public class UserRepository : IRepository.IUserRepository
    {
        private DbContext _context;
        public UserRepository(IConfiguration configuration)
        {
            _context = new DbContext(configuration);
        }
        public bool Create(User model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            try
            {
                List<User> users = new List<User>();
                String sql = $"SELECT * FROM Users WHERE Id = {id};";

                users = _context.ConvertDataTable<User>(_context.execute(sql));
                return users[0];
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public User IsValid(User user)
        {
            try
            {
                List<User> users = new List<User>();
                String sql = $"SELECT * FROM Users WHERE Email = '{user.Email}' AND Password = '{user.Password}';";

                users = _context.ConvertDataTable<User>(_context.execute(sql));
                return users[0];
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
