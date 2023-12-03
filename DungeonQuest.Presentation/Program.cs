using DungeonQuest.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Upisite ime vaseg heroja:");
            string name = StringInput();
            var hero = new Hero(name);
            
            bool exit = false;
            do
            {
                var monsters = new List<Monster>();
                int i = 0;
                while (i < 10)
                {
                    monsters.Add(MonsterGenerator());
                    i++;
                }
                
            } while (!exit);
            
        }

        static public string StringInput()
        {
            string input;
            do { input = Console.ReadLine(); } while (input.Trim() == "");
            return input;
        }
        
        static public Monster MonsterGenerator()
        {
            int randomNumberGenerator = new Random().Next(1,101);
            if (randomNumberGenerator <= 60) { return new Goblin(); }
            else if (randomNumberGenerator <= 90) { return new Brute(); }
            else { return new Witch(); }
        }
    }
}
