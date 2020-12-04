using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommandLine;

namespace EntityGenerator
{
    public class ArgumentParser
    {
        [Option('a', "addr", Default = "localhost",
            HelpText = "Adres serwera bazy danych wraz z portem.")]
        public string Address { get; set; }

        [Option('d', "db", Default = "fakers_db",
            HelpText = "Nazwa bazy danych z w której zostanie przeprowadzona generacja.")]
        public string DatabaseName { get; set; }

        [Option('u', "user", Default = "fakers_u",
            HelpText = "Użytkownik bazy danych przez którego nastąpi połączenie.")]
        public string Username { get; set; }

        [Option('p', "pass", Default = "fakers",
            HelpText = "Hasło użytkownika.")]
        public string Password { get; set; }

        [Option('n', "amount", Default = null,
            HelpText = "Docelowa ilość osób do wygenerowania.")]
        public int? GenerationAmount { get; set; }

        public static Task RunWithParsedAsync(IEnumerable<string> args, Func<ArgumentParser, Task> action)
        {
            return Parser.Default
                .ParseArguments<ArgumentParser>(args)
                .WithParsedAsync(action);
        }

        public string GetConnectionString() =>
            $"Host={Address};Database={DatabaseName};Username={Username};Password={Password}";
    }
}