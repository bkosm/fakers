using System;
using System.Linq;

namespace EntityGenerator
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var context = new PeopleContext();

            foreach (var person in context.People)
            {
                Console.WriteLine(person);
            }
        }
    }
}