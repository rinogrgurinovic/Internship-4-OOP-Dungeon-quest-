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
            var name = StringInput();
            var hero = ChoosingHeroType(name);
            
            bool exit = false;
            do
            {
                var monsters = new List<Monster>();
                var i = 0;
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

        static public int IntInput()
        {
            int input;
            var inputVerification = true;
            do
            {
                if (!inputVerification) { Console.WriteLine("Krivi unos, pokusajte ponovno:"); }
                inputVerification = int.TryParse(Console.ReadLine(), out input);
            } while (!inputVerification);
            return input;
        }
        
        static public Monster MonsterGenerator()
        {
            var randomNumberGenerator = new Random().Next(1,101);
            if (randomNumberGenerator <= 60) { return new Goblin(); }
            else if (randomNumberGenerator <= 90) { return new Brute(); }
            else { return new Witch(); }
        }

        static public Hero ChoosingHeroType(string name)
        {
            ChoosingHeroTypeMenu();
            do
            {
                switch (IntInput())
                {
                    case 1:
                        return new Gladiator(name);
                    case 2:
                        return new Marksman(name);
                    case 3:
                        return new Enchater(name);
                    default:
                        Console.WriteLine("Krivi unos, pokusajte ponovno:");
                        break;
                }
            } while (true);
        }

        static public void ChoosingHeroTypeMenu()
        {
            Console.WriteLine("Odaberite tip vaseg heroja:");
            Console.WriteLine("1 - Gladiator");
            Console.WriteLine("2 - Marksman");
            Console.WriteLine("3 - Enchanter");
        }
    }
}
