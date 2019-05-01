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
    public class CareerAPIController : ControllerBase
    {
        private readonly IProjectServer projectService_;

        public CareerAPIController(IProjectServer projectService)
        {
            projectService_ = projectService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> GetCareer()
        {
            List<string> rst = new List<string>();
            var careers = projectService_.getAllcar();
            foreach (var p in careers)
            {
                rst.Add(p.title);
            }
            return rst;
        }

        [HttpGet("{id}")]
        public IEnumerable<string> GetCareerDetail(int id)
        {
            List<string> rst = new List<string>();
            var careers = projectService_.getByIdcar(id);
            rst.Add("ID: " + careers.careerID);
            rst.Add("Description: " + careers.content);
            rst.Add("Category: " + careers.category.categoryName);
            rst.Add("Created Time: " + careers.createTime);
            rst.Add("Updated Time: " + careers.createTime);
            return rst;
        }

    }
}