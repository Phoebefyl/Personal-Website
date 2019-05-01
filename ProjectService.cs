using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab11.Models;
using Lab11.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab11.Service
{
    public class ProjectService : IProjectServer
    {
        private readonly ProjectWebsiteDbContext _ctx;
        public ProjectService(ProjectWebsiteDbContext ctx)
        {
            _ctx = ctx;
        }

        //---------------- Project function--------------

        public void add1(Project project)
        {
            _ctx.project.Add(project);
            _ctx.SaveChanges();
        }

        public void addComment(int projectID, Comment cm)
        {
            _ctx.project.Find(projectID).comments.Append(cm);
            _ctx.comments.Add(cm);
            try
            {
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                // do nothing for now
            }
        }

        public void deleteComment(int projectID, int commentID)
        {
            _ctx.comments.Remove(_ctx.comments.Find(commentID));
            _ctx.SaveChanges();
        }

        public void update()
        {
            _ctx.SaveChanges();
        }

        public IEnumerable<Project> getAll()
        {
            return _ctx.project.Include(project => project.category)
                .Include(project => project.author)
                .Include(project => project.comments)
                    .ThenInclude(comment => comment.author);
        }

        public IEnumerable<Project> getByCategory(Category ctg)
        {
            return getAll().Where(projects => projects.category.categoryID == ctg.categoryID);
        }

        public Project getById(int id)
        {
            return getAll().FirstOrDefault(a => a.projectID == id);
        }

        public void deleteProjects(int projectID)
        {
            var projects = getAll().FirstOrDefault(a => a.projectID == projectID);

            if (projects != null)
            {
                foreach (var cm in projects.comments)
                {
                    _ctx.comments.Remove(cm);
                }
                _ctx.project.Remove(projects);
            }
            _ctx.SaveChanges();
        }

        //---------------- Interest function--------------

        public void add2(Interest interest)
        {
            _ctx.interest.Add(interest);
            _ctx.SaveChanges();
        }

        public void addCommentint(int interestID, Comment cm)
        {
            _ctx.interest.Find(interestID).comments.Append(cm);
            _ctx.comments.Add(cm);
            try
            {
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                // do nothing for now
            }
        }

        public void deleteCommentint(int interestID, int commentID)
        {
            _ctx.comments.Remove(_ctx.comments.Find(commentID));
            _ctx.SaveChanges();
        }

        public IEnumerable<Interest> getAllint()
        {
            return _ctx.interest.Include(interest => interest.category)
                .Include(interest => interest.author)
                .Include(interest => interest.comments)
                    .ThenInclude(comment => comment.author);
        }

        public IEnumerable<Interest> getByCategoryint(Category ctg)
        {
            return getAllint().Where(interests => interests.category.categoryID == ctg.categoryID);
        }

        public Interest getByIdint(int id)
        {
            return getAllint().FirstOrDefault(a => a.interestID == id);
        }

        public void deleteInterests(int interestID)
        {
            var interests = getAllint().FirstOrDefault(a => a.interestID == interestID);

            if (interests != null)
            {
                foreach (var cm in interests.comments)
                {
                    _ctx.comments.Remove(cm);
                }
                _ctx.interest.Remove(interests);
            }
            _ctx.SaveChanges();
        }

        //---------------- Career function--------------

        public void add3(Career career)
        {
            _ctx.career.Add(career);
            _ctx.SaveChanges();
        }

        public void addCommentcar(int careerID, Comment cm)
        {
            _ctx.career.Find(careerID).comments.Append(cm);
            _ctx.comments.Add(cm);
            try
            {
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                // do nothing for now
            }
        }

        public void deleteCommentcar(int careerID, int commentID)
        {
            _ctx.comments.Remove(_ctx.comments.Find(commentID));
            _ctx.SaveChanges();
        }

        public IEnumerable<Career> getAllcar()
        {
            return _ctx.career.Include(career => career.category)
                .Include(career => career.author)
                .Include(career => career.comments)
                    .ThenInclude(comment => comment.author);
        }

        public IEnumerable<Career> getByCategorycar(Category ctg)
        {
            return getAllcar().Where(careers => careers.category.categoryID == ctg.categoryID);
        }

        public Career getByIdcar(int id)
        {
            return getAllcar().FirstOrDefault(a => a.careerID == id);
        }

        public void deleteCareers(int careerID)
        {
            var careers = getAllcar().FirstOrDefault(a => a.careerID == careerID);

            if (careers != null)
            {
                foreach (var cm in careers.comments)
                {
                    _ctx.comments.Remove(cm);
                }
                _ctx.career.Remove(careers);
            }
            _ctx.SaveChanges();
        }
    }
}
