using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutrientDiary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Adding try catch for exception handling
            try
            {
               //Todo- do we need to check if the argument is null?
                    CreateHostBuilder(args).Build().Run();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
