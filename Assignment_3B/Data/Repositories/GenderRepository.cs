using Assignment_3B.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Assignment_3B.Data.Repositories
{
    public class GenderRepository : IGenericRepository<Gender>
    {

        private DbContext _context;

        public GenderRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdate(Gender entity)
        {
            var dbContext = _context as AppDbContext;
            dbContext.Genders.AddOrUpdate(entity);
            dbContext.SaveChanges();
        }

        public Gender Get(int id)
        {
            var dbContext = _context as AppDbContext;
            var gender = dbContext.Genders.Where(x => x.GenderId == id).First();
            return gender;
        }

        public IEnumerable<Gender> GetAll()
        {
            var dbContext = _context as AppDbContext;
            var genders = dbContext.Genders.ToList();
            return genders;
        }

        public bool Remove(int id)
        {
            bool flag = false;
            var gender = Get(id);
            if (gender != null)
            {
                var dbContext = _context as AppDbContext;
                dbContext.Genders.Remove(gender);
                dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
    }
}