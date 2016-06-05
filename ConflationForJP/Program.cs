using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConflationForJP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {



            /*

            IDictionary<String, CountdownEvent> countMap = new Dictionary<String, CountdownEvent>();
            CountdownEvent eventForC = new CountdownEvent(1);
            CountdownEvent eventForBAC = new CountdownEvent(1);
            countMap.Add("C", eventForC);
            countMap.Add("BAC", eventForBAC);
            DataFeeder feeder = new DataFeeder(countMap);
            Ticker tickerC = new Ticker("C", 48.00);
            Ticker tickerBAC = new Ticker("BAC", 13.00);
            feeder.addTicker(tickerC);
            feeder.addTicker(tickerBAC);
            Console.WriteLine("=============================================3333333333 =====================================");
            feeder.startFeeder();

            Conflation conflationC = new Conflation(eventForC, tickerC);
            conflationC.priceUpdateEvent += PriceUpdateHandlerForC;
            Thread conflationThreadC = new Thread(conflationC.DoConflation);
            conflationThreadC.Start();

            Conflation conflationBAC = new Conflation(eventForBAC, tickerBAC);
            conflationBAC.priceUpdateEvent += PriceUpdateHandlerForBAC;
            Thread conflationThreadBAC = new Thread(conflationBAC.DoConflation);
            conflationThreadBAC.Start();
            */


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 stockForm = new Form1();
            Application.Run(stockForm);



        }
    }
}
