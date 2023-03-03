
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
            private int fileId;

            public Link(string name, string url, string desc, int fileId)
            {
                this.name = name;
                this.url = url;
                this.description = desc;
                this.fileId = fileId;
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

            public int FileId
            {
                get { return fileId; }
                set { fileId = value; }
            }
        }


       

        static List<Link> currentList = new List<Link>();
        static void Main(string[] args)
        {
            PrintWelcome();
            string command;
            do
            {
                Console.Write(": ");
                command = Console.ReadLine();
                if (command == "quit")
                {
                    Console.WriteLine("Thank you and have a nice day.");
                }
                else if (command == "help")
                {
                    WriteTheHelp();
                }
                else if (command == "load")
                {
                    LoadFile();
                }
                else if (command == "open")
                {
                    Open(currentList);
                }
                else if (command == "add")
                {
                    AddLink();
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
                    System.Diagnostics.Process.Start(link.Url);
                }
            }
        }

        private static void PrintContents(List<Link> links)
        {
            foreach (Link element in links)
            {
                Console.WriteLine($"{element.Name}: {element.Url}");
            }
        }
        private static void WriteTheHelp()
        {
            string[] hstr = {
                "help  - display this help",
                "load  - load all links from a file",
                "open  - open a specific link",
                "quit  - quit the program",
                "add   - add link to list"
            };
            foreach (string h in hstr) Console.WriteLine(h);
        }
        public static void LoadFile()
        {
            using (StreamReader sr = new StreamReader($"{Environment.GetEnvironmentVariable("USERPROFILE")}\\source\\repos\\WebLinks\\Nyheter.txt"))
            {
                int counter = 0;
                string ln;

                while ((ln = sr.ReadLine()) != null)
                {
                    string[] line = ln.Split(",");
                    string name = line[0];
                    string description = line[1];
                    string url = line[2];
                    nyheter.Add(new Link(line[0], line[1], line[2], counter));
                    counter++;
                }
            }
        }


        public static void SaveToFile(string filename = "Nyheter.txt")
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                nyheter.ForEach(link => sw.WriteLine($"{link.Name}," +
                    $"{link.Url}," +
                    $"{link.Description}"));
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
    }
}

