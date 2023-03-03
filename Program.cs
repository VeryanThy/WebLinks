
using System;
using System.Diagnostics;

namespace WebLinks
{
    internal class Program
    {
        static List<Link> nyheter = new List<Link>();
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
            PrintWelcome();
            string command;
            LoadFile();
            do
            {
                Console.Write("Command: ");
                command = Console.ReadLine();
                Console.Clear();
                if (command == "quit")
                {
                    string Ans;
                    Console.WriteLine("Do you want to save before quiting? Press Y for yes");
                    Ans = Console.ReadLine();
                    if (Ans == "Y")
                    {
                        SaveToFile($"{Environment.GetEnvironmentVariable("USERPROFILE")}\\source\\repos\\WebLinks\\Nyheter.txt");
                    }
                    else Console.WriteLine("Thank you and have a nice day.");

                }
                else if (command == "help")
                {
                    WriteTheHelp();
                }
                else if (command == "load")
                {
                    LoadFile();
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
                    AddLink();
                }
                else if (command == "save")
                {
                    SaveToFile();
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
            Console.WriteLine("Welcome to the AWESOME NEWS-PROGRAM!");
            Console.WriteLine("We bring you to the news.\n");
            Console.WriteLine("Write 'help' for help!\n");
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
        public static void LoadFile()
        {
            using (StreamReader sr = new StreamReader($"{Environment.GetEnvironmentVariable("USERPROFILE")}\\source\\repos\\WebLinks\\Nyheter.txt"))
            {
                string ln;

                while ((ln = sr.ReadLine()) != null)
                {
                    string[] line = ln.Split(",");
                    string name = line[0];
                    string description = line[1];
                    string url = line[2];
                    nyheter.Add(new Link(line[0], line[1], line[2]));
                }
            }
        }
        public static void SaveToFile(string filename = "temp")
        {
            if (filename == "temp") filename = ($"{Environment.GetEnvironmentVariable("USERPROFILE")}\\source\\repos\\WebLinks\\Nyheter.txt");
            
            // Eventeull fix för att tömma fil
            // File.WriteAllText(filename, String.Empty);
            using (StreamWriter sw = new StreamWriter(filename))
            {
                nyheter.ForEach(link => sw.WriteLine($"{link.Name}," +
                    $"{link.Description}," +
                    $"{link.Url}"));
            }
        }
       public static void AddLink()
      {
          Console.Write("Link name: ");
          string name = Console.ReadLine();
          Console.Write("Describe the link: ");
          string description = Console.ReadLine();
          Console.Write("Link URL: ");
          string url = Console.ReadLine();
          nyheter.Add(new Link(name, description, url));
       }
        public static List<>
    }
}


