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
    public class ProjectController : Controller
    {
        private readonly IProjectServer projectService_;

        public ProjectController(IProjectServer projectService)
        {
            projectService_ = projectService;
        }

        public IActionResult Index()
        {
            var projects = projectService_.getAll();
            ProjectIndexViewModel projectIndexViewModel = new ProjectIndexViewModel
            {
                ProjectCollection = projects,
                title = "Project Index"
            };
            return View(projectIndexViewModel);
        }

        public IActionResult Details(int id)
        {
            var project = projectService_.getById(id);
            return View(project);
        }

        public IActionResult Code(int id)
        {
            var project = projectService_.getById(id);
            return View(project);
        }

        //----< gets form for creating a course >--------------------

        [HttpGet]
        public IActionResult Create(int id)
        {
            var projects = projectService_.getAll();
            var model = new Project();
            //model.stroyID = storys.Count() + 1;
            return View(model);
        }
        //----< posts back new courses details >---------------------

        [HttpPost]
        public IActionResult Create(int id, Project project)
        {
            var projects = projectService_.getAll();
            project.createTime = DateTime.Now;

            //Temporary avatarURL & password
            project.author.avatarURL = "https://lucidchart.zendesk.com/system/photos/8933/3314/profile_image_678269360_201415.png";
            project.author.password = "admin12345";
            project.author.email = "123@sina.com";

            projectService_.add1(project);
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




        [HttpPost]
        public IActionResult AddComment(int id, Comment cm)
        {
            var projects = projectService_.getAll();
            var pj = projects.FirstOrDefault(a => a.projectID == id);
            cm.project = pj;
            cm.author = pj.author;  //demo data  --> will be replaced by current user
            cm.postTime = DateTime.Now;

            projectService_.addComment(id, cm);

            //var newComment = new Comment() {


            //};
            return RedirectToAction("details", new { id = id });
        }

        public IActionResult DeleteComment(int projectID, int commentID)
        {

            projectService_.deleteComment(projectID, commentID);

            return RedirectToAction("details", new { id = projectID });
        }

        [HttpGet]
        public IActionResult EditProject(int projectID)
        {
            var projects = projectService_.getById(projectID);
            return View(projects);
        }

        [HttpPost]
        public IActionResult EditProject(Project project)
        {
            var newProject = projectService_.getById(project.projectID);
            newProject.title = project.title;
            newProject.url = project.url;
            newProject.content = project.content;
            newProject.category = project.category;
            newProject.updateTime = DateTime.Now;
            projectService_.update();

            return RedirectToAction("details", new { id = newProject.projectID });
        }

        public IActionResult DeleteProject(int projectID)
        {
            projectService_.deleteProjects(projectID);
            return RedirectToAction("Index");
        }

        
    }
}