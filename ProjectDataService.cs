using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab11.Models;


namespace Lab11.Service
{
    public class ProjectDataService : IProjectServer
    {

        //---------------Project Data Server function----------------

        public IEnumerable<Project> getAll()
        {
            ProjectList projectList = ProjectList.getInstance();
            return projectList;
        }

        public IEnumerable<Project> getByCategory(Category ctg)
        {
            throw new NotImplementedException();
        }

        public Project getById(int id)
        {
            ProjectList projectList = ProjectList.getInstance();
            return projectList[id];
        }

        public void add1(Project project)
        {
            ProjectList projectList = ProjectList.getInstance();
            projectList.add(project);
        }

        public void addComment(int projectID, Comment cm)
        {
            throw new NotImplementedException();
        }

        public void update()
        {
            throw new NotImplementedException();
        }

        public void deleteProjects(int projectID)
        {
            throw new NotImplementedException();
        }

        public void deleteComment(int projectID, int commentID)
        {
            throw new NotImplementedException();
        }

        //---------------Interest Data Server function----------------

        public IEnumerable<Interest> getAllint()
        {
            InterestList interestList = InterestList.getInstance();
            return interestList;
        }

        public IEnumerable<Interest> getByCategoryint(Category ctg)
        {
            throw new NotImplementedException();
        }

        public Interest getByIdint(int id)
        {
            InterestList interestList = InterestList.getInstance();
            return interestList[id];
        }

        public void add2(Interest interest)
        {
            InterestList interestList = InterestList.getInstance();
            interestList.add(interest);
        }

        public void addCommentint(int interestID, Comment cm)
        {
            throw new NotImplementedException();
        }

        public void deleteInterests(int interestID)
        {
            throw new NotImplementedException();
        }

        public void deleteCommentint(int interestID, int commentID)
        {
            throw new NotImplementedException();
        }

        //---------------Career Data Server function----------------

        public IEnumerable<Career> getAllcar()
        {
            CareerList careerList = CareerList.getInstance();
            return careerList;
        }

        public IEnumerable<Career> getByCategorycar(Category ctg)
        {
            throw new NotImplementedException();
        }

        public Career getByIdcar(int id)
        {
            CareerList careerList = CareerList.getInstance();
            return careerList[id];
        }

        public void add3(Career career)
        {
            CareerList careerList = CareerList.getInstance();
            careerList.add(career);
        }

        public void addCommentcar(int careerID, Comment cm)
        {
            throw new NotImplementedException();
        }

        public void deleteCareers(int careerID)
        {
            throw new NotImplementedException();
        }

        public void deleteCommentcar(int careerID, int commentID)
        {
            throw new NotImplementedException();
        }
    }
}
