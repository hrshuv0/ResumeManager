using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeManager.Data;
using ResumeManager.Models;

namespace ResumeManager.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ResumeDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnv;

        public ResumeController(ResumeDbContext dbContext, IWebHostEnvironment webHostEnv)
        {
            _dbContext = dbContext;
            _webHostEnv = webHostEnv;
        }

        public IActionResult Index()
        {
            List<Applicant> applicantList = _dbContext.Applicants.ToList();

            return View(applicantList);
        }



        public IActionResult Create()
        {
            Applicant applicant = new Applicant();

            applicant.Experiences.Add(new Experience() { ExperienceId = 1 });
            //applicant.Experiences.Add(new Experience() { ExperienceId = 2 });
            //applicant.Experiences.Add(new Experience() { ExperienceId = 3 });

            ViewBag.Gender = GetGender();

            return View(applicant);
        }

        [HttpPost]
        public IActionResult Create(Applicant applicant)
        {
            string uniqueFileName = GetUploadFileName(applicant);
            applicant.PhotoUrl = uniqueFileName;

            _dbContext.Applicants.Add(applicant);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        private string GetUploadFileName(Applicant applicant)
        {
            string uniqueFileName = null;

            if(applicant.ProfilePhoto != null)
            {
                string uploadFolder = Path.Combine(_webHostEnv.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString();
                string filaPath = Path.Combine(uploadFolder, uniqueFileName);
                using(var fileStream = new FileStream(filaPath, FileMode.Create))
                {
                    applicant.ProfilePhoto.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }

        public IActionResult Details()
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(int id)
        {
            Applicant applicant = _dbContext.Applicants
                .Include(e => e.Experiences).FirstOrDefault(a => a.Id == id)!;

            return View(applicant);
        }

        [HttpPost]
        public IActionResult Delete(Applicant applicant)
        {
            _dbContext.Attach(applicant);
            _dbContext.Entry(applicant).State = EntityState.Deleted;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetGender()
        {
            var selectGender = new List<SelectListItem>();
            var gender = new SelectListItem() { Value=null, Text="Select Gender"};
            selectGender.Add(gender);

            gender = new SelectListItem() { Value = "Male", Text = "Male" };
            selectGender.Add(gender);
            gender = new SelectListItem() { Value = "FeMale", Text = "FeMale" };
            selectGender.Add(gender);

            return selectGender;
        }
    }
}
