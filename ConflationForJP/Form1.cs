using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConflationForJP
{
    public partial class Form1 : Form
    {
        IDictionary<String, CountdownEvent> countMap = new Dictionary<String, CountdownEvent>();
        Ticker tickerC = new Ticker("C", 48.00);
        Ticker tickerBAC = new Ticker("BAC", 13.00);
        public Form1()
        {
            InitializeComponent();
            CountdownEvent eventForC = new CountdownEvent(1);
            CountdownEvent eventForBAC = new CountdownEvent(1);
            countMap.Add("C", eventForC);
            countMap.Add("BAC", eventForBAC);
        }




        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string PriceForC
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string PriceForBAC
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public void PriceUpdateHandlerForC(object sender, EventArgs e)
        {
            Conflation sender1 = (Conflation)sender;
            // textBox1.Text = System.Convert.ToString(sender1.Price);
            Thread threadC = new Thread(() => this.UpdateC(System.Convert.ToString(sender1.Price)));
            threadC.Start();


        }

        private void UpdateC(string aaa)
        {
            this.SetTextC(aaa);
        }

        private void UpdateBAC(string aaa)
        {
            this.SetTextBAC(aaa);
        }

        public void PriceUpdateHandlerForBAC(object sender, EventArgs e)
        {
            Conflation sender1 = (Conflation)sender;
            //textBox2.Text = System.Convert.ToString(sender1.Price);
            Thread threadBAC = new Thread(() => this.UpdateBAC(System.Convert.ToString(sender1.Price)));
            threadBAC.Start();
        }

        private void SetTextC(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextC);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }

        private void SetTextBAC(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextBAC);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox2.Text = text;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorkerDataFeeder.RunWorkerAsync();
            backgroundWorkerForC.RunWorkerAsync();
            backgroundWorkerForBAC.RunWorkerAsync();

        }

        private void backgroundWorkerForC_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorkerForC_DoWork(object sender, DoWorkEventArgs e)
        {
            CountdownEvent eventForC = countMap[tickerC.Symbol];
            Conflation conflationC = new Conflation(eventForC, tickerC);
            conflationC.priceUpdateEvent += PriceUpdateHandlerForC;
            Thread conflationThreadC = new Thread(conflationC.DoConflation);
            conflationThreadC.Start();
        }

        private void backgroundWorkerForC_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void backgroundWorkerForBAC_DoWork(object sender, DoWorkEventArgs e)
        {
            CountdownEvent eventForBAC = countMap[tickerBAC.Symbol]; ;
            Conflation conflationBAC = new Conflation(eventForBAC, tickerBAC);
            conflationBAC.priceUpdateEvent += PriceUpdateHandlerForBAC;
            Thread conflationThreadBAC = new Thread(conflationBAC.DoConflation);
            conflationThreadBAC.Start();
        }

        private void backgroundWorkerForBAC_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorkerDataFeeder_DoWork(object sender, DoWorkEventArgs e)
        {
            DataFeeder feeder = new DataFeeder(countMap);
            feeder.feederUpdateEvent += FeederUpdateEventHandler;
            feeder.addTicker(tickerC);
            feeder.addTicker(tickerBAC);
            Console.WriteLine("=============================================3333333333 =====================================");
            feeder.startFeeder();
           
        }

        private void FeederUpdateEventHandler(object sender, EventArgs e)
        {
            Ticker t = (Ticker) sender;
            Thread feederThread = new Thread((() => this.UpdateFeederUI(t)));
            feederThread.Start();

        }
        private void UpdateFeederUI(Ticker ticker)
        {
            this.AddtoFeederUI(DateTime.Now.ToShortDateString()+" "+ DateTime.Now.ToLongTimeString() +" "+ DateTime.Now.Millisecond+":: " +ticker.Symbol+" is updated:  "+Convert.ToString(ticker.Update));
        }

        private void AddtoFeederUI(string text)
        {
                    
            if (this.listBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(AddtoFeederUI);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.listBox1.Items.Add(text);
                if (listBox1.Items.Count > 25)
                {
                    listBox1.Items.RemoveAt(0);
                }

            }
        }
    

        private void backgroundWorkerDataFeeder_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorkerDataFeeder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
