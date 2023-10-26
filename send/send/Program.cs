using static System.Net.WebRequestMethods;

HttpClient client = new HttpClient();
Console.WriteLine("link");
string re = Console.ReadLine();
Console.WriteLine("slep secend");
int sleep = Convert.ToInt32(Console.ReadLine());
for (; ; )
{
    Console.WriteLine("send");
    var res = await client.GetAsync(re);
    Console.WriteLine(res.StatusCode);
    Console.WriteLine(res.Headers);
    Console.WriteLine(res.TrailingHeaders);
    Console.WriteLine(res.Content.ReadAsStringAsync().Result);
    Thread.Sleep(sleep * 1000);
}