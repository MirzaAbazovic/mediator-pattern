using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public class Boeing : Aircraft
    {
        public Boeing(string callSign, IAirTrafficControl atc)
            : base(callSign, atc)
        {
            
        }


        public override int Ceiling
        {
            get { return 33000; }
        }
    }

}
