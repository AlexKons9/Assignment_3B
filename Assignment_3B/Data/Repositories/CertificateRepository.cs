using Assignment_3B.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Assignment_3B.Data.Repositories
{
    public class CertificateRepository : IGenericRepository<Certificate>
    {
        private DbContext _context;

        public CertificateRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdate(Certificate certificate)
        {
            var dbContext = _context as AppDbContext;
            dbContext.Certificates.AddOrUpdate(certificate);
            dbContext.SaveChanges();
        }

        public Certificate Get(int id)
        {
            var dbContext = _context as AppDbContext;
            var certificate = dbContext.Certificates.Where(x => x.CertificateId == id).First();
            return certificate;
        }

        public IEnumerable<Certificate> GetAll()
        {
            var dbContext = _context as AppDbContext;
            var certificates = dbContext.Certificates.ToList();
            return certificates;
        }

        public bool Remove(int id)
        {
            bool flag = false;
            var certificate = Get(id);
            if (certificate != null)
            {
                var dbContext = _context as AppDbContext;
                dbContext.Certificates.Remove(certificate);
                dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }

    }
}