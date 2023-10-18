using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public abstract class Colony
    {
        protected string name { get; set; }

        protected int numOfAnimals { get; set; }

        public string GetName()
        {
            return name;
        }

        public int GetNumberOfAnimals()
        {
            return numOfAnimals;
        }

        public Colony(string name, int numOfAnimals)
        {
            this.name = name;
            this.numOfAnimals = numOfAnimals;
        }

        public override string ToString()
        {
            return this.name + " : " + this.numOfAnimals;
        }
    }
}
