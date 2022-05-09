using log4net;

namespace Monitor
{
    public class WebMonitoring : IDisposable  
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(WebMonitoring));
        public TimeSpan CheckInterval { get; set; }
        public string? Site { get; set; }
        public string? Title { get; set; }
        public string? Email { get; set; }
        public HttpClient Client { get; set; } = new HttpClient();

        public WebMonitoring(string checkInterval, string responseTime, string site, string email, string title)
        {
            CheckInterval = TimeSpan.Parse(checkInterval);
            Site = site;
            Email = email;
            Title = title;

            Client.Timeout = TimeSpan.Parse(responseTime);
        }

        public async Task OnTimedEvent()
        {
            try
            {
                HttpResponseMessage response = await Client.GetAsync(Site);

                if (response.IsSuccessStatusCode)
                {
                    log.Error(Title);
                }
            }
            catch (TaskCanceledException)
            {
                await SendEmail();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public async Task SendEmail()
        {
            await Mail.SendMessage(Email);
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}