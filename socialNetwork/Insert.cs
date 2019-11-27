using System;
using System.Collections.Generic;
using System.Text;

namespace socialNetwork
{
    class Insert
    {
        public Insert()
        {
            
        }
        public void createCircle()
        {
            var pub = new Circle();
            //circle1.id = "cir1";
            pub.name = "Public";
            pub.members = new System.Collections.Generic.List<string>();

            Db.Db.circles.InsertOne(pub);
        }

        public void createUser()
        {

        }

        public void createPost()
        {

        }

        public void createComment()
        {

        }
    }
}
