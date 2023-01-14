using Assignment_3B.Data.Repositories;
using Assignment_3B.Data;
using Assignment_3B.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_3B.Models;
using System.Web.Services.Description;
using PdfCertificateMaker.Services;
using Microsoft.Ajax.Utilities;

namespace Assignment_3B.Controllers
{
    public class CandidateUIController : Controller
    {
        private AppDbContext _context;
        private CertificateRepository _repository;
        private LazyLoadingService _loadService;
        private PdfCertificateService _pdfService;


        public CandidateUIController()
        {
            _context = new AppDbContext();
            _repository = new CertificateRepository(_context);
            _loadService = new LazyLoadingService(_context);
            _pdfService = new PdfCertificateService();
        }

        // GET: CandidateUI
        public ActionResult Index(string CandidateId, string message)
        {
            ViewBag.Message = message;
            if (String.IsNullOrEmpty (CandidateId)) // if press submit without value 
            {
                CandidateId = "0";
            }
            var certificates = _repository.GetAll();
            _loadService.LoadCertificates(certificates);
            var candidatesCertificates = new List<Certificate>();
            foreach (var c in certificates)
            {
                if (c.CandidateId.CandidateId == Convert.ToInt32(CandidateId))
                {
                    candidatesCertificates.Add(c);
                }
            }
            return View(candidatesCertificates);
        }

        public ActionResult Details(int id)
        {
            var certificate = _repository.Get(id);
            if (certificate != null)
            {
                var resultCertificate = _loadService.LoadCertificate(certificate);
                return View(resultCertificate);
            }
            return View();
        }

        public ActionResult PdfMaker(int id)
        {
            var certificate = _repository.Get(id);
            if (certificate != null)
            {
                var resultCertificate = _loadService.LoadCertificate(certificate);
                _pdfService.CreatePdfCertificate(certificate.CandidateId.FirstName, certificate.CandidateId.LastName, resultCertificate.CertificateType.Type);
            }
            else
            {
                return RedirectToAction("Index", new { CandidateId = id, message = "This Certificate does not exist!" });

            }
            return RedirectToAction("Index", new { CandidateId = id, message = "Certificate has been downloaded!" });
        }
    }
}