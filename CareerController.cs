using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Lab11.Data;
using Lab11.Models;
using Lab11.Service;
using Lab11.ViewAllModels;

namespace Lab11.Controllers
{
    public class CareerController : Controller
    {
        private readonly IProjectServer projectService_;

        public CareerController(IProjectServer projectService)
        {
            projectService_ = projectService;
        }

        public IActionResult Index()
        {
            var careers = projectService_.getAllcar();
            ProjectIndexViewModel projectIndexViewModel = new ProjectIndexViewModel
            {
                CareerCollection = careers,
                title = "Career Index"
            };
            return View(projectIndexViewModel);
        }

        public IActionResult Details(int id)
        {
            var career = projectService_.getByIdcar(id);
            return View(career);
        }


        //----< gets form for creating a course >--------------------

        [HttpGet]
        public IActionResult Create(int id)
        {
            var careers = projectService_.getAllcar();
            var model = new Career();
            //model.stroyID = storys.Count() + 1;
            return View(model);
        }
        //----< posts back new courses details >---------------------

        [HttpPost]
        public IActionResult Create(int id, Career career)
        {
            var careers = projectService_.getAllcar();
            career.createTime = DateTime.Now;

            //Temporary avatarURL & password
            career.author.avatarURL = "https://lucidchart.zendesk.com/system/photos/8933/3314/profile_image_678269360_201415.png";
            career.author.password = "admin12345";
            career.author.email = "123@sina.com";

            projectService_.add3(career);
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            var formFile = files[0];
            var filePath = Directory.GetCurrentDirectory() + "/Repository/Images/"
                           + formFile.FileName;

            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            return Ok();
        }

        public IActionResult Diagram(int id)
        {
            var career = projectService_.getByIdcar(id);
            return View(career);
        }


        [HttpPost]
        public IActionResult AddComment(int id, Comment cm)
        {
            var careers = projectService_.getAllcar();
            var cr = careers.FirstOrDefault(a => a.careerID == id);
            cm.career = cr;
            cm.author = cr.author;  //demo data  --> will be replaced by current user
            cm.postTime = DateTime.Now;

            projectService_.addComment(id, cm);

            //var newComment = new Comment() {


            //};
            return RedirectToAction("details", new { id = id });
        }

        public IActionResult DeleteComment(int careerID, int commentID)
        {

            projectService_.deleteComment(careerID, commentID);

            return RedirectToAction("details", new { id = careerID });
        }

        [HttpGet]
        public IActionResult EditCareer(int careerID)
        {
            var careers = projectService_.getByIdcar(careerID);
            return View(careers);
        }

        [HttpPost]
        public IActionResult EditCareer(Career career)
        {
            var newCareer = projectService_.getByIdcar(career.careerID);
            newCareer.title = career.title;
            newCareer.url = career.url;
            newCareer.content = career.content;
            newCareer.category = career.category;
            newCareer.updateTime = DateTime.Now;
            projectService_.update();

            return RedirectToAction("details", new { id = newCareer.careerID });
        }

        public IActionResult DeleteCareer(int careerID)
        {
            projectService_.deleteCareers(careerID);
            return RedirectToAction("Index");
        }
    }
}