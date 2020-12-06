using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeneratorsClass;
using ExternalAPI;
using System.Threading;

namespace EntityGenerator
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            await ArgumentParser.RunWithParsedAsync(args, async parsed =>
            {
                await using var context = new PeopleContext(parsed.GetConnectionString());
                var amount = parsed.GenerationAmount;

                Generator.Generate(context, 100);
            });

           
        }
    }
}