using System;
using System.Threading.Tasks;

namespace AadInformation
{
    class Program
    {
        static async Task Main()
        {
            var aad = new AzureActiveDirectory();
            await aad.MakeUserRequest();
            Console.ReadLine();
        }
    }
}
