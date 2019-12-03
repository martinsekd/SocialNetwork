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

            if (user.Count == 0)
            {
                InsertDummyData();
            }
        }

        private void InsertDummyData()
        {
            //Cirkler
            insert.createCircle("Public");
            insert.createCircle("Lystrup-Slænget");
            insert.createCircle("Aarhus-Universitet");


            // Users
            insert.createUser("AndreasAHN", "Andreas Hervert Nielsen", 25, "M");
            insert.createUser("DerpEtte", "Marie Unmack Bærentzen", 22, "K");
            insert.createUser("Albert21", "Simon Anh Cao Nguyen", 25, "M");
            insert.createUser("Martinsekd", "Martin Skelde Krøjmand", 22, "M");
            insert.createUser("MikkezMrr", "Mikkel Rohde Richter", 25, "M");
            insert.createUser("Asser", "Asbjørn Ege Scøjler", 24, "M");
            insert.createUser("TheFlipFlop", "Nanna Hougaard", 25, "K");
            insert.createUser("AK47", "Anne-Katrine Japhetson Mortensen", 24, "K");
            insert.createUser("Grisen523", "Magnus Japhetson Mortensen", 24, "M");

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
            insert.addUserToCircle(Db.@select.GetUser("Martinsekd"), Db.@select.GetCircle("Aarhus-Universitet"));




            //Add block for some users
            var userIns1 = Db.@select.GetUser("Martinsekd");

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
            insert.createPost("Det nye køleskab", "Jeg har fået et nyt køleskab til 900 kr.?", "www.imgur.dk/img", userAndreasAHN, circlePublic);
            insert.createPost("Lasagneopskrift", "Oksekød\nTomat\nPersille\nGulerødder\nSeleri\n\nregano\n", "https://www.google.com/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwj8p6TV2ZnmAhUMyaQKHZBOAecQjRx6BAgBEAQ&url=https%3A%2F%2Fmambeno.dk%2Fopskrifter%2Flaekker-lasagne-oestershatte%2F&psig=AOvVaw3MU4GGQqOgGJXmReNYMqWW&ust=1575470105845074", userAndreasAHN, circleLystrup);
            insert.createPost("League of Legends", "Jeg mangler en spille makker, nogen der er frisk på ranked???? ", "https://previews.123rf.com/images/manyapeace45/manyapeace451712/manyapeace45171200537/91907334-christmas-dinner-cheers-top-of-view-of-a-nicely-served-wooden-table-christmas-dinner-with-tasty-dish.jpg", userAndreasAHN, circleUni);

            ////DerpEtte
            var userDerpEtte = Db.@select.GetUser("DerpEtte");
            insert.createPost("Julefrokost 8 dec", "Kom og join min julefrokost på jomfru ane gade på Sprutten. Vi begynder kl 19:00. Glæder mig til at se jer?", "", userDerpEtte, circlePublic);
            insert.createPost("Ny julemand", "Der er kommet ny julemand i Grønland.", "www.jul.dk/img", userDerpEtte, circleUni);

            ////Martinsekd
            var userMartinsekd = Db.@select.GetUser("Martinsekd");
            insert.createPost("Har i hørt det sidste nye", "Alle i familien er syge", "", userMartinsekd, circlePublic);
            insert.createPost("Lektier...", "Man får altså alt for mange lektier for nu", "", userMartinsekd, circleUni);

            ////Albert21
            var userAlbert21 = Db.@select.GetUser("Albert21");
            insert.createPost("PC tips?", "Er der nogen der kan give mig gode tips til opgradering af min PC?", "", userAlbert21, circlePublic);
            insert.createPost("Hvor mange amerikanere er bange for fredag den 13.?", " Rigtig mange", "", userAlbert21, circleUni);

            ////MikkezMrr
            var userMikkezMrr = Db.@select.GetUser("MikkezMrr");
            insert.createPost("Fobi for lange ord?", "Hippopotomonstrosesquippedaliafobi, læs det hurtigt", "", userMikkezMrr, circlePublic);
            insert.createPost("Hvor kommer ordet skole fra?", "Ordet skole kommer af det latinske ord schola. The more you know.", "", userMikkezMrr, circleLystrup);

            ////Asser
            var userAsser = Db.@select.GetUser("Asser");
            insert.createPost("Hvordan bruger man ordet nat?", "Ved at udtale nat", "", userAsser, circlePublic);
            insert.createPost("Hvilken farve havde julemandens rigtige tøj?", "Julemanden var oprindeligt klædt i grønt. Green santa", "", userAsser, circleLystrup);

            ////TheFlipFlop
            var userTheFlipFlop = Db.@select.GetUser("TheFlipFlop");
            insert.createPost("Hvor hurtigt skal man gå for at nå over et fodgængerfelt inden rødt?", "Umuligt hvis man ikke kan gå.", "", userTheFlipFlop, circlePublic);
            insert.createPost("Hvordan er en bils bremselængde?", "Lidt sødt og saltet", "", userTheFlipFlop, circleLystrup);

            ////AK47
            var userAK47 = Db.@select.GetUser("AK47");
            insert.createPost("Hvor hurtig er en snegl?", "637 år for at vandre fra Nordjylland til Spanien i hastigt tempo.", "", userAK47, circlePublic);
            insert.createPost("Skrammel vand", "Vand med brus er altså noget værre bras", "", userAK47, circleLystrup);

            ////Grisen523
            var userGrisen523 = Db.@select.GetUser("Grisen523");
            insert.createPost("Facebook, hvor mange venner har jeg?", "Facebook, hvor mange venner har jeg??", "", userGrisen523, circlePublic);
            insert.createPost("Det er blevet december", "Det er så koldt", "", userGrisen523, circleLystrup);





            //Add comment to somepost
            ////AndreasAHN
            Post post = Db.@select.GetPostFromTitle("Det er blevet december");
            insert.createComment("Eller til et bad i havnen", "AndreasAHN", post);
            post = Db.@select.GetPostFromTitle("Hvor hurtig er en snegl?");
            insert.createComment("Hvor mange gange når den at dø på den tid? XD", "AndreasAHN", post);
            post = Db.@select.GetPostFromTitle("Hvor hurtigt skal man gå for at nå over et fodgængerfelt inden rødt?");
            insert.createComment("Det jo sådan set rigtigt.", "AndreasAHN", post);
            post = Db.@select.GetPostFromTitle("Fobi for lange ord?");
            insert.createComment("Nej tak", "AndreasAHN", post);
            post = Db.@select.GetPostFromTitle("PC tips?");
            insert.createComment("Køb ryzen", "AndreasAHN", post);
            post = Db.@select.GetPostFromTitle("Julefrokost 8 dec");
            insert.createComment("Jeg kommer, må jeg tage nogle venner med", "AndreasAHN", post);

            ////DerpEtte
            post = Db.@select.GetPostFromTitle("Fobi for lange ord?");
            insert.createComment("KAN DU KOM NED AD DEN CYKLE", "DerpEtte", post);
            post = Db.@select.GetPostFromTitle("Hvor mange amerikanere er bange for fredag den 13.?");
            insert.createComment("Det havde jeg ikke forventet", "DerpEtte", post);
            post = Db.@select.GetPostFromTitle("PC tips?");
            insert.createComment("Intel for lyfe", "DerpEtte", post);
            post = Db.@select.GetPostFromTitle("League of Legends");
            insert.createComment("Jeg er frisk, hvornår kan du?", "DerpEtte", post);
            post = Db.@select.GetPostFromTitle("Det nye køleskab");
            insert.createComment("Meget cool!", "DerpEtte", post);

            ////Martinsekd
            post = Db.@select.GetPostFromTitle("PC tips?");
            insert.createComment("Geforce RTX 2080 ti for minecraft", "Martinsekd", post);
            post = Db.@select.GetPostFromTitle("Ny julemand");
            insert.createComment("Jeg håber han giver flere gaver end den gamle", "Martinsekd", post);
            post = Db.@select.GetPostFromTitle("League of Legends");
            insert.createComment("I morgen aften.", "Martinsekd", post);



            ////Albert21
            post = Db.@select.GetPostFromTitle("Lektier...");
            insert.createComment("Jeg elsker lektier", "Albert21", post);
            post = Db.@select.GetPostFromTitle("Har i hørt det sidste nye");
            insert.createComment("Fordi de kom til at ryge?", "Albert21", post);
            post = Db.@select.GetPostFromTitle("Ny julemand");
            insert.createComment("Hvor gammel er han?", "Albert21", post);
            post = Db.@select.GetPostFromTitle("League of Legends");
            insert.createComment("Hvad din elo?", "Albert21", post);



            ////MikkezMrr
            post = Db.@select.GetPostFromTitle("Skrammel vand");
            insert.createComment("Enig", "MikkezMrr", post);
            post = Db.@select.GetPostFromTitle("Hvilken farve havde julemandens rigtige tøj?");
            insert.createComment("Reported", "MikkezMrr", post);
            post = Db.@select.GetPostFromTitle("Hvilken farve havde julemandens rigtige tøj?");
            insert.createComment("k", "MikkezMrr", post);
            post = Db.@select.GetPostFromTitle("Hvordan bruger man ordet nat?");
            insert.createComment("Virkelig?", "MikkezMrr", post);


            ////Asser
            post = Db.@select.GetPostFromTitle("Det er blevet december");
            insert.createComment("Skal vi ikke ud og lave ølbowling", "Asser", post);
            post = Db.@select.GetPostFromTitle("Facebook, hvor mange venner har jeg?");
            insert.createComment("Det er ikke siri", "Asser", post);
            post = Db.@select.GetPostFromTitle("Hvordan er en bils bremselængde?");
            insert.createComment("50m ved 225 km i timen", "Asser", post);
            post = Db.@select.GetPostFromTitle("Fobi for lange ord?");
            insert.createComment("Kom bare do", "Asser", post);



            ////TheFlipFlop
            post = Db.@select.GetPostFromTitle("Det er blevet december");
            insert.createComment("Sindsyge mennesker", "TheFlipFlop", post);
            post = Db.@select.GetPostFromTitle("Hvordan bruger man ordet nat?");
            insert.createComment("Det havde jeg ikke tænkt på før", "TheFlipFlop", post);
            post = Db.@select.GetPostFromTitle("Hvor kommer ordet skole fra?");
            insert.createComment("Tak for info!", "TheFlipFlop", post);
            post = Db.@select.GetPostFromTitle("Lasagneopskrift");
            insert.createComment("Kom forbi og lav den, jeg er sulten.", "TheFlipFlop", post);


            ////AK47
            post = Db.@select.GetPostFromTitle("Hvilken farve havde julemandens rigtige tøj?");
            insert.createComment("Tak for info", "AK47", post);
            post = Db.@select.GetPostFromTitle("Hvor kommer ordet skole fra?");
            insert.createComment("Okay, fedt", "AK47", post);
            post = Db.@select.GetPostFromTitle("Lasagneopskrift");
            insert.createComment("Kan jeg joine jer?", "AK47", post);
            post = Db.@select.GetPostFromTitle("Det nye køleskab");
            insert.createComment("Havde du for meget gammel ost i det gamle. Stank det???", "AK47", post);


            ////Grisen523
            post = Db.@select.GetPostFromTitle("Hvilken farve havde julemandens rigtige tøj?");
            insert.createComment("Stop spam!", "Grisen523", post);
            post = Db.@select.GetPostFromTitle("Hvordan bruger man ordet nat?");
            insert.createComment("Det har jeg prøvet!", "Grisen523", post);
            post = Db.@select.GetPostFromTitle("Lasagneopskrift");
            insert.createComment("A congratulations!", "Grisen523", post);
            post = Db.@select.GetPostFromTitle("Det nye køleskab");
            insert.createComment("Kan jeg ligge nogle ting på køl, mit er lige gået i stykker.", "Grisen523", post);
        }
    }
}
