using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
    class Program
    {
        static void Main()
        {
            List<Language> languages = File.ReadAllLines("./languages.tsv")
                .Skip(1)
                .Select(line => Language.FromTsv(line))
                .ToList();

            // Task 1
            PrettyPrintAll(languages);

            // Task 2
            var summaries = languages.Select(lang => $"{lang.Year}: {lang.Name} by {lang.ChiefDeveloper}");
            PrintAll(summaries);

            // Task 3
            var csharpLanguages = languages.Where(lang => lang.Name == "C#");
            PrettyPrintAll(csharpLanguages);

            // Task 4
            var microsoftLanguages = languages.Where(lang => lang.ChiefDeveloper.Contains("Microsoft"));
            PrettyPrintAll(microsoftLanguages);

            // Task 5
            var lispDescendants = languages.Where(lang => lang.Predecessors.Contains("Lisp"));
            PrettyPrintAll(lispDescendants);

            // Task 6
            var scriptNames = languages.Where(lang => lang.Name.Contains("Script")).Select(lang => lang.Name);
            PrintAll(scriptNames);

            // Task 7
            Console.WriteLine($"Total languages: {languages.Count()}");

            // Task 8
            int millenniumCount = languages.Count(lang => lang.Year >= 1995 && lang.Year <= 2005);
            Console.WriteLine($"Languages from 1995-2005: {millenniumCount}");

            // Task 9
            var millenniumStrings = languages
                .Where(lang => lang.Year >= 1995 && lang.Year <= 2005)
                .Select(lang => $"{lang.Name} was invented in {lang.Year}");
            PrintAll(millenniumStrings);
        }

        static void PrettyPrintAll(IEnumerable<Language> langs)
        {
            foreach (Language lang in langs)
            {
                Console.WriteLine(lang.Prettify());
            }
        }

        static void PrintAll(IEnumerable<object> items)
        {
            foreach (object item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}