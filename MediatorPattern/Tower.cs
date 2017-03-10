using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public class Tower : IAirTrafficControl
    {
        private readonly IList<Aircraft> _aircraftUnderGuidance = new List<Aircraft>();

        public void ShowAircraftsPositions()
        {
            int i = 1;
            Console.WriteLine("TOWER: Reporting ");
            foreach (Aircraft aircraftUnderGuidance in _aircraftUnderGuidance)
            {
               
                Console.WriteLine("{0}. [{1}]",i++, aircraftUnderGuidance.ToString());
            }
        }

        public void ReceiveAircraftLocation(Aircraft reportingAircraft)
        {
            //Console.WriteLine("TOWER ReceiveAircraftLocation reportingAircraft => " + reportingAircraft.ToString());

            foreach (Aircraft currentAircraftUnderGuidance in _aircraftUnderGuidance.
                Where(x => x != reportingAircraft))
            {
                if (Math.Abs(currentAircraftUnderGuidance.Altitude - reportingAircraft.Altitude) < 1000)
                {
                    Console.WriteLine("TOWER:  REPORTING AIRCRAFT [{0}] AND Aircraft Under Guidance [{1}] SPACE INTRUSION RPORTING TO AIRCRAFT [{0}] PLEASE CLIMB 1000 !!!",reportingAircraft.ToString(), currentAircraftUnderGuidance.ToString());
                    reportingAircraft.Climb(1000);
                    //communicate to the class
                    Console.WriteLine("TOWER:  WARNING TO AIRCRAFT [{0}]  OS SPACE INTRUSION", reportingAircraft.ToString());
                    currentAircraftUnderGuidance.WarnOfAirspaceIntrusionBy(reportingAircraft);
                }
            }
        }

        public void RegisterAircraftUnderGuidance(Aircraft aircraft)
        {
            if (!_aircraftUnderGuidance.Contains(aircraft))
            {
                Console.WriteLine("TOWER: registering Aircraft {0} \n",aircraft.ToString());
                _aircraftUnderGuidance.Add(aircraft);
            }
        }
    }
}
