using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Configuration;
using log4net;
using System.Xml.Linq;

namespace Monitor
{
    public class WebMonitoring
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(WebMonitoring));
        public TimeSpan CheckInterval { get; set; }
        public TimeSpan ResponseTime { get; set; }
        public string? Site { get; set; }
        public string? Title { get; set; }
        public string? Email { get; set; }
        public HttpClient? Client { get; set; }


        public WebMonitoring(string checkInterval, string responseTime, string site, string email, string title)
        {
            CheckInterval = TimeSpan.Parse(checkInterval);
            ResponseTime = TimeSpan.Parse(responseTime);
            Site = site;
            Email = email;
            Title = title;
        }

        public async Task OnTimedEvent()
        {
            try
            {
                Client = new HttpClient();

                Client.Timeout = TimeSpan.FromSeconds(2);

                HttpResponseMessage response = new HttpResponseMessage();

                response = await Client.GetAsync(Site);

                if (response.IsSuccessStatusCode)
                {
                    log.Error(Title);
                }
            }
            catch (TaskCanceledException)
            {
                await SendEmail();
            }
            finally
            {
                Client?.Dispose();
            }
        }

        //public async Task CheckStatus(bool webResponse)
        //{
        //    if (webResponse)
        //    {
        //        log.Error(Title);
        //    }
        //    else
        //    {
        //        await SendEmail();
        //    }
        //}

        public async Task SendEmail()
        {
           // await Mail.SendMessage();
            await Task.Delay(100);
            Console.WriteLine("we are on the SendEmail");
            Console.WriteLine(Title);
        }

    }
}