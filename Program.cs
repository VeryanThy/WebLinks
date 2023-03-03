
namespace WebLinks
{
    internal class Program
    {

        class Link
        {
            private string name;
            private string url;
            private string description;

            public Link(string name, string url, string desc)
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


        public static void PrintContents()
        {
            foreach (Link element in Nyheter)
            {
                Console.WriteLine($"{name} | {description} | {url}");
            }
        }

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
                    Console.WriteLine("Good bye!");
                }
                else if (command == "help")
                {
                    WriteTheHelp();
                }
                else if (command == "load")
                {
                    NotYetImplemented(command);
                }
                else if (command == "open")
                {
                    NotYetImplemented(command);
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
            Console.WriteLine("Hello and welcome to the ... program ...");
            Console.WriteLine("that does ... something.");
            Console.WriteLine("Write 'help' for help!");
        }

        private static void WriteTheHelp()
        {
            string[] hstr = {
                "help  - display this help",
                "load  - load all links from a file",
                "open  - open a specific link",
                "quit  - quit the program"
            };
            foreach (string h in hstr) Console.WriteLine(h);
        }

        static List<Link> Nyheter = new List<Link>();

        public static void LoadFile()
        {
            using (StreamReader sr = new StreamReader("Nyheter.txt"))
            {
                int counter = 0;
                string ln;

                while ((ln = sr.ReadLine()) != null)
                {
                    string[] line = ln.Split(", ");
                    string name = line[0];
                    string description = line[1];
                    string url = line[2];
                    Nyheter.Add(new Link(line[0], line[1], line[2]));
                    counter++;
                }
            }
        }


        public static void SaveToFile(string filename = "Nyheter.txt")
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {

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
            Nyheter.Add(new Link(name, description, url));

        }
    }
}