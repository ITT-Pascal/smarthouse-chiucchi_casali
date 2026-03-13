using SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Commands;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Queries;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;
using static System.Console;

namespace SmartHouse.BlaisePascal.Console.Devices.CCTVDevice.Controllers
{
    public class CCTVController //To finish
    {
        private readonly ICCTVRepository _repository;

        public CCTVController(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void AddCCTV()
        {
            Write("Insert CCTV name: ");
            string? name = ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                WriteLine("Inserted name is invalid.");
                return;
            }
            Write("Insert CCTV PIN: ");
            if(!int.TryParse(ReadLine(), out int pin))
            {
                WriteLine("Invalid PIN.");
                return;
            }
            new AddCCTVCommand(_repository).Execute(name, pin);
            WriteLine("CCTV added succesfully!");
        }

        public void RemoveCCTV() 
        {
            string? cctv = SelectCCTV();
            if (string.IsNullOrWhiteSpace(cctv))
                return;
            Guid id = new(cctv);
            try
            {
                new RemoveCCTVCommand(_repository).Execute(id);
                WriteLine("CCTV removed succesfully!");
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}.");
            }
        }

        public void SwitchOn() 
        {
            string? cctv = SelectCCTV();
            if (string.IsNullOrWhiteSpace(cctv))
                return;
            Guid id = new(cctv);
            try
            {
                if (new CCTVCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected CCTV is already on.");
                else
                {
                    new CCTVSwitchOnCommand(_repository).Execute(id);
                    WriteLine("Selected CCTV switched on succesfully!");
                }
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        public void SwitchOff()
        {
            string? cctv = SelectCCTV();
            if (string.IsNullOrWhiteSpace(cctv))
                return;
            Guid id = new(cctv);
            try
            {
                if (!new CCTVCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected CCTV is already off.");
                else
                {
                    new CCTVSwitchOffCommand(_repository).Execute(id);
                    WriteLine("Selected CCTV switched off succesfully!");
                }
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        private void ShowCCTVs()
        {
            var cctvs = new CCTVGetAllQuery(_repository).Execute();
            Write("CCTVs: ");
            if(cctvs.Count == 0)
            {
                WriteLine("There are no CCTVs available.");
                return;
            }
            for(int i=0; i<cctvs.Count; i++)
            {
                var cctv = cctvs[i];
                WriteLine($"{i + 1}) {cctv.Name}\n{cctv}");
            }
        }

        private void ShowChoices()
        {
            WriteLine("1 - Add CCTV \n" +
                "2 - Remove CCTV \n" +
                "3 - Switch on CCTV \n" +
                "4 - Switch off CCTV" +
                "5 - Return to device selection menu");
        }

        public void ShowMenu(CCTVController controller)
        {
            bool exit = false;
            while(!exit)
            {
                Clear();
                Write("\x1b[3J");
                controller.ShowCCTVs();
                controller.ShowChoices();
                Write("Select an option: ");
                string? choice = ReadLine();

                WriteLine();

                switch (choice)
                {
                    case "1":
                        controller.AddCCTV();
                        break;
                    case "2":
                        controller.RemoveCCTV();
                        break;
                    case "3":
                        controller.SwitchOn();
                        break;
                    case "4":
                        controller.SwitchOff();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        WriteLine("Invalid choice.");
                        break;
                }
                WriteLine("Press Enter to return to the selection menu.");
                ReadLine();
            }
        }

        private string? SelectCCTV()
        {
            var cctvs = new CCTVGetAllQuery(_repository).Execute();
            if (cctvs.Count == 0)
            {
                WriteLine("There are no CCTVs available.");
                return null;
            }

            Write("Insert CCTV number: ");
            if (!int.TryParse(ReadLine(), out int n))
            {
                WriteLine("Invalid number.");
                return null;
            }

            if (n < 1 || n > cctvs.Count)
            {
                WriteLine("Inserted number goes out of range (no corresponding CCTV).");
                return null;
            }

            try
            {
                return cctvs[n - 1].Id.ToString();
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}.");
                return null;
            }
        }
    }
}
