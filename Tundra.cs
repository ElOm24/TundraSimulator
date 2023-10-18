using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace ConsoleApp1
{
    public class Tundra
    {
        Random rnd = new Random();

        private int numberOfPrey;
        private int numberOfPredator;

        private List<(Predator, int)> predatorColonies = new List<(Predator, int)>(); //strategy
        private List<(Prey, int)> preyColonies = new List<(Prey, int)>();

        public Tundra() {
            string textTundra = "./textTundra.txt";
            //string textTundra = "./sampleInput2.txt";

            Read(textTundra);
        }

        public Tundra(string textTundra)
        {
            Read(textTundra);
        }

        public void Read(string textTundra)
        {
            predatorColonies = new List<(Predator, int)>();
            preyColonies = new List<(Prey, int)>();

            TextFileReader lineReader = new TextFileReader(textTundra);
            string[] line = lineReader.ReadLine()!.Split(" ");

            numberOfPrey = int.Parse(line[0]);
            numberOfPredator = int.Parse(line[1]);

            for (int i = 0; i < numberOfPrey + numberOfPredator; i++)
            {
                line = lineReader.ReadLine()!.Split(" ");

                string name = line[0];
                string speciesLetter = line[1];

                int startNumber = int.Parse(line[2]); //"45" to 45

                switch (speciesLetter)
                {
                    case "l":
                        preyColonies.Add((new Lemming(name, startNumber), startNumber));
                        break;

                    case "h":
                        preyColonies.Add((new Hare(name, startNumber), startNumber));
                        break;

                    case "g":
                        preyColonies.Add((new Gopher(name, startNumber), startNumber));
                        break;

                    case "o":
                        predatorColonies.Add((new Owl(name, startNumber), startNumber));
                        break;

                    case "f":
                        predatorColonies.Add((new Fox(name, startNumber), startNumber));
                        break;

                    case "w":
                        predatorColonies.Add((new Wolf(name, startNumber), startNumber));
                        break;

                    default:
                        throw new Exception("the following species does not exist.");
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("Preys: ");
            for (int i = 0; i < preyColonies.Count; i++)
            {
                Console.WriteLine(preyColonies[i].Item1);
            }
            Console.WriteLine(" --------- ");


            Console.WriteLine("Predators: ");
            for (int i = 0; i < predatorColonies.Count; i++)
            {
                Console.WriteLine(predatorColonies[i].Item1);
            }
            Console.WriteLine(" --------- ");
        }


        private bool CheckPredators()
        {
            int totalPredatorsInitial = 0, totalPredatorsNow = 0;

            bool is_okay = true;

            foreach((Colony, int) x in predatorColonies)
            {
                int numOfPredator = x.Item1.GetNumberOfAnimals();
                is_okay = is_okay && numOfPredator < 4; // if each of them satify the condition

                totalPredatorsInitial += x.Item2;
                totalPredatorsNow += numOfPredator;
            }

            if (is_okay || totalPredatorsNow >= 2*totalPredatorsInitial)
            {
                return false;
            }
            return true;
        }

        public int GetRandom(int x)
        {
            rnd = new Random();
            return rnd.Next(0, x);
        }

        public void Simulate()
        {
            int turn = 1;
            int indexRandomPrey, indexRandomPredator;

            while (CheckPredators())
            {
                indexRandomPrey = GetRandom(preyColonies.Count());
                indexRandomPredator = GetRandom(predatorColonies.Count());

                if (preyColonies[indexRandomPrey].Item1.IsNumZero())
                {
                    continue;
                }
                    

                Console.WriteLine("-------- Turn " + turn + " -----------");
                Print();
                
                preyColonies[indexRandomPrey].Item1.ByTurn(turn);
                predatorColonies[indexRandomPredator].Item1.Offspring(turn);

                preyColonies[indexRandomPrey].Item1.BeingAttacked(predatorColonies[indexRandomPredator].Item1);


                Console.WriteLine(indexRandomPredator + " and " + indexRandomPrey);

                turn++;
                if (turn > 1000)
                {
                    break;
                }
                Console.WriteLine();

            }

            Console.WriteLine("-------- Turn " + turn + " -----------");
            Print();
        }
    }
}
