using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public class Fokker : Aircraft
    {
        public Fokker(string callSign, IAirTrafficControl atc) : base(callSign, atc)
        {
        }

        public override int Ceiling
        {
            get { return 40000; }
        }
    }
}
