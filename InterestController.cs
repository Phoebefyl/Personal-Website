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
    public class InterestController : Controller
    {
        private readonly IProjectServer projectService_;
        //private readonly string pathStorage_;

        public InterestController(IProjectServer projectService)
        {
            projectService_ = projectService;
            //pathStorage_ = "images\\";
        }

        public IActionResult Index()
        {
            var interests = projectService_.getAllint();
            ProjectIndexViewModel projectIndexViewModel = new ProjectIndexViewModel
            {
                InterestCollection = interests,
                title = "Interest Index"
            };
            return View(projectIndexViewModel);
        }

        public IActionResult Details(int id)
        {
            var interest = projectService_.getByIdint(id);
            return View(interest);
        }

        //----< gets form for creating a course >--------------------

        [HttpGet]
        public IActionResult Create(int id)
        {
            var interests = projectService_.getAllint();
            var model = new Interest();
            //model.stroyID = storys.Count() + 1;
            return View(model);
        }
        //----< posts back new courses details >---------------------

        [HttpPost]
        public IActionResult Create(int id, Interest interest)
        {
            var interests = projectService_.getAllint();
            interest.createTime = DateTime.Now;

            //Temporary avatarURL & password
            interest.author.avatarURL = "https://lucidchart.zendesk.com/system/photos/8933/3314/profile_image_678269360_201415.png";
            interest.author.password = "admin12345";
            interest.author.email = "123@sina.com";

            projectService_.add2(interest);
            return RedirectToAction("index");
        }

        ////----< gets form for creating a course >--------------------

        //[HttpGet]
        //public IActionResult Create(int id)
        //{
        //    UploadViewModel createViewModel = new UploadViewModel()
        //    {
        //        interest = new Interest(),
        //        uploadImage = null
        //    };

        //    return View(createViewModel);
        //}
        ////----< posts back new courses details >---------------------

        //[HttpPost]
        //public async Task<IActionResult> Create(int id, UploadViewModel uploadViewModel)
        //{
        //    IFormFile img = uploadViewModel.uploadImage;
        //    string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_") + img.FileName;
        //    string path = (new FileInfo(AppDomain.CurrentDomain.BaseDirectory)).Directory.Parent.Parent.Parent.FullName;
        //    string filePath = path + "\\wwwroot\\" + pathStorage_ + newFileName;
        //    await Upload(img, filePath);
        //    uploadViewModel.interest.createTime = DateTime.Now;

        //    //Temporary avatarURL & password
        //    uploadViewModel.interest.author.avatarURL = "https://lucidchart.zendesk.com/system/photos/8933/3314/profile_image_678269360_201415.png";
        //    uploadViewModel.interest.author.password = "admin12345";
        //    uploadViewModel.interest.author.email = "123@sina.com";
        //    uploadViewModel.interest.url = pathStorage_ + newFileName;

        //    projectService_.add2(uploadViewModel.interest);
        //    return RedirectToAction("index");
        //}

        ////[HttpPost]
        //public async Task<IActionResult> Upload(IFormFile formFile, string filePath)
        //{
        //    if (formFile.Length > 0)
        //    {
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await formFile.CopyToAsync(stream);
        //        }
        //    }
        //    return Ok();
        //}


        [HttpPost]
        public IActionResult AddComment(int id, Comment cm)
        {
            var interests = projectService_.getAllint();
            var it = interests.FirstOrDefault(a => a.interestID == id);
            cm.interest = it;
            cm.author = it.author;  //demo data  --> will be replaced by current user
            cm.postTime = DateTime.Now;

            projectService_.addComment(id, cm);

            //var newComment = new Comment() {


            //};
            return RedirectToAction("details", new { id = id });
        }

        public IActionResult DeleteComment(int interestID, int commentID)
        {

            projectService_.deleteComment(interestID, commentID);

            return RedirectToAction("details", new { id = interestID });
        }

        [HttpGet]
        public IActionResult EditInterest(int interestID)
        {
            var interests = projectService_.getByIdint(interestID);
            return View(interests);
        }

        [HttpPost]
        public IActionResult EditInterest(Interest interest)
        {
            var newInterest = projectService_.getByIdint(interest.interestID);
            newInterest.title = interest.title;
            newInterest.url = interest.url;
            newInterest.content = interest.content;
            newInterest.category = interest.category;
            newInterest.updateTime = DateTime.Now;
            projectService_.update();

            return RedirectToAction("details", new { id = newInterest.interestID });
        }

        public IActionResult DeleteInterest(int interestID)
        {
            projectService_.deleteInterests(interestID);
            return RedirectToAction("Index");
        }
    }
}