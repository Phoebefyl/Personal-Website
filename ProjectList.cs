using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab11.Models
{
        public class ProjectList : IEnumerable<Project>
        {
            public List<Project> projects { get; set; } = new List<Project>();

            private static ProjectList instance { get; set; } = null;  // holds persistant instance

        private ProjectList()
        {

            //----< Users >-----------------
            User user0 = new User()
            {
                userID = 0,
                userName = "Yueliu Fan",
                password = "qwertyuiop",
                email = "yfan33@syr.edu",
                avatarURL = "https://image.flaticon.com/icons/svg/145/145852.svg"
            };

            User user1 = new User()
            {
                userID = 1,
                userName = "Peng Zhang",
                password = "asdfghjkl",
                email = "phoebefyl123@gmail.com",
                avatarURL = "https://image.flaticon.com/icons/svg/145/145862.svg"
            };

            User user2 = new User()
            {
                userID = 2,
                userName = "Rong Fan",
                password = "zxcvbnm",
                email = "fansunrise@gmail.com",
                avatarURL = "https://image.flaticon.com/icons/svg/145/145843.svg"
            };

            User user3 = new User()
            {
                userID = 3,
                userName = "Jiuhua Zhang",
                password = "0987654321",
                email = "fansunrise888@gmail.com",
                avatarURL = "https://image.flaticon.com/icons/svg/1645/1645003.svg"
            };

            //----< Comments >-----------------
            Comment comment0 = new Comment()
            {
                commentID = 0,
                content = "Perfect job! Look nice.",
                postTime = new DateTime(2019, 1, 6),
                status = true,
                author = user0,
            };

            Comment comment1 = new Comment()
            {
                commentID = 1,
                content = "Thank you so much. I really like your project.",
                postTime = new DateTime(2019, 3, 6),
                status = true,
                author = user1,
            };

            Comment comment2 = new Comment()
            {
                commentID = 2,
                content = "Great Job!",
                postTime = new DateTime(2019, 2, 6),
                status = true,
                author = user2,
            };

            Comment comment3 = new Comment()
            {
                commentID = 3,
                content = "I will think about give you an offer.",
                postTime = new DateTime(2019, 4, 6),
                status = true,
                author = user3,
            };


            //----< Categories >-----------------
            Category ctg0 = new Category()
            {
                categoryID = 1,
                categoryName = "C++"
            };

            Category ctg1 = new Category()
            {
                categoryID = 2,
                categoryName = "C#"
            };

            Category ctg2 = new Category()
            {
                categoryID = 3,
                categoryName = "Matlab"
            };

            Category ctg3 = new Category()
            {
                categoryID = 4,
                categoryName = "HTML/CSS/JS"
            };

            //----< Projects >-----------------
            Project project0 = new Project()
            {
                projectID = 0,
                title = "Remote dependency analyzer",
                content = "Develop a communication package to implement asynchronous message passing communication between client and server with WCF." +
                "Build a client GUI based on WPF navigating server’s folders and files and display the analysis results.",
                url = "https://www.flaticon.com/premium-icon/icons/svg/1583/1583017.svg",
                createTime = new DateTime(2018, 08, 27),
                updateTime = new DateTime(2018, 12, 3),
                author = user0,
                category = ctg1,
                comments = new List<Comment>(){
                            comment0,
                            comment1,
                            comment3
                        }
            };
            projects.Add(project0);

            Project project1 = new Project()
            {
                projectID = 1,
                title = "Present Personal Website App",
                content = "Built Personal Web based on Asp.Net Core MVC, which allows users to create, edit and delete information." +
                "Created a SQL Server database and connected to the model using Entity Framework.",
                url = "https://www.flaticon.com/premium-icon/icons/svg/1710/1710554.svg",
                createTime = new DateTime(2019, 02, 1),
                updateTime = new DateTime(2019, 05, 03),
                author = user0,
                category = ctg3,
                comments = new List<Comment>(){
                            comment2,
                            comment0,
                            comment3
                        }
            };
            projects.Add(project1);

            Project project2 = new Project()
            {
                projectID = 2,
                title = "Physical crystal model project",
                content = "Assist supervisor to complete physical crystal model assembly by using MATLAB and Clanguage." +
                    "Assist supervisor to observe the shape of metal particles, for example, metal distortion, metal extension, metal compression,and so on.",
                url = "https://image.flaticon.com/icons/svg/1336/1336494.svg",
                createTime = new DateTime(2016, 11, 5),
                updateTime = new DateTime(2016, 01, 13),
                author = user0,
                category = ctg2,
                comments = new List<Comment>(){
                            comment1,
                            comment3
                        }
            };
            projects.Add(project2);
        }

        public static ProjectList getInstance()
        {
            if (instance == null)
            {
                instance = new ProjectList();
            }
            return instance;
        }

        public int size()
        {
            return projects.Count;
        }

        public void add(Project pjt)
        {
            projects.Add(pjt);
        }

        public bool delete(int id)
        {
            if (0 <= id && id < size())
            {
                projects.RemoveAt(id);
                return true;
            }
            return false;
        }

        public Project this[int i]
        {
            get { return projects[i]; }
            set { projects[i] = value; }
        }

        public IEnumerator<Project> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
