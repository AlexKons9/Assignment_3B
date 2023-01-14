using Assignment_3B.Data.Repositories;
using Assignment_3B.Data;
using Assignment_3B.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_3B.Controllers
{
    public class ExamsResultsController : Controller
    {
        private AppDbContext _context;
        private ExamsResultsRepository _repository;
        private LazyLoadingService _loadService;


        public ExamsResultsController()
        {
            _context = new AppDbContext();
            _repository = new ExamsResultsRepository(_context);
            _loadService = new LazyLoadingService(_context);
        }

        // GET: ExamsResults
        public ActionResult Index()
        { 
            var exams = _repository.GetAll();
            _loadService.LoadExams(exams);
            return View(exams);
        }

        public ActionResult Details(int id)
        {
            var exam = _repository.Get(id);
            if (exam != null)
            {
                var resultExam = _loadService.LoadExam(exam);
                return View(resultExam);
            }
            return View();
        }

    }
}