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
                    hero.HealthPoints = Battle(hero, monsters[i], i + 1);

                    if (hero.HealthPoints <= 0)
                    {
                        exit = GameOver();
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine($"Pobijedili ste {i + 1}. bitku");
                    Console.WriteLine();

                    Console.WriteLine($"Osvojili ste {monsters[i].Experience} XP-a");
                    hero.Experience += monsters[i].Experience;
                    Console.WriteLine();

                    if (hero.Experience >= 100)
                    {
                        hero.Level++;
                        hero.Experience -= 100;
                        Console.WriteLine($"Level up-ali ste se, vas novi level je {hero.Level}");

                        Console.WriteLine();
                    }

                    Console.WriteLine($"Vratilo vam se {0.25 * hero.HealthPointsMax} HP-a");
                    hero.HealthPoints *= 1.25;
                    Console.WriteLine();

                    Console.WriteLine("Pritisnite tipku za nastavak");
                    Console.ReadKey();

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

        static public double Battle(Hero hero, Monster monster, int monsterNumber)
        {
            do
            {
                Console.WriteLine($"Borite se protiv - {monster.Name} ({monsterNumber}/10)");

                DisplayHeroStats(hero);
                Console.WriteLine();
                DisplayMonsterStats(monster);
                Console.WriteLine();

                var heroMove = HeroMoves();
                var monsterMove = (BattleMove)new Random().Next(0, 3);

                if (heroMove == monsterMove)
                {
                    Console.WriteLine("Cudoviste je izabralo isto sto i vi, nista se ne dogodi. Pritisnite tipku za nastavak");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else if (DetermineRoundWinner(heroMove, monsterMove)) { monster.HealthPoints -= hero.Damage; }
                else { hero.HealthPoints -= monster.Damage; }

                if (monster.HealthPoints <= 0 || hero.HealthPoints <= 0) { return hero.HealthPoints; }
                Console.Clear();
            } while (true);
        }

        static public bool DetermineRoundWinner(BattleMove heroMove, BattleMove monsterMove)
        {
            if ((heroMove == BattleMove.Direct && monsterMove == BattleMove.Side) ||
                (heroMove == BattleMove.Side && monsterMove == BattleMove.Counter) ||
                (heroMove == BattleMove.Counter && monsterMove == BattleMove.Direct))
            {
                Console.WriteLine("Vi ste pobijedili rundu. Pritisnite tipku za nastavak");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("Cudoviste je pobijedilo rundu. Pritisnite tipku za nastavak");
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

        static public void DisplayHeroStats(Hero hero)
        {
            Console.WriteLine(hero.Name);
            Console.WriteLine($"HP - {hero.HealthPoints}/{hero.HealthPointsMax}");
            Console.WriteLine($"Damage - {hero.Damage}");
            Console.WriteLine($"Level - {hero.Level}");
            Console.WriteLine($"XP - {hero.Experience}/100");
        }

        static public void DisplayMonsterStats(Monster monster)
        {
            Console.WriteLine(monster.Name);
            Console.WriteLine($"HP - {monster.HealthPoints}/{monster.HealthPointsMax}");
            Console.WriteLine($"Damage - {monster.Damage}");
        }

        static public bool GameOver()
        {
            Console.WriteLine("Umrli ste, zelite li pokusati ponovno?");
            string input = StringInput();
            do
            {
                switch (input.ToLower())
                {
                    case "da":
                        return false;
                    case "ne":
                        return true;
                    default:
                        Console.WriteLine("Krivi unos, pokusajte ponovno:");
                        break;
                }
            } while (true);
        }
    }
}
