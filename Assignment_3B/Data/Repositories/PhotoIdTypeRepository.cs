using Assignment_3B.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Assignment_3B.Data.Repositories
{
    public class PhotoIdTypeRepository : IGenericRepository<PhotoIdType>
    {

        private DbContext _context;

        public PhotoIdTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdate(PhotoIdType entity)
        {
            var dbContext = _context as AppDbContext;
            dbContext.PhotoIdTypes.AddOrUpdate(entity);
            dbContext.SaveChanges();
        }

        public PhotoIdType Get(int id)
        {
            var dbContext = _context as AppDbContext;
            var photoIdType = dbContext.PhotoIdTypes.Where(x => x.Id == id).First();
            return photoIdType;
        }

        public IEnumerable<PhotoIdType> GetAll()
        {
            var dbContext = _context as AppDbContext;
            var photoIdTypes = dbContext.PhotoIdTypes.ToList();
            return photoIdTypes;
        }

        public bool Remove(int id)
        {
            bool flag = false;
            var photoIdType = Get(id);
            if (photoIdType != null)
            {
                var dbContext = _context as AppDbContext;
                dbContext.PhotoIdTypes.Remove(photoIdType);
                dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
    }
}