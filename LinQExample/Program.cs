using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQExample
{

    public class Player
    {
        Guid _id;//unique all over world(pc clock + MAC)
        string _name;
        int _xp;
        public Guid Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int Xp
        {
            get
            {
                return _xp;
            }

            set
            {
                _xp = value;
            }
        }


        public override string ToString()   
        {
            return _id.ToString()+" "+ _name.ToString() + " " + _xp.ToString();
        }
    }

    class Program
    {
        static List<Player> players = new List<Player>()
        {
            new Player {Id = Guid.NewGuid(), Name = "Pete Volga", Xp=90 },
            new Player {Id = Guid.NewGuid(), Name = "John Doe", Xp=10 },
            new Player {Id = Guid.NewGuid(), Name = "Pete Blogs", Xp=250 },
            new Player {Id = Guid.NewGuid(), Name = "Glenn OGrady", Xp=300 }
        };

        static void Main(string[] args)
        {
            //return the first occurance of the match or null
            Player found = players.FirstOrDefault(p => p.Name == "John Doe");
            if (found != null)
                Console.WriteLine("{0}", found.ToString());
            else
                Console.WriteLine("not found");

            Console.WriteLine("\n");


            //return the first occurance of the some records 
            Player found1 = players.FirstOrDefault(p => p.Name.Contains("Pete"));
            if (found1 != null)
                Console.WriteLine("{0}", found1.ToString());
            else
                Console.WriteLine("not found");

            Console.WriteLine("\n");



            //return all those with an XP value over 100
            List<Player> topPlayers = players.Where(plr => plr.Xp >= 100).ToList();

            if (topPlayers.Count > 0)
                foreach (var item in topPlayers)
                {
                    Console.WriteLine("{0}", item.ToString());

                }
            else
                Console.WriteLine("no top players");

            Console.WriteLine("\n");



            //scorebard of players + xp

            var ScoreBoard = players
                                    .OrderByDescending(o => o.Xp)
                                    .Select(scores => new { scores.Name, scores.Xp });
            foreach (var item in ScoreBoard)
            {
                Console.WriteLine("{0}\t{1}", item.Name, item.Xp);
            }




            Console.ReadKey();
        }
    }
}
