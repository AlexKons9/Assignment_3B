using Assignment_3B.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_3B.Data.Repositories
{
    public class CandidateRepository : IGenericRepository<Candidate>
    {
        private DbContext _context;

        public CandidateRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdate(Candidate candidate)
        {
            var dbContext = _context as AppDbContext;
            dbContext.Candidates.AddOrUpdate(candidate);
            dbContext.SaveChanges();
        }

        public void AddOrUpdate(Candidate candidate, int genderId, int photoIdTypeId)
        {
            var dbContext = _context as AppDbContext;
            var gender = dbContext.Genders.Find(genderId);
            var photoIdType = dbContext.PhotoIdTypes.Find(photoIdTypeId);
            candidate.Gender = gender;
            candidate.PhotoIdType = photoIdType;
            dbContext.Candidates.Add(candidate);
            dbContext.SaveChanges();
        }

        public Candidate Get(int id)
        {
            var dbContext = _context as AppDbContext;
            var candidate = dbContext.Candidates.Where(x => x.CandidateId == id).First();
            return candidate;
        }

        public IEnumerable<Candidate> GetAll()
        {
            var dbContext = _context as AppDbContext;
            var candidates = dbContext.Candidates.ToList();
            return candidates;
        }


        public bool Remove(int id)
        {
            bool flag = false;
            var candidate = Get(id);
            if (candidate != null)
            {
                var dbContext = _context as AppDbContext;
                dbContext.Candidates.Remove(candidate);
                dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
    }
}