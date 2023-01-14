using Assignment_3B.Data;
using Assignment_3B.Data.Repositories;
using Assignment_3B.Models;
using Assignment_3B.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Assignment_3B.Controllers
{
    public class CandidateController : Controller
    {
        private AppDbContext _context;
        private CandidateRepository _repository;
        private GenderRepository _genderRepository;
        private PhotoIdTypeRepository _photoIdTypeRepository;
        private LazyLoadingService _loadService;

        public CandidateController()
        {
            _context= new AppDbContext();
            _repository = new CandidateRepository(_context);
            _genderRepository = new GenderRepository(_context);
            _photoIdTypeRepository = new PhotoIdTypeRepository(_context);
            _loadService = new LazyLoadingService(_context);
        }

        // GET: Candidate
        public ActionResult Index() // List
        {
            var candidates = _repository.GetAll();
            _loadService.LoadCandidates(candidates);
            return View(candidates);
        }

        public ActionResult Create()
        {
            var genders = _genderRepository.GetAll();
            if (genders == null || genders.Count() <= 0) return View();
            var selectListOfGenders = new List<SelectListItem>();
            var groupGenders = new SelectListGroup();
            foreach (var gender in genders)
            {
                var selectListItem = new SelectListItem()
                {
                    Disabled = false,
                    Group = groupGenders,
                    Selected = false,
                    Text = $@"{gender.GenderId} {gender.GenderType}",
                    Value = gender.GenderId.ToString()
                };
                selectListOfGenders.Add(selectListItem);
            }
            selectListOfGenders.ElementAt(0).Selected = true;
            ViewData.Add("Gender", selectListOfGenders);

            var idTypes = _photoIdTypeRepository.GetAll();
            if (idTypes == null || idTypes.Count() <= 0) return View();
            var selectListOfPhotoIdTypes = new List<SelectListItem>();
            var groupIdTypes = new SelectListGroup();
            foreach (var idType in idTypes)
            {
                var selectListItem = new SelectListItem()
                {
                    Disabled = false,
                    Group = groupIdTypes,
                    Selected = false,
                    Text = $@"{idType.Id} {idType.Type}",
                    Value = idType.Id.ToString()
                };
                selectListOfPhotoIdTypes.Add(selectListItem);
            }
            selectListOfPhotoIdTypes.ElementAt(0).Selected = true;
            ViewData.Add("PhotoIdType", selectListOfPhotoIdTypes);
            return View();
        }

       [HttpPost]
        public ActionResult Save([Bind(Include = "CandidateId,FirstName,MiddleName,LastName," +
           "NativeLanguage,BirthDate,PhotoIdNumber,PhotoIssueDate,Email,AddressLine,AddressLine2, " +
           "CountryOfResidence, Province, City, PostalCode, LandlineNumber, MobileNumber")]Candidate candidate,
           [Bind(Include = "Gender")] int Gender, [Bind(Include = "PhotoIdType")] int PhotoIdType)
        {
            //string textResult = "";
            if(ModelState.IsValid)
            {
                //if (candidate.CandidateId == 0)
                //{
                //    //textResult = "created";
                //    //_repository.Add(candidate, Gender, PhotoIdType);
                //}
                //else
                //{
                //    //textResult = "updated";
                //    //_repository.AddOrUpdate(candidate);
                //}
                _repository.AddOrUpdate(candidate, Gender, PhotoIdType); 

            }
            return RedirectToAction("Index");   //, new { message = $"A new Candidate is been {textResult} successfully!" }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var candidate = _loadService.LoadCandidate(_repository.Get(id));

            var genders = _genderRepository.GetAll();
            var selectListOfGenders = new List<SelectListItem>();
            var groupGenders = new SelectListGroup();
            foreach (var gender in genders)
            {
                var selectListItem = new SelectListItem()
                {
                    Disabled = false,
                    Group = groupGenders,
                    Selected = false,
                    Text = $@"{gender.GenderId} {gender.GenderType}",
                    Value = gender.GenderId.ToString() 
                };
                selectListOfGenders.Add(selectListItem);
            }
            selectListOfGenders.ElementAt(candidate.Gender.GenderId - 1).Selected = true;
            ViewData.Add("Gender", selectListOfGenders);

            var idTypes = _photoIdTypeRepository.GetAll();
            var selectListOfPhotoIdTypes = new List<SelectListItem>();
            var groupIdTypes = new SelectListGroup();
            foreach (var idType in idTypes)
            {
                var selectListItem = new SelectListItem()
                {
                    Disabled = false,
                    Group = groupIdTypes,
                    Selected = false,
                    Text = $@"{idType.Id} {idType.Type}",
                    Value = idType.Id.ToString()
                };
                selectListOfPhotoIdTypes.Add(selectListItem);
            }
            selectListOfPhotoIdTypes.ElementAt(candidate.PhotoIdType.Id - 1).Selected = true;
            ViewData.Add("PhotoIdType", selectListOfPhotoIdTypes);

            return View(candidate);
        }

        [HttpPost]
        public ActionResult Edit(Candidate candidate)
        {
            var genderType = _context.Genders.Find(candidate.Gender.GenderId);
            var idType = _context.PhotoIdTypes.Find(candidate.PhotoIdType.Id);
            candidate.Gender = genderType;
            candidate.PhotoIdType = idType;
            _repository.AddOrUpdate(candidate);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var candidate = _repository.Get(id);
            if(candidate != null)
            {
                var resultCandidate = _loadService.LoadCandidate(candidate);
                return View(resultCandidate);
            }
            return View();
        }

        public ActionResult Remove(int id)
        {
            var candidate = _repository.Get(id);
            if (candidate != null)
            {
                var resultCandidate = _loadService.LoadCandidate(candidate);
                return View(resultCandidate);
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (_repository.Remove(id))
            {
                string message = $"Candidate with id = {id} is deleted succesfully!";
                return RedirectToAction("Index", new { message = message });
            }
            return RedirectToAction("Index",
                new { message = $"Candidate with id {id} was not found!" });
        }
    }
}