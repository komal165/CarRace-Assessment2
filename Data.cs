using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace
{
    //coding for abstract class
    abstract class Data
    {
        public static Car[] Cars = new Car[5];
        public static Bettor[] Bidders = new Bettor[3];
        public static Random rand = new Random();
        public static int CurrentGambler { get; set; }
    }
}
