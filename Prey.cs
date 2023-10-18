using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Prey : Colony 
    {
        public Prey(string name, int numOfAnimals) : base(name, numOfAnimals) { }

        public virtual void ByTurn(int turn) { }

        public virtual void BeingAttacked(Predator predator) { }

        public bool IsNumZero()
        {
            return numOfAnimals == 0; //yes no
        }
    }

    public class Lemming : Prey
    {
        public Lemming(string name, int numOfAnimals) : base(name, numOfAnimals) { }

        public override void BeingAttacked(Predator predator) 
        {
            int new_value = numOfAnimals - (4 * predator.GetNumberOfAnimals());
            //prey: 20, predator: 4
            //new_value = 4
            //if 16>=0 --> prey = 4

            //prey: 4, predator: 4
            //new_value= 4 - (16) = -12
            //if -12>=0 --> predator.Perish(4/4)
            //decrease = 1, predators = 3 

            if (new_value >= 0)  {
                numOfAnimals = new_value;
            } else  {
                predator.Perish(numOfAnimals / 4);
            }
        }

        public override void ByTurn(int turn)
        {
            if (turn % 2 == 0)
            {
                numOfAnimals *= 2;
            }

            if (numOfAnimals > 200)
            {
                numOfAnimals = 30;
            }
        }
    }

    public class Hare : Prey
    {
        public Hare(string name, int numOfAnimals) : base(name, numOfAnimals) { }

        public override void BeingAttacked(Predator predator)
        {
            int new_value = numOfAnimals - (2 * predator.GetNumberOfAnimals());

            if (new_value >= 0)
            {
                numOfAnimals = new_value;
            }
            else
            {
                predator.Perish(numOfAnimals / 2);
            }
        }
        public override void ByTurn(int turn)
        {
            if (turn % 2 == 0)
            {
                numOfAnimals = numOfAnimals + (numOfAnimals / 2);
            }

            if (numOfAnimals > 100)
            {
                numOfAnimals = 20;
            }
        }
    }

    public class Gopher : Prey
    {
        public Gopher(string name, int numOfAnimals) : base(name, numOfAnimals) { }

        public override void BeingAttacked(Predator predator)
        {
            int new_value = numOfAnimals - (2 * predator.GetNumberOfAnimals());

            if (new_value >= 0)
            {
                numOfAnimals = new_value;
            }

            else
            {
                predator.Perish(numOfAnimals / 2);
            }
        }

        public override void ByTurn(int turn)
        {
            if (turn % 4 == 0)
            {
                numOfAnimals *= 2;
            }

            if (numOfAnimals > 200)
            {
                numOfAnimals = 40;
            }
        }
    }
}
