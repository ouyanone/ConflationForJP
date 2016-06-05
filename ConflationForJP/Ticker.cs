using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflationForJP
{
    class Ticker
    {
        String symbol="";
        double update = 0.0;
        public Ticker(String symbol, double update)
        {
            this.symbol = symbol;
            this.update = update;
        }

        public string Symbol
        {
            get
            {
                return symbol;
            }

            set
            {
                symbol = value;
            }
        }

        public double Update
        {
            get
            {

                    return update;
                
            }

            set
            {
 
                    update = value;

            }
        }
    }
}
