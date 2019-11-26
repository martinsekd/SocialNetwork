

namespace socialNetwork
{
    class Db
    {
        public static IMongoCollection<User> users;
        public static IMongoCollection<Post> posts;
        public static IMongoCollection<Circle> circles;

        public static void feed(string userid)
        {
            //var user2 = Builders<User>.Filter.Eq("userid", userid);
            var user2 = (users.Find(u => u.userid == userid)).ToList();
            foreach (var u in user2)
                Console.WriteLine(u.name);
        }

        public static void insertTestData()
        {
            var pub = new Circle();
            //circle1.id = "cir1";
            pub.name = "Public";
            pub.members = new System.Collections.Generic.List<string>();

            var circle1 = new Circle();
            //circle1.id = "cir1";
            circle1.name = "Our private circle";
            circle1.members = new System.Collections.Generic.List<string>();

            var post1 = new Post();
            post1.id = ObjectId.GenerateNewId((int)DateTime.Now.ToFileTime()).ToString();
            post1.description = "Her er en beskrivelse 1 ";
            post1.title = "Title 1";
            post1.url = "www.dr.dk";
            post1.created = DateTime.Now;
            post1.circle = circle1;
            post1.comments = new System.Collections.Generic.List<Comment>();

            var post2 = new Post();
            post2.id = ObjectId.GenerateNewId((int)DateTime.Now.ToFileTime()).ToString();
            post2.description = "Her er en beskrivelse 2";
            post2.title = "Title 2";
            post2.url = "www.tv2.dk";
            post2.created = DateTime.Now;
            post2.circle = pub;
            post2.comments = new System.Collections.Generic.List<Comment>();

            var post3 = new Post();
            post3.id = ObjectId.GenerateNewId((int)DateTime.Now.ToFileTime()).ToString();
            post3.description = "Her er en beskrivelse 3";
            post3.title = "Title 3";
            post3.url = "www.google.dk";
            post3.created = DateTime.Now;
            post3.circle = circle1;
            post3.comments = new System.Collections.Generic.List<Comment>();


            var user1 = new User();
            user1.userid = "B�rge";
            user1.age = 20;
            user1.gender = "Mand";
            user1.name = "Carl B�rge Hansen";
            user1.posts = new System.Collections.Generic.List<Post>();
            user1.circles = new System.Collections.Generic.List<Circle>();
            user1.blocked = new System.Collections.Generic.List<string>();
            user1.posts.Add(post1);
            user1.posts.Add(post2);
            //users.InsertOne(user1);

            var user2 = new User();
            user2.userid = "Birger";
            user2.age = 20;
            user2.gender = "Mand";
            user2.name = "Birger Hansen";
            user2.posts = new System.Collections.Generic.List<Post>();
            user2.circles = new System.Collections.Generic.List<Circle>();
            user2.blocked = new System.Collections.Generic.List<string>();
            //users.InsertOne(user2);

            var user3 = new User();
            user3.userid = "Carl";
            user3.age = 20;
            user3.gender = "Mand";
            user3.name = "Carl B�rge Hansen";
            user3.posts = new System.Collections.Generic.List<Post>();
            user3.circles = new System.Collections.Generic.List<Circle>();
            user3.blocked = new System.Collections.Generic.List<string>();
            user3.posts.Add(post3);
            //users.InsertOne(user3);


            circle1.members.Add(user1.userid);
            circle1.members.Add(user2.userid);
            circles.InsertOne(circle1);

            user1.circles.Add(circle1);
            user2.circles.Add(circle1);

            Comment c1 = new Comment();
            c1.content = "Godt br�lt l�ve";
            c1.user = user2.userid;
            post1.comments.Add(c1);

            Comment c2 = new Comment();
            c2.content = "Godt g�et";
            c1.user = user2.userid;
            post1.comments.Add(c2);

            user1.blocked.Add(user3.userid);

            users.InsertOne(user1);
            users.InsertOne(user2);
            users.InsertOne(user3);
        }
    }
}