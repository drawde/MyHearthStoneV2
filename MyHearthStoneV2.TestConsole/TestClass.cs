using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace MyHearthStoneV2.TestConsole
{
    public class TestClass
    {
        public string name { get; set; }
        int i = 0;
        System.Timers.Timer timer;
        bool flag = true;
        static object mylock = new object();
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Thread.CurrentThread.IsBackground = false;
            lock (mylock)
            {
                if (!flag)
                {
                    return;
                }
                i++;
                Console.WriteLine("Now:" + i.ToString());
                if (i == 80)
                {
                    timer.Stop();
                    flag = false;
                }
            }
            //Thread.Sleep(1000);//同UnSafeTimer
        }
        public void Init()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }
    }
}
