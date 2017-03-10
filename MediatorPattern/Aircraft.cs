using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public abstract class Aircraft
    {
        private readonly IAirTrafficControl _atc;
        private int _currentAltitude;

        public Aircraft(string callSign, IAirTrafficControl atc)
        {
            _atc = atc;
            CallSign = callSign;
            Console.WriteLine("Creating Aircraft  => {0}\n",this.ToString());
            _atc.RegisterAircraftUnderGuidance(this);
          
        }

        public abstract int Ceiling { get; }

        public string CallSign { get; private set; }

        public int Altitude
        {
            get { return _currentAltitude; }
            set
            {
               // Console.WriteLine("AIRPLANE {0} SET ALTITUDE TO NEW ALTITUDE {1}\n", this.ToString(),value);
                _currentAltitude = value;
                _atc.ReceiveAircraftLocation(this);
            }
        }

        public void Climb(int heightToClimb)
        {
            Console.WriteLine("AIRPLANE [{0}] Climbing to {1} => NEW ALTITUDE {2}", this.ToString(), heightToClimb, Altitude += heightToClimb);
            Altitude += heightToClimb;
           
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            var incoming = (Aircraft)obj;
            return this.CallSign.Equals(incoming.CallSign);
        }

        public override int GetHashCode()
        {
            return CallSign.GetHashCode();
        }


        public override string ToString()
        {
            //return String.Format("Aircraft type {0} CallSign {1} Ceiling {2} Altitude {3}", this.GetType().ToString(), CallSign, Ceiling, Altitude);
            return String.Format("Aircraft {0} Altitude {1}",  CallSign, Altitude);
        }

        public void WarnOfAirspaceIntrusionBy(Aircraft reportingAircraft)
        {
            Console.WriteLine("I'm [{0}]  HAVE SPACE INTRUSION BY [{1}]\n", this.ToString(), reportingAircraft.ToString());
            //do something in response to the warning
        }
    }
}
