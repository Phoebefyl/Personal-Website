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
    public class InterestAPIController : ControllerBase
    {
        private readonly IProjectServer projectService_;

        public InterestAPIController(IProjectServer projectService)
        {
            projectService_ = projectService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> GetInterest()
        {
            List<string> rst = new List<string>();
            var interests = projectService_.getAllint();
            foreach (var p in interests)
            {
                rst.Add(p.title);
            }
            return rst;
        }

        [HttpGet("{id}")]
        public IEnumerable<string> GetInterestDetail(int id)
        {
            List<string> rst = new List<string>();
            var interests = projectService_.getByIdint(id);
            rst.Add("ID: " + interests.interestID);
            rst.Add("Description: " + interests.content);
            rst.Add("Category: " + interests.category.categoryName);
            rst.Add("Created Time: " + interests.createTime);
            rst.Add("Updated Time: " + interests.createTime);
            return rst;
        }

    }
}