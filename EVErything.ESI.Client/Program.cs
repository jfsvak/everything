using IdentityModel.Client;
using System;
using System.Threading.Tasks;

namespace EVErything.ESI.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MainAsync().GetAwaiter().GetResult();
            Console.WriteLine("Goodbye World!");
        }

        public static async Task MainAsync()
        {
            Console.WriteLine("Hello ESI!");
            var disco = await DiscoveryClient.GetAsync("https://login.eveonline.com");
            Console.WriteLine("after get!");

            if (disco.IsError) {
                Console.WriteLine("Error!");
                Console.WriteLine(disco.Error);
                return;
            }

            Console.WriteLine(disco);
        }


    }
}
