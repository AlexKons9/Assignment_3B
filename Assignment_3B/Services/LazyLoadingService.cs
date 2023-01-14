using Assignment_3B.Data;
using Assignment_3B.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment_3B.Services
{
    public class LazyLoadingService
    {
        private AppDbContext _context;

        public LazyLoadingService(AppDbContext context)
        {
            _context = context;
        }

        public Certificate LoadCertificate(Certificate certificate)
        {
            _context.Entry(certificate).Reference(x => x.CertificateType).Load();
            _context.Entry(certificate).Reference(x => x.CandidateId).Load();
            _context.Entry(certificate).Reference(x => x.Exam).Load();
            return certificate;
        }

        public Candidate LoadCandidate(Candidate candidate)
        {
            _context.Entry(candidate).Reference(x => x.Gender).Load();
            _context.Entry(candidate).Reference(x => x.PhotoIdType).Load();
            return candidate;
        }

        public Exam LoadExam(Exam exam)
        {
            _context.Entry(exam).Reference(x => x.MarkPerTopic).Load();
            _context.Entry(exam).Reference(x => x.CertificateType).Load();
            _context.Entry(exam).Reference(x => x.CandidateId).Load();

            return exam;
        }

        public IEnumerable<Certificate> LoadCertificates(IEnumerable<Certificate> certificates)
        {
            foreach (var certificate in certificates)
            {
                _context.Entry(certificate).Reference(x => x.CertificateType).Load();
                _context.Entry(certificate).Reference(x => x.CandidateId).Load();
                _context.Entry(certificate).Reference(x => x.Exam).Load();
            }
            return certificates;
        }

        public IEnumerable<Candidate> LoadCandidates(IEnumerable<Candidate> candidates)
        {
            foreach (var candidate in candidates)
            {
                _context.Entry(candidate).Reference(x => x.Gender).Load();
                _context.Entry(candidate).Reference(x => x.PhotoIdType).Load();
            }
            return candidates;
        }

        public IEnumerable<Exam> LoadExams(IEnumerable<Exam> exams)
        {
            foreach (var exam in exams)
            {
                _context.Entry(exam).Reference(x => x.MarkPerTopic).Load();
                _context.Entry(exam).Reference(x => x.CertificateType).Load();
                _context.Entry(exam).Reference(x => x.CandidateId).Load();
            }

            return exams;
        }
    }
}