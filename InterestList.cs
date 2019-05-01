using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab11.Models
{
    public class InterestList : IEnumerable<Interest>
    {
        public List<Interest> interests { get; set; } = new List<Interest>();

        private static InterestList instance { get; set; } = null;  // holds persistant instance

        private InterestList()
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
                categoryName = "Music"
            };

            Category ctg1 = new Category()
            {
                categoryID = 2,
                categoryName = "Game"
            };

            Category ctg2 = new Category()
            {
                categoryID = 3,
                categoryName = "Cook"
            };

            Category ctg3 = new Category()
            {
                categoryID = 4,
                categoryName = "Travel"
            };

            //----< Interests >-----------------
            Interest interest0 = new Interest()
            {
                interestID = 0,
                title = "Music",
                content = "I have already played piano for ten more years. I had a lot of fun during the process." +
                "Hope you could also play a musical instrument to release yourself when you feel depressed.",
                url = "https://image.flaticon.com/icons/svg/1754/1754368.svg",
                createTime = new DateTime(2000, 12, 5),
                updateTime = new DateTime(2010, 8, 24),
                author = user0,
                category = ctg0,
                comments = new List<Comment>(){
                            comment0,
                            comment1,
                            comment3
                        }
            };
            interests.Add(interest0);

            Interest interest1 = new Interest()
            {
                interestID = 1,
                title = "Game",
                content = "Weiqi is a kind of game played with black and white pieces on a board of 361 crosses." +
                "I learned it when I was about 5 years old. This game could cultivate my logic capbility and I also enjoyed it.",
                url = "https://image.flaticon.com/icons/svg/1390/1390232.svg",
                createTime = new DateTime(2000, 11, 5),
                updateTime = new DateTime(2005, 2, 6),
                author = user0,
                category = ctg1,
                comments = new List<Comment>(){
                            comment2,
                            comment0,
                            comment3
                        }
            };
            interests.Add(interest1);

            Interest interest2 = new Interest()
            {
                interestID = 2,
                title = "Cook",
                content = "After I went abroad, I had no choice to cook by my self." +
                    "Now cooking new dishes is my favourite hobby.",
                url = "https://image.flaticon.com/icons/svg/1591/1591431.svg",
                createTime = new DateTime(2019, 1, 5),
                updateTime = new DateTime(2019, 2, 6),
                author = user0,
                category = ctg2,
                comments = new List<Comment>(){
                            comment1,
                            comment3
                        }
            };
            interests.Add(interest2);

            Interest interest3 = new Interest()
            {
                interestID = 3,
                title = "Travelling",
                content = "I really love travelling. My dream is to travel all over the world in the future." +
                    "And also hope I could travel with my best friends and my families",
                url = "https://image.flaticon.com/icons/svg/201/201623.svg",
                createTime = new DateTime(2019, 1, 5),
                updateTime = new DateTime(2019, 2, 6),
                author = user0,
                category = ctg3,
                comments = new List<Comment>(){
                            comment1,
                            comment2
                        }
            };
            interests.Add(interest2);
        }

        public static InterestList getInstance()
        {
            if (instance == null)
            {
                instance = new InterestList();
            }
            return instance;
        }

        public int size()
        {
            return interests.Count;
        }

        public void add(Interest its)
        {
            interests.Add(its);
        }

        public bool delete(int id)
        {
            if (0 <= id && id < size())
            {
                interests.RemoveAt(id);
                return true;
            }
            return false;
        }

        public Interest this[int i]
        {
            get { return interests[i]; }
            set { interests[i] = value; }
        }

        public IEnumerator<Interest> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
