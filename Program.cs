
namespace WebLinks
{
    internal class Program
    {

        class Link
        {
            private string name;
            private string url;
            private string description;
            private int fileId;

            public Link(string name, string url, string desc, int fileId) {
                this.name = name;
                this.url = url;
                this.description = desc;
                this.fileId = fileId;
            }
            
            public string Name {
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
       

        public static void Open()
        {
            string openName;

            Console.Write("Name of link you want to open: ");
            openName = Console.ReadLine();
            foreach (Link in Nyheter)
            {
                if (Link.name.Contains(openName))
                {
                    System.Diagnostics.Process.Start(Link.url);
                }
            }
        }

        public static void PrintContents() 
        {
            foreach (string element in lista) 
            {
                Console.WriteLine($"{komplett lista}{}{}");
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
                    Open();
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


        public static void LoadFile()
        {
            List <Link> Nyheter = new List<Link>();
            using (StreamReader sr = new StreamReader("Nyheter.txt")) {
                int counter = 0;
                string ln;

                while ((ln = sr.ReadLine()) != null)
                {
                    string[] line = ln.Split(", ");
                    string name = line[0];
                    string description= line[1];
                    string url= line[2];                 
                    Nyheter.Add(new Link(line[0], line[1], line[2], counter));
                    counter++;
                }
            }
        }
       

    }
}