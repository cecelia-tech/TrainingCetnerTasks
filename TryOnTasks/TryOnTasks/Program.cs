// See https://aka.ms/new-console-template for more information
using TryOnTasks;

Console.WriteLine("Hello, World!");
//HttpClient client;
//HttpResponseMessage response;

//for (int i = 0; i < 30; i++)
//{
//    var client = new HttpClient();

//    var response = await client.GetAsync("https://www.bbc.com/");

//    //Console.WriteLine(response.StatusCode);
//}

Monitoring m = new Monitoring();

m.SetTimer();
Console.ReadKey();