using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityGenerator
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            await ArgumentParser.RunWithParsedAsync(args, async parsed =>
            {
                await using var context = new PeopleContext(parsed.GetConnectionString());
                
                //TODO generation stuff
                await context.People.ForEachAsync(Console.WriteLine);
                
            });
        }
    }
}