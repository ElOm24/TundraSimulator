using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Predator : Colony
    {
        public Predator(string name, int numOfAnimals) : base(name, numOfAnimals) { }

        public virtual void Offspring(int turn) { }

        public void Perish(int decrease) 
        {
            numOfAnimals = numOfAnimals - decrease;
        }
    }

    public class Owl : Predator
    {
        public Owl(string name, int numOfAnimals) : base(name, numOfAnimals) { }

        public override void Offspring(int turn)
        {
            if(turn % 8 == 0)
            {
                numOfAnimals = numOfAnimals + (numOfAnimals / 4);
            }
        }
    }

    public class Fox : Predator
    {
        public Fox(string name, int numOfAnimals) : base(name, numOfAnimals) { }

        public override void Offspring(int turn)
        {
            if (turn % 8 == 0)
            {
                numOfAnimals = numOfAnimals + (numOfAnimals / 4) * 3;
            }
        }
    }

    public class Wolf : Predator
    {
        public Wolf(string name, int numOfAnimals) : base(name, numOfAnimals) { }

        public override void Offspring(int turn)
        {
            if (turn % 8 == 0)
            {
                numOfAnimals = numOfAnimals + (numOfAnimals / 4) * 2;
            }
        }
    }
}
