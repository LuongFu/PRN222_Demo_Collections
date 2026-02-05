using System;
using System.Net.Http;
using System.Threading.Tasks;
class Program
{
    static readonly HttpClient client = new HttpClient();
    static async Task Main()
    {
    string uri = "http://www.contoso.com/";
    try
    {
        HttpResponseMessage response = await client.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseBody);
        }
        catch (HttpRequestException e) {
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);

        }
    }
}