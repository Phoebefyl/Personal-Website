using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab11.Models
{
    public class CareerList : IEnumerable<Career>
    {
        public List<Career> careers { get; set; } = new List<Career>();

        private static CareerList instance { get; set; } = null;  // holds persistant instance

        private CareerList()
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
                author = user0,
            };

            Comment comment1 = new Comment()
            {
                commentID = 1,
                content = "Thank you so much. I really like your project.",
                postTime = new DateTime(2019, 3, 6),
                author = user1,
            };

            Comment comment2 = new Comment()
            {
                commentID = 2,
                content = "Great Job!",
                postTime = new DateTime(2019, 2, 6),
                author = user2,
            };

            Comment comment3 = new Comment()
            {
                commentID = 3,
                content = "I will think about give you an offer.",
                postTime = new DateTime(2019, 4, 6),
                author = user3,
            };


            //----< Categories >-----------------
            Category ctg0 = new Category()
            {
                categoryID = 1,
                categoryName = "Computer Engineering Careers"
            };

            Category ctg1 = new Category()
            {
                categoryID = 2,
                categoryName = "Information technology"
            };

            Category ctg2 = new Category()
            {
                categoryID = 3,
                categoryName = "Software Engineering"
            };


            //----< Careers >-----------------
            Career career0 = new Career()
            {
                careerID = 0,
                title = "Computer Engineering Careers",
                content = "Design and oversee the production of computer hardware equipment. Test and re-test parts to ensure they work properly." +
                "Design and develop the software systems that control computers. Design and test circuits and other electronic components.",
                url = "https://image.flaticon.com/icons/svg/1688/1688989.svg",
                createTime = new DateTime(2019, 1, 5),
                updateTime = new DateTime(2019, 2, 6),
                author = user0,
                category = ctg0,
                comments = new List<Comment>(){
                            comment0,
                            comment3
                        }
            };
            careers.Add(career0);

            Career career1 = new Career()
            {
                careerID = 1,
                title = "Information technology",
                content = "Information technology is the use of computers to store, retrieve, transmit, and manipulate data,[1] or information, often in the context of a business or other enterprise." +
                "This is my major. I will also think about choosing this area of jobs",
                url = "https://image.flaticon.com/icons/svg/1671/1671405.svg",
                createTime = new DateTime(2019, 1, 5),
                updateTime = new DateTime(2019, 2, 6),
                author = user2,
                category = ctg1,
                comments = new List<Comment>(){
                            comment2,
                            comment0,
                            comment3
                        }
            };
            careers.Add(career1);

            Career career2 = new Career()
            {
                careerID = 2,
                title = "Software Engineering",
                content = "This career is the application of engineering to the development of software in a systematic method." +
                    "The systematic application of scientific and technological knowledge, methods, and experience to the design, implementation, testing, and documentation of software" +
                    "Engineers are professionals whose main purpose is to find solutions for problems using research, scientific principles, and the tools they have at their disposal" +
                    "I would really prefer to choose software engineer jobs",
                url = "https://image.flaticon.com/icons/svg/881/881541.svg",
                createTime = new DateTime(2019, 1, 5),
                updateTime = new DateTime(2019, 2, 6),
                author = user3,
                category = ctg2,
                comments = new List<Comment>(){
                            comment1,
                            comment3
                        }

            };
            careers.Add(career2);
        }

        public static CareerList getInstance()
        {
            if (instance == null)
            {
                instance = new CareerList();
            }
            return instance;
        }

        public int size()
        {
            return careers.Count;
        }

        public void add(Career car)
        {
            careers.Add(car);
        }

        public bool delete(int id)
        {
            if (0 <= id && id < size())
            {
                careers.RemoveAt(id);
                return true;
            }
            return false;
        }

        public Career this[int i]
        {
            get { return careers[i]; }
            set { careers[i] = value; }
        }

        public IEnumerator<Career> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
