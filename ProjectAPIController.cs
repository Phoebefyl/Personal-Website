using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab11.Service;

namespace Lab11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAPIController : ControllerBase
    {
        private readonly IProjectServer projectService_;

        public ProjectAPIController(IProjectServer projectService)
        {
            projectService_ = projectService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> GetProject()
        {
            List<string> rst = new List<string>();
            var projects = projectService_.getAll();
            foreach (var p in projects)
            {
                rst.Add(p.title);
            }
            return rst;
        }

        [HttpGet("{id}")]
        public IEnumerable<string> GetProjectDetail(int id)
        {
            List<string> rst = new List<string>();
            var projects = projectService_.getById(id);
            rst.Add("ID: " + projects.projectID);
            rst.Add("Description: " + projects.content);
            rst.Add("Category: " + projects.category.categoryName);
            rst.Add("Created Time: " + projects.createTime);
            rst.Add("Updated Time: " + projects.createTime);
            return rst;
        }

    }
}