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
            bool exit;
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
                while (true)
                {
                    Console.Clear();
                    hero.HealthPoints = Battle(hero, monsters[i], i + 1);

                    if (hero.HealthPoints <= 0 && hero.Revive)
                    {
                        hero.Revive = false;
                        Console.WriteLine("Umrli ste, ali ste se vatili iz mrtvih");
                        hero.HealthPoints = hero.HealthPointsMax;
                        hero.Mana = hero.ManaMax;
                        hero.HealthPoints = Battle(hero, monsters[i], i + 1);
                    }

                    if (hero.HealthPoints <= 0 && !hero.Revive)
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
                        hero.HealthPointsMax += 5;
                        hero.Damage += 2;
                        hero.ManaMax += 5;
                        hero.CriticalChance += 5;
                        hero.StunChance += 5;
                        Console.WriteLine();
                    }

                    Console.WriteLine($"Vratilo vam se {0.25 * hero.HealthPointsMax} HP-a");
                    hero.HealthPoints *= 1.25;
                    if (hero.HealthPoints > hero.HealthPointsMax)
                        hero.HealthPoints = hero.HealthPointsMax;
                    Console.WriteLine();

                    if (hero.Type == Hero.HeroType.Enchanter)
                    {
                        Console.WriteLine("Obnovljena vam je mana");
                        hero.Mana = hero.ManaMax;
                        Console.WriteLine();
                    }

                    Console.WriteLine("Pritisnite tipku za nastavak");
                    Console.ReadKey();

                    if (hero.HealthPoints != hero.HealthPointsMax)
                        if (UseXPToHeal())
                        {
                            hero.Experience /= 2;
                            hero.HealthPoints = hero.HealthPointsMax;
                            Console.WriteLine("Obnovljen HP. Pritisnite tipku za nastavak");
                            Console.ReadKey();
                        }

                    i++;

                    if (i == 9) 
                    { 
                        exit = GameWin(hero);
                        break;
                    }
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
                else if (DetermineRoundWinner(heroMove, monsterMove)) { 
                    if (hero.Type == Hero.HeroType.Marksman)
                    {
                        var randomNumberGenerator = new Random().Next(1, 101);
                        if (randomNumberGenerator <= hero.CriticalChance)
                            monster.HealthPoints -= hero.Damage;
                    }
                    monster.HealthPoints -= hero.Damage;
                }
                else if (monster.Name == "Brute")
                {
                    var randomNumberGenerator = new Random().Next(1, 101);
                    if (randomNumberGenerator <= 33)
                        hero.HealthPoints *= monster.TrueDamage;
                }
                else if (monster.Name == "Witch")
                {
                    var randomNumberGenerator = new Random().Next(1, 101);
                    if (randomNumberGenerator <= 15)
                    {
                        var randomHealthPoints = new Random().Next(1, 101);
                        hero.HealthPointsMax = randomHealthPoints;
                    }
                }
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
            if (hero.Type == Hero.HeroType.Enchanter)
            {
                Console.WriteLine($"Mana - {hero.Mana}");
            }
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
            var input = StringInput();
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

        static public bool GameWin(Hero hero)
        {
            Console.WriteLine("Pobijedili ste!");
            Console.WriteLine();
            Console.WriteLine("Vasi konacni statovi:");
            DisplayHeroStats(hero);
            Console.WriteLine("Pritisnite tipku za kraj");
            Console.ReadKey();
            return true;
        }

        static public bool UseXPToHeal()
        {
            Console.Clear();
            Console.WriteLine("Zelite li potrositi pola XP-a da obnovite sav HP:");
            var input = StringInput();
            do
            {
                switch (input.ToLower())
                {
                    case "da":
                        return true;
                    case "ne":
                        return false;
                    default:
                        Console.WriteLine("Krivi unos, pokusajte ponovno:");
                        break;
                }
            } while (true);
        }
    }
}
