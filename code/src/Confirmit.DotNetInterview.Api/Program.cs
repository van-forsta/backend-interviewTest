//==== DO NOT MODIFY THIS FILE ====
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Confirmit.DotNetInterview.Api
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                Host
                    .CreateDefaultBuilder(args)
                    .Build()
                    .Run();
                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
        }
    }
}
