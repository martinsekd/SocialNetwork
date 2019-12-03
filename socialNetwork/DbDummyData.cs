using System;
using System.Collections.Generic;
using System.Text;

namespace socialNetwork
{
    class DbDummyData
    {
        private Insert insert;
        private Select selects;

        public DbDummyData()
        {
            insert = new Insert();
            selects = new Select();

            List<User> user = Db.select.GetAllUsers();

            if (user.Count() == 0)
                InsertDummyData();
        }

        private void InsertDummyData()
        {
            // Users
            insert.createUser("AndreasAHN", "Andreas Hervert Nielsen", 25, "Mand");
            insert.createUser("DerpEtte", "Marie Unmack Bærentzen", 22, "Kvinde");
            insert.createUser("Albert21", "Simon Anh Cao Nguyen", 25, "Mand");
            insert.createUser("MartinSCK", "Martin Skelde Krøjmand", 22, "Mand");
            insert.createUser("MikkezMrr", "Mikkel Rohde Richter", 25, "Mand");
            insert.createUser("Asser", "Asbjørn Ege Scøjler", 24, "Mand");
            insert.createUser("TheFlipFlop", "Nanna Hougaard", 25, "Kvinde");
            insert.createUser("AK47", "Anne-Katrine Japhetson Mortensen", 24, "Kvinde");
            insert.createUser("Grisen523", "Magnus Japhetson Mortensen", 24, "Mand");

            //Cirkler
            insert.createCircle("Public");
            insert.createCircle("Lystrup-Slænget");
            insert.createCircle("Aarhus-Universitet");

            //Add all users to Public cirkel
            List<User> user = Db.select.GetAllUsers();
            for (int i = 0; i < user.Count; i++)
            {
                insert.addUserToCircle(Db.@select.GetUser(user[i].userid), Db.@select.GetCircle("Public"));
            }


            //Add user to cirkels
            insert.addUserToCircle(Db.@select.GetUser("AndreasAHN"), Db.@select.GetCircle("Lystrup-Slænget"));
            insert.addUserToCircle(Db.@select.GetUser("MikkezMrr"), Db.@select.GetCircle("Lystrup-Slænget"));
            insert.addUserToCircle(Db.@select.GetUser("Asser"), Db.@select.GetCircle("Lystrup-Slænget"));
            insert.addUserToCircle(Db.@select.GetUser("TheFlipFlop"), Db.@select.GetCircle("Lystrup-Slænget"));
            insert.addUserToCircle(Db.@select.GetUser("AK47"), Db.@select.GetCircle("Lystrup-Slænget"));
            insert.addUserToCircle(Db.@select.GetUser("Grisen523"), Db.@select.GetCircle("Lystrup-Slænget"));

            insert.addUserToCircle(Db.@select.GetUser("AndreasAHN"), Db.@select.GetCircle("Aarhus-Universitet"));
            insert.addUserToCircle(Db.@select.GetUser("DerpEtte"), Db.@select.GetCircle("Aarhus-Universitet"));
            insert.addUserToCircle(Db.@select.GetUser("Albert21"), Db.@select.GetCircle("Aarhus-Universitet"));
            insert.addUserToCircle(Db.@select.GetUser("MartinSCK"), Db.@select.GetCircle("Aarhus-Universitet"));




            //Add block for some users
            var userIns1 = Db.@select.GetUser("MartinSCK");

            var blockUserIns1 = Db.@select.GetUser("MikkezMrr");
            insert.addBlockedUser(userIns1, blockUserIns1);

            var blockUserIns2 = Db.@select.GetUser("Asser");
            insert.addBlockedUser(userIns1, blockUserIns2);

            var blockUserIns3 = Db.@select.GetUser("TheFlipFlop");
            insert.addBlockedUser(userIns1, blockUserIns3);

            var blockUserIns4 = Db.@select.GetUser("AK47");
            insert.addBlockedUser(userIns1, blockUserIns4);

            var blockUserIns5 = Db.@select.GetUser("Grisen523");
            insert.addBlockedUser(userIns1, blockUserIns5);


            var userIns2 = Db.@select.GetUser("Albert21");
            insert.addBlockedUser(userIns2, blockUserIns1);
            insert.addBlockedUser(userIns2, blockUserIns2);
            insert.addBlockedUser(userIns2, blockUserIns3);
            insert.addBlockedUser(userIns2, blockUserIns4);
            insert.addBlockedUser(userIns2, blockUserIns5);




            //Add 1 post to every user for every cirkle
            var circlePublic = Db.@select.GetCircle("Public");
            var circleLystrup = Db.@select.GetCircle("Lystrup-Slænget");
            var circleUni = Db.@select.GetCircle("Aarhus-Universitet");

            ////AndreasAHN
            var userAndreasAHN = Db.@select.GetUser("AndreasAHN");
            insert.createPost("Rosiner", "Hvorfor?", "", userAndreasAHN, circlePublic);
            insert.createPost("Rosiner", "Hvorfor?", "", userAndreasAHN, circleLystrup);
            insert.createPost("Rosiner", "Hvorfor?", "", userAndreasAHN, circleUni);

            ////DerpEtte
            var userDerpEtte = Db.@select.GetUser("DerpEtte");
            insert.createPost("Rosiner", "Hvorfor?", "", userDerpEtte, circlePublic);
            insert.createPost("Rosiner", "Hvorfor?", "", userDerpEtte, circleUni);

            ////MartinSCK
            var userMartinSCK = Db.@select.GetUser("MartinSCK");
            insert.createPost("Rosiner", "Hvorfor?", "", userMartinSCK, circlePublic);
            insert.createPost("Rosiner", "Hvorfor?", "", userMartinSCK, circleUni);

            ////Albert21
            var userAlbert21 = Db.@select.GetUser("Albert21");
            insert.createPost("Rosiner", "Hvorfor?", "", userAlbert21, circlePublic);
            insert.createPost("Rosiner", "Hvorfor?", "", userAlbert21, circleUni);

            ////MikkezMrr
            var userMikkezMrr = Db.@select.GetUser("MikkezMrr");
            insert.createPost("Rosiner", "Hvorfor?", "", userMikkezMrr, circlePublic);
            insert.createPost("Rosiner", "Hvorfor?", "", userMikkezMrr, circleLystrup);

            ////Asser
            var userAsser = Db.@select.GetUser("Asser");
            insert.createPost("Rosiner", "Hvorfor?", "", userAsser, circlePublic);
            insert.createPost("Rosiner", "Hvorfor?", "", userAsser, circleLystrup);

            ////TheFlipFlop
            var userTheFlipFlop = Db.@select.GetUser("TheFlipFlop");
            insert.createPost("Rosiner", "Hvorfor?", "", userTheFlipFlop, circlePublic);
            insert.createPost("Rosiner", "Hvorfor?", "", userTheFlipFlop, circleLystrup);

            ////AK47
            var userAK47 = Db.@select.GetUser("AK47");
            insert.createPost("Rosiner", "Hvorfor?", "", userAK47, circlePublic);
            insert.createPost("Rosiner", "Hvorfor?", "", userAK47, circleLystrup);

            ////Grisen523
            var userGrisen523 = Db.@select.GetUser("Grisen523");
            insert.createPost("Rosiner", "Hvorfor?", "", userGrisen523, circlePublic);
            insert.createPost("Rosiner", "Hvorfor?", "", userGrisen523, circleLystrup);





            //Add comment to somepost
            ////AndreasAHN
            //Post post = Db.@select.GetPostFromTitle(titel);
            //Db.insert.createComment(postComment, UserId, post);

            ////DerpEtte

            ////MartinSCK

            ////Albert21

            ////MikkezMrr


            ////Asser

            ////TheFlipFlop

            ////AK47

            ////Grisen523

        }
    }
}
