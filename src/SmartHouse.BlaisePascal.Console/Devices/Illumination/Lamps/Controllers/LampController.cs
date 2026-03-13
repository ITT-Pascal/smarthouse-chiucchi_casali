using SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Commands;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Queries;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Repositories;
using static System.Console;
namespace SmartHouse.BlaisePascal.Console.Devices.Illumination.Lamps.Controllers
{
    public class LampController
    {
        private readonly ILampRepository _repository;

        public LampController(ILampRepository repos)
        {
            _repository = repos;
        }

        public void AddLamp()
        {
            Write("Insert lamp name: ");
            string? name = ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                WriteLine("Inserted name is invalid.");
                return;
            }
            new AddLampCommand(_repository).Execute(name);
            WriteLine("Lamp added succesfully!");
        }

        public void RemoveLamp()
        {
            string? lamp = SelectLamp();
            if (string.IsNullOrWhiteSpace(lamp))
                return;
            Guid id = new Guid(lamp);
            try
            {
                new RemoveLampCommand(_repository).Execute(id);
                WriteLine("Lamp removed succesfully!");
            }
            catch (ArgumentException ex)
            {
                WriteLine($"ERROR: {ex.Message}");
            }
        }

        public void SwitchOn()
        {
            string? lamp = SelectLamp();
            if (string.IsNullOrWhiteSpace(lamp))
                return;
            Guid id = new Guid(lamp);
            try
            {
                if (new LampCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected lamp is alredy on.");
                else
                {
                    new SwitchOnLampCommand(_repository).Execute(id);
                    WriteLine("Selected lamp switched on succesfully!");
                }
            }
            catch (ArgumentException ex)
            {
                WriteLine($"ERROR: {ex.Message}");
            }
        }

        public void SwitchOff()
        {
            string? lamp = SelectLamp();
            if (string.IsNullOrWhiteSpace(lamp))
                return;
            Guid id = new Guid(lamp);
            try
            {
                if (!new LampCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected lamp is alredy off.");
                else
                {
                    new SwitchOffLampCommand(_repository).Execute(id);
                    WriteLine("Selected lamp switched off succesfully!");
                }
            }
            catch (ArgumentException ex)
            {
                WriteLine($"ERROR: {ex.Message}");
            }
        }

        public void Brighten()
        {
            string? lamp = SelectLamp();
            if (string.IsNullOrWhiteSpace(lamp))
                return;
            Guid id = new Guid(lamp);
            try
            {
                if (!new LampCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected lamp must be turned on to use this function.");
                else if (new LampCheckIntensityMaxQuery(_repository).Execute(id))
                    WriteLine("Selected lamp's intensity is already at maximum.");
                else
                {
                    Write("Insert the amount you want to add to the selected lamp's intensity:");
                    if(!int.TryParse(ReadLine(), out int amount))
                    {
                        WriteLine("Invalid amount.");
                        return;
                    }
                    new BrightenLampCommand(_repository).Execute(id, amount);
                    WriteLine("Selected lamp's intensity increased by amount.");
                }
            }
            catch (ArgumentException ex)
            {
                WriteLine($"ERROR: {ex.Message}");
            }
        }

        public void Dimmer()
        {
            string? lamp = SelectLamp();
            if (string.IsNullOrWhiteSpace(lamp))
                return;
            Guid id = new Guid(lamp);
            try
            {
                if (!new LampCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected lamp must be turned on to use this function.");
                else if (new LampCheckIntensityMinQuery(_repository).Execute(id))
                    WriteLine("Selected lamp's intensity is already at minimum.");
                else
                {
                    Write("Insert the amount you want to subtract to the selected lamp's intensity:");
                    if (!int.TryParse(ReadLine(), out int amount))
                    {
                        WriteLine("Invalid amount.");
                        return;
                    }
                    new DimmerLampCommand(_repository).Execute(id, amount);
                    WriteLine("Selected lamp's intensity decreased by amount.");
                }
            }
            catch (ArgumentException ex)
            {
                WriteLine($"ERROR: {ex.Message}");
            }
        }

        public void ChangeBrightness()
        {
            string? lamp = SelectLamp();
            if (string.IsNullOrWhiteSpace(lamp))
                return;
            Guid id = new Guid(lamp);
            if (!new LampCheckIsOnQuery(_repository).Execute(id))
            {
                WriteLine("Selected lamp must be turned on to use this function.");
                return;
            }

            Write("Insert new intensity: ");
            if (!int.TryParse(ReadLine(), out int newIntensity))
            {
                WriteLine("Invalid brightness");
                return;
            }

            try
            {
                new SetIntensityCommand(_repository).Execute(id, newIntensity);
                WriteLine("Selected lamp's intensity changed.");
            }
            catch (ArgumentException ex)
            {
                WriteLine($"ERROR: {ex.Message}");
            }
        }

        private void ShowLamps()
        {
            var lamps = new GetAllLampsQuery(_repository).Execute();

            WriteLine("Lamps: ");

            if (lamps.Count == 0)
            {
                WriteLine("There are no lamps available.");
                return;
            }

            for (int i = 0; i < lamps.Count; i++)
            {
                var l = lamps[i];
                WriteLine($"{i + 1}. {l.Name}\n{l}");
            }
        }
        private void ShowChoices()
        {
            WriteLine("1 - Add lamp \n" +
                "2 - Remove lamp \n" +
                "3 - Switch On \n" +
                "4 - Switch Off \n" +
                "5 - Brighten \n" +
                "6 - Dimmer \n" +
                "7 - Change brightness \n" +
                "8 - Return to device selection menu");
        }

        public void ShowMenu(LampController controller)
        {
            bool exit = false;
            while (!exit)
            {
                Clear();
                Write("\x1b[3J");
                controller.ShowLamps();
                controller.ShowChoices();
                Write("Select an option: ");
                string? choice = ReadLine();

                WriteLine();

                switch (choice)
                {
                    case "1":
                        controller.AddLamp();
                        break;
                    case "2":
                        controller.RemoveLamp();
                        break;
                    case "3":
                        controller.SwitchOn();
                        break;
                    case "4":
                        controller.SwitchOff();
                        break;
                    case "5":
                        controller.Brighten();
                        break;
                    case "6":
                        controller.Dimmer();
                        break;
                    case "7":
                        controller.ChangeBrightness();
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        WriteLine("Invalid Choice");
                        break;
                }

                WriteLine("Press Enter To go back to the menu");
                ReadLine();
            }
        }

        private string? SelectLamp()
        {
            var lamps = new GetAllLampsQuery(_repository).Execute();
            if (lamps.Count == 0)
            {
                WriteLine("There are no lamps available");
                return null;
            }

            Write("Insert lamp number: ");
            if (!int.TryParse(ReadLine(), out int num))
            {
                WriteLine("Invalid number.");
                return null;
            }

            if (num < 1 || num > lamps.Count)
            {
                WriteLine("Inserted number goes out of range (no corrponding lamp).");
                return null;
            }

            try
            {
                return lamps[num - 1].Id.ToString();
            }
            catch (ArgumentException ex)
            {
                WriteLine($"ERROR: {ex.Message}");
                return null;
            }
        }
    }
}
