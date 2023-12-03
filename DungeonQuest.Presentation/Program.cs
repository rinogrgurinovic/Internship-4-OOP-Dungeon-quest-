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
                

            } while (!exit);
            
        }

        static public string StringInput()
        {
            string input;
            do { input = Console.ReadLine(); } while (input.Trim() == "");
            return input;
        }
    }
}
