using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConflationForJP
{
    class DataFeeder
    {
        private IList<Ticker> tickerList = new List<Ticker>();
        private IDictionary<String, CountdownEvent> countMap = new Dictionary<String, CountdownEvent>();
        public event EventHandler feederUpdateEvent;

        public DataFeeder(IDictionary<String, CountdownEvent> map)
        {
            this.countMap = map;
        }

        public void addTicker(Ticker ticker)
        {
            tickerList.Add(ticker);
        }

        public void startFeeder()
        {
            Object feederLocker = new object();
            foreach (Ticker ticker in  tickerList)
            {
                new Thread(() => feedTicker(ticker, feederLocker)).Start();
            }
        }

        private void feedTicker(Ticker ticker, Object feederLock)
        {
            sendTickerUpdate(ticker, 0, ticker.Update, feederLock);
            Random random;
            if (ticker.Symbol.Equals("C"))
            {
                random = new Random(Environment.TickCount);
            } else
            {
                random = new Random(Environment.TickCount/4);
            }
            
           
            while (true)
            {
                // random interval to send the stock price update
                int interval = random.Next(1, 100);
                //int interval = random.Next(2000, 5000);
                // random price change of the stock between -.05 to .05
                double priceChange = (random.NextDouble() - 0.50) / 10;
                sendTickerUpdate(ticker, interval, priceChange, feederLock);
            }
        }

        private void sendTickerUpdate(Ticker ticker, int interval, double change, object feederLock)
        {
            if (interval > 0)
            {
                lock(feederLock)
                {
                    Monitor.Wait(feederLock, interval);
                }
            }

            //Console.WriteLine(DateTime.Now.ToLongTimeString()+":"+DateTime.Now.Millisecond+"::"+ticker.Symbol+ "-------------sending after "+interval+"ms change "+change);

            if (change != 0.00)
            {
                lock(ticker)
                {
                    ticker.Update = change;
                    Ticker t = new Ticker(ticker.Symbol, ticker.Update);
                    feederUpdateEvent?.Invoke(t, EventArgs.Empty);
                    Monitor.PulseAll(ticker);

                }
            }

            if (interval == 0)
            {
                CountdownEvent countdown = countMap[ticker.Symbol];
                countdown.Signal();

            }

        }






    }
}
