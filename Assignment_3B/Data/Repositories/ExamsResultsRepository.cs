using Assignment_3B.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment_3B.Data.Repositories
{
    public class ExamsResultsRepository : IGenericRepository<Exam>
    {
        private DbContext _context;

        public ExamsResultsRepository(AppDbContext context)
        {
            _context = context;
        }


        public void AddOrUpdate(Exam entity)
        {
            throw new NotImplementedException();
        }

        public Exam Get(int id)
        {
            var dbContext = _context as AppDbContext;
            var exam = dbContext.Exams.Where(x => x.ExamsId == id).First();
            return exam;
        }

        public IEnumerable<Exam> GetAll()
        {
            var dbContext = _context as AppDbContext;
            var exams = dbContext.Exams.ToList();
            return exams;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}