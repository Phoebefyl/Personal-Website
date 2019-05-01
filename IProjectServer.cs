using Lab11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11.Service
{
    public interface IProjectServer
    {
        //---------------Project Server function----------------

        IEnumerable<Project> getAll();

        IEnumerable<Project> getByCategory(Category ctg);

        Project getById(int id);

        void add1(Project project);

        void addComment(int projectID, Comment cm);

        void update();

        void deleteProjects(int projectID);

        void deleteComment(int projectID, int commentID);

        //---------------Interest Server function----------------

        IEnumerable<Interest> getAllint();

        IEnumerable<Interest> getByCategoryint(Category ctg);

        Interest getByIdint(int id);

        void add2(Interest interest);

        void addCommentint(int interestID, Comment cm);

        void deleteInterests(int interestID);

        void deleteCommentint(int interestID, int commentID);

        //---------------Career Server function----------------

        IEnumerable<Career> getAllcar();

        IEnumerable<Career> getByCategorycar(Category ctg);

        Career getByIdcar(int id);

        void add3(Career career);

        void addCommentcar(int careerID, Comment cm);

        void deleteCareers(int careerID);

        void deleteCommentcar(int careerID, int commentID);

    }
}
