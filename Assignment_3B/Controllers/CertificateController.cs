using Assignment_3B.Data.Repositories;
using Assignment_3B.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_3B.Models;
using Assignment_3B.Services;

namespace Assignment_3B.Controllers
{
    public class CertificateController : Controller
    {
        private AppDbContext _context;
        private CertificateRepository _repository;
        private LazyLoadingService _loadService;

        public CertificateController()
        {
            _context = new AppDbContext();
            _repository = new CertificateRepository(_context);
            _loadService = new LazyLoadingService(_context); // loads information, needed due to lazy loading
        }

        public ActionResult Index() // Liststring message
        {
            var certificates =_repository.GetAll();
            _loadService.LoadCertificates(certificates);
            return View(certificates);
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

        public ActionResult Remove(int id)
        {
            var certificate = _repository.Get(id);
            if (certificate != null)
            {
                var resultCertificate = _loadService.LoadCertificate(certificate);
                return View(resultCertificate);
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (_repository.Remove(id))
            {
                return RedirectToAction("Index", new { message = $"Certificate with id = {id} is deleted succesfully!" });
            }
            return RedirectToAction("Index", new { message = $"Certificate with id {id} was not found!" });
        }

    }
}