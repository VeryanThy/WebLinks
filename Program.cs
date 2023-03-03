
using System;
using System.Diagnostics;

namespace WebLinks
{
    internal class Program
    {
       
        class Link
        {
            private string name;
            private string url;
            private string description;
            public Link(string name, string desc, string url)
            {
                this.name = name;
                this.url = url;
                this.description = desc;
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string Url
            {
                get { return url; }
                set { url = value; }
            }
            public string Description
            {
                get { return description; }
                set { description = value; }
            }
        }

        static void Main(string[] args)
        {
            List<Link> nyheter = new List<Link>();
            LoadFile($"{Environment.GetEnvironmentVariable("USERPROFILE")}\\source\\repos\\WebLinks\\Nyheter.txt", nyheter);
            PrintWelcome();
            string command;           
            do
            {
                Console.Write(": ");
                command = Console.ReadLine();
                if (command == "quit")
                {
                    Console.WriteLine("Thank you and have a nice day.");

                    SaveToFile($"{Environment.GetEnvironmentVariable("USERPROFILE")}\\source\\repos\\WebLinks\\Nyheter.txt");

                }
                else if (command == "help")
                {
                    WriteTheHelp();
                }
                else if (command == "load")
                {
                    Console.Write("Enter the full path to the file you want to load: ");
                    string path = Console.ReadLine();
                    Console.Write("Name the file: ");
                    string name = Console.ReadLine();
                    List<Link> filename = new List<Link>();
                    LoadFile(path, filename);
                }
                else if (command == "list")
                {
                    PrintContents(nyheter);
                }
                else if (command == "open")
                {
                    Open(nyheter);
                }
                else if (command == "add")
                {
                    Console.Write("Choose which file to add to: ");
                    string filename = Console.ReadLine();
                    AddLink(filename);
                } else if (command == "save")
                {
                    Console.Write("Choose which file to save to: ");
                    string filename = Console.ReadLine();
                    SaveToFile(filename);
                }
                else
                {
                    Console.WriteLine($"Unknown command '{command}'");
                }
            } while (command != "quit");
        }
        private static void NotYetImplemented(string command)
        {
            Console.WriteLine($"Sorry: '{command}' is not yet implemented");
        }
        private static void PrintWelcome()
        {
            Console.WriteLine("Hello and welcome to the AWESOME NEWS-PROGRAM");
            Console.WriteLine("that brings you to the news.");
            Console.WriteLine("Write 'help' for help!");
        }
        private static void Open(List<Link> nyheter)
        {
            string openName;

            Console.Write("Name of link you want to open: ");
            openName = Console.ReadLine();
            foreach (Link link in nyheter)
            {
                if (link.Name.Contains(openName, StringComparison.InvariantCultureIgnoreCase))
                {
                    Process.Start(new ProcessStartInfo { FileName = link.Url, UseShellExecute = true });
                }
            }
        }
        private static void PrintContents(List<Link> links)
        {
            foreach (Link element in links)
            {
                Console.WriteLine($"{element.Name} : {element.Description} : {element.Url}");
            }
        }      
        private static void WriteTheHelp()
        {
            string[] hstr = {
                "help  - display this help",
                "load  - load all links from a file",
                "open  - open a specific link",
                "quit  - quit the program",
                "add   - add link to list",
                "list  - list available links",
                "save  - save your links to file"
            };
            foreach (string h in hstr) Console.WriteLine(h);
        }
        private static void LoadFile(string filepath, List<Link> filename)
        {
            using (StreamReader sr = new StreamReader(filepath))
            {
                string ln;

                while ((ln = sr.ReadLine()) != null)
                {
                    string[] line = ln.Split(",");
                    string name = line[0];
                    string description = line[1];
                    string url = line[2];
                    filename.Add(new Link(line[0], line[1], line[2]));
                }
            }
        }
        private static void SaveToFile(string filename = "temp", List<Link> listname)
        {

            if (filename=="temp") filename = ($"{Environment.GetEnvironmentVariable("USERPROFILE")}\\source\\repos\\WebLinks\\Nyheter.txt");
            
            // Eventeull fix för att tömma fil
            // File.WriteAllText(filename, String.Empty);
            using (StreamWriter sw = new StreamWriter(filename))
            {
                listname.ForEach(link => sw.WriteLine($"{link.Name}," +
                    $"{link.Description}," +
                    $"{link.Url}"));
            }
        }
       private static void AddLink(List<Link> filename)
      {
          Console.Write("Link name: ");
          string name = Console.ReadLine();
          Console.Write("Describe the link: ");
          string description = Console.ReadLine();
          Console.Write("Link URL: ");
          string url = Console.ReadLine();
          filename.Add(new Link(name, description, url));
       }
    }
}


