using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_3.IRepository;
using test_3.Models;

namespace test_3.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private DbContext _context;
        public StudentRepository(IConfiguration configuration)
        {
            _context = new DbContext(configuration);
        }
        public bool Create(Student model)
        {
            
            try
            {
                String sql = $"INSERT INTO Student (Name,Birthday,RegisterDate,ALStream) " +
                   $"VALUES(" +
                   $"'{model.Name}'" +
                   $",'{model.BirthdayDate}'" +
                   $",'{model.RegisterDate}'" +
                   $",'{model.ALStream}'" +
                   $");";
                _context.execute(sql);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
                String sql = $"DELETE FROM Student WHERE Id = {id};";

                _context.execute(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Student> GetAll()
        {
            try
            {
                List<Student> students = new List< Student>();
                String sql = $"SELECT * FROM Student;";

                students = _context.ConvertDataTable<Student>(_context.execute(sql));
                return students;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public Student GetById(int id)
        {
            try
            {
                List<Student> students = new List<Student>();
                String sql = $"SELECT * FROM Student WHERE Id = {id};";

                students = _context.ConvertDataTable<Student>(_context.execute(sql));
                return students[0];
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Student> SearchByName(string search)
        {
            try
            {
                List<Student> students = new List<Student>();
                String sql = $"SELECT * FROM Student WHERE Name Like '%{search}%';";

                students = _context.ConvertDataTable<Student>(_context.execute(sql));
                return students;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(Student model)
        {
            try
            {
                String sql = $"UPDATE Student SET " +
                    $"Name = '{model.Name}'" +
                    $", Birthday = '{model.BirthdayDate}'" +
                    $", RegisterDate = '{model.RegisterDate}'" +
                    $", ALStream = '{model.ALStream}'" +
                    $" WHERE Id='{model.Id}';";
                _context.execute(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
