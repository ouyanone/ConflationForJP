using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConflationForJP
{
    class Conflation
    {
        private static int CONFLATION_THRESHOLD_IN_MS = 2000;
        private int timeout = CONFLATION_THRESHOLD_IN_MS;
        private Ticker ticker;
       // private long startTime = 0;
        private double price = 0.00;
        private CountdownEvent countdown;

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public event EventHandler priceUpdateEvent;


        public Conflation(CountdownEvent c, Ticker t)
        {
            this.countdown = c;
            this.ticker = t;
        }

        public void DoConflation()
        {
            countdown.Wait();
            Price = ticker.Update;

            DateTime startTime = DateTime.Now;
            while (true)
            {
                lock(ticker)
                {
                    ticker.Update = 0.00;
                    if (timeout< CONFLATION_THRESHOLD_IN_MS)
                    {
                        Monitor.Wait(ticker, timeout);
                    } else
                    {
                        Monitor.Wait(ticker);
                    }

                    if (ticker.Update !=0.00)
                    {
                        Console.WriteLine("***********************************"+ticker.Symbol + " received update :"+ticker.Update);
                    }
                    DateTime currentTime = DateTime.Now;
                    double ms = currentTime.Subtract(startTime).TotalMilliseconds;
                    int timePassed = Convert.ToInt32(ms);
                    Price += ticker.Update;
                    if (timePassed>= CONFLATION_THRESHOLD_IN_MS)
                    {
                        Console.WriteLine(DateTime.Now.ToLongTimeString() + "^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^" + ticker.Symbol + " Latest pricme:" + price);
                        if (priceUpdateEvent !=  null)
                        {
                            Console.WriteLine(DateTime.Now.ToLongTimeString() + "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@" + ticker.Symbol + " Latest pricme:" + price);
                            priceUpdateEvent(this, DateBoldEventArgs.Empty);
                        }
                          
                        startTime = DateTime.Now;
                        timeout = CONFLATION_THRESHOLD_IN_MS;

                    } else
                    {
                        timeout = CONFLATION_THRESHOLD_IN_MS - timePassed;
                    }

                }
            }



        }

    }
}
