using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TryOnTasks
{
    internal class Monitoring
    {
        public System.Timers.Timer? aTimer { get; set; }
        HttpClient? client;

        internal void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(500);

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += async (obj, e) => await OnTimedEvent();
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            //aTimer.Start();
            GC.KeepAlive(aTimer);
        }

        private async Task OnTimedEvent()
        {
            client = new HttpClient();

            var response = await client.GetAsync("https://www.bbc.co.uk");
            Console.WriteLine(response.StatusCode);
        }
    }
}
