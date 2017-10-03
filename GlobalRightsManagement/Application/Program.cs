using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecklassRekkids.GlblRightsMgmt.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading Data...");
            //Initialise database
            new BootStrap().Init(args);
            Console.WriteLine("Data is loaded...");

            //Accept input from user untill press quit
            while (true)
            {
                Console.WriteLine("Please enter partner name and product start date you wish to search otherwise enter \"quit\" to exit:");
                var input = Console.ReadLine();
                if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                int lenOfPartnerName = input.IndexOf(" ") + 1;
                string partnerName;


                if (lenOfPartnerName > 1)
                {
                    partnerName = input.Substring(0, lenOfPartnerName-1);
                }
                else
                {
                    Console.WriteLine("Invalid user input, try Again?");
                    continue;
                }

                String startByDate;
                if (lenOfPartnerName < input.Length)
                {
                    startByDate = input.Substring(lenOfPartnerName - 1);
                }
                else
                {
                    Console.WriteLine("Invalid user input, try Again?");
                    continue;
                }

                //Execute the search using given input.
                var output = new BootStrap().Execute(partnerName, startByDate);

                Console.WriteLine(output);
            }
        }

    }
}
