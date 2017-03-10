using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IAirTrafficControl tower = new Tower();

            Aircraft flight1 = new Airbus("AC159", tower);
            Aircraft flight2 = new Boeing("WS203", tower);
            Aircraft flight3 = new Fokker("AC602", tower);
            tower.ShowAircraftsPositions();
            flight1.Altitude += 1010;
            tower.ShowAircraftsPositions();
            flight2.Altitude += 1420;
            tower.ShowAircraftsPositions();
            flight3.Altitude += 2630;
            tower.ShowAircraftsPositions();
            Console.ReadKey();

        }
    }
}
