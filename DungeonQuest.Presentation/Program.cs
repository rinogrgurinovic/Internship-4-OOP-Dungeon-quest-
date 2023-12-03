using DungeonQuest.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonQuest.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            do
            {
                Console.WriteLine("Upisite ime vaseg heroja:");
                var name = StringInput();
                var hero = ChoosingHeroType(name);

                var monsters = new List<Monster>();
                var i = 0;
                while (i < 10)
                {
                    monsters.Add(MonsterGenerator());
                    i++;
                }
                
                i = 0;
                while (i < 10)
                {
                    Console.Clear();
                    Battle(hero, monsters[i]);
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

        static public Monster MonsterGenerator()
        {
            var randomNumberGenerator = new Random().Next(1,101);
            if (randomNumberGenerator <= 60) { return new Goblin(); }
            else if (randomNumberGenerator <= 90) { return new Brute(); }
            else { return new Witch(); }
        }

        static public bool Battle(Hero hero, Monster monster)
        {
            do
            {
                var heroMove = HeroMoves();
                var monsterMove = (BattleMove)new Random().Next(0, 3);
                if (heroMove == monsterMove)
                {
                    Console.WriteLine("Cudoviste je izabralo isto sto i vi, nista se ne dogodi. Pritisnite tipku za nastavak");
                    Console.ReadKey();
                    continue;
                }
                Round(heroMove, monsterMove);
                
            } while (true);
        }

        static public bool Round(BattleMove heroMove, BattleMove monsterMove)
        {
            if ((heroMove == BattleMove.Direct && monsterMove == BattleMove.Side) ||
                (heroMove == BattleMove.Side && monsterMove == BattleMove.Counter) ||
                (heroMove == BattleMove.Counter && monsterMove == BattleMove.Direct))
            {
                Console.WriteLine("Vi ste dobili rundu. Pritisnite tipku za nastavak");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("Cudoviste je dobilo rundu. Pritisnite tipku za nastavak");
                Console.ReadKey();
                return false;
            }
        }

        static public BattleMove HeroMoves()
        {
            HeroMovesMenu();
            do
            {
                switch (IntInput())
                {
                    case 1:
                        return BattleMove.Direct;
                    case 2:
                        return BattleMove.Side;
                    case 3:
                        return BattleMove.Counter;
                    default:
                        Console.WriteLine("Krivi unos, pokusajte ponovno:");
                        break;
                }
            } while (true);
        }

        static public void HeroMovesMenu()
        {
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 - Direktan napad");
            Console.WriteLine("2 - Napad s boka");
            Console.WriteLine("3 - Protunapad");
        }

        public enum BattleMove
        {
            Direct,
            Side,
            Counter
        }
    }
}
