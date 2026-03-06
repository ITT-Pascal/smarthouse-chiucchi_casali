using static System.Console;
class program
{
    static void Main()
    {
        ILampRepository repository = new InMemoryLampRepository();
        ILampRepository repositorytxt = new TxtLampRepository();
        LampController controller = new LampController(repository);

        bool exit = false;

        while (!exit)
        {
            Clear();
            controller.ShowLamps();
            ShowMenu();

            Write("Choose an option: ");
            string choice = ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1"
                    controller.Add
            }
        }
    }
}