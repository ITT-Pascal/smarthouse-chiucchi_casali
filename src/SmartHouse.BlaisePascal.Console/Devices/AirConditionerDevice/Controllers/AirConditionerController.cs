using SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Commands;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Queries;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;
using static System.Console;

namespace SmartHouse.BlaisePascal.Console.Devices.AirConditionerDevice.Controllers
{
    public class AirConditionerController
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerController(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public void AddAirConditioner()
        {
            Write("Insert air conditioner name: ");
            string? name = ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                WriteLine("Inserted name is invalid.");
                return;
            }
            new AddAirConditionerCommand(_repository).Execute(name);
            WriteLine("Air conditioner added succesfully!");
        }

        public void RemoveAirConditioner()
        {
            string? ac = SelectAirConditioner();
            if (string.IsNullOrWhiteSpace(ac))
                return;
            Guid id = new(ac);
            try
            {
                new RemoveAirConditionerCommand(_repository).Execute(id);
                WriteLine("Air conditioner removed succesfully!");
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}.");
            }
        }

        public void SwitchOn()
        {
            string? ac = SelectAirConditioner();
            if (string.IsNullOrWhiteSpace(ac))
                return;
            Guid id = new(ac);
            try
            {
                if (new AirConditionerCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected air conditioner is already on.");
                else
                {
                    new AirConditionerSwitchOnCommand(_repository).Execute(id);
                    WriteLine("Selected air conditioner switched on succesfully!");
                }
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        public void SwitchOff()
        {
            string? ac = SelectAirConditioner();
            if (string.IsNullOrWhiteSpace(ac))
                return;
            Guid id = new(ac);
            try
            {
                if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected air conditioner is already off.");
                else
                {
                    new AirConditionerSwitchOnCommand(_repository).Execute(id);
                    WriteLine("Selected air conditioner switched off succesfully!");
                }
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        public void SwitchToDryMode()
        {
            string? ac = SelectAirConditioner();
            if (string.IsNullOrWhiteSpace(ac))
                return;
            Guid id = new(ac);
            try
            {
                if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected air conditioner is off. To use this function it must be turned on.");
                else if (new AirConditionerCheckIsDryModeQuery(_repository).Execute(id))
                    WriteLine("Selected air conditioner is already on dry mode.");
                else
                {
                    new AirConditionerSwitchToDryModeCommand(_repository).Execute(id);
                    WriteLine("Selected air conditioner's mode switched to dry.");
                }
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        public void SwitchToHotMode()
        {
            string? ac = SelectAirConditioner();
            if (string.IsNullOrWhiteSpace(ac))
                return;
            Guid id = new(ac);
            try
            {
                if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected air conditioner is off. To use this function it must be turned on.");
                else if (new AirConditionerCheckIsHotModeQuery(_repository).Execute(id))
                    WriteLine("Selected air conditioner is already on hot mode.");
                else
                {
                    new AirConditionerSwitchToHotModeCommand(_repository).Execute(id);
                    WriteLine("Selected air conditioner's mode switched to hot.");
                }
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        public void SwitchToCoolMode()
        {
            string? ac = SelectAirConditioner();
            if (string.IsNullOrWhiteSpace(ac))
                return;
            Guid id = new(ac);
            try
            {
                if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected air conditioner is off. To use this function it must be turned on.");
                else if (new AirConditionerCheckIsCoolModeQuery(_repository).Execute(id))
                    WriteLine("Selected air conditioner is already on cool mode.");
                else
                {
                    new AirConditionerSwitchToCoolModeCommand(_repository).Execute(id);
                    WriteLine("Selected air conditioner's mode switched to cool.");
                }
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        public void SetPowerToPowerful()
        {
            string? ac = SelectAirConditioner();
            if (string.IsNullOrWhiteSpace(ac))
                return;
            Guid id = new(ac);
            try
            {
                if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected air conditioner is off. To use this function it must be turned on.");
                else if (new AirConditionerCheckIsPowerfulPowerQuery(_repository).Execute(id))
                    WriteLine("Selected air conditioner is already on powerful power.");
                else
                {
                    new AirConditionerSetPowerToPowerfulCommand(_repository).Execute(id);
                    WriteLine("Selected air conditioner's power switched to powerful.");
                }
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        public void SetPowerToNormal()
        {
            string? ac = SelectAirConditioner();
            if (string.IsNullOrWhiteSpace(ac))
                return;
            Guid id = new(ac);
            try
            {
                if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected air conditioner is off. To use this function it must be turned on.");
                else if (new AirConditionerCheckIsNormalPowerQuery(_repository).Execute(id))
                    WriteLine("Selected air conditioner is already on normal power.");
                else
                {
                    new AirConditionerSetPowerToNormalCommand(_repository).Execute(id);
                    WriteLine("Selected air conditioner's power switched to normal.");
                }
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        public void SetPowerToWeak()
        {
            string? ac = SelectAirConditioner();
            if (string.IsNullOrWhiteSpace(ac))
                return;
            Guid id = new(ac);
            try
            {
                if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected air conditioner is off. To use this function it must be turned on.");
                else if (new AirConditionerCheckIsWeakPowerQuery(_repository).Execute(id))
                    WriteLine("Selected air conditioner is already on weak power.");
                else
                {
                    new AirConditionerSetPowerToWeakCommand(_repository).Execute(id);
                    WriteLine("Selected air conditioner's power switched to weak.");
                }
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        private void ShowAirConditioners()
        {
            var airConditioners = new AirConditionerGetAllQuery(_repository).Execute();
            WriteLine("Air conditioners: ");
            if(airConditioners.Count == 0)
            {
                WriteLine("There are no air conditioners available.");
                return;
            }
            for(int i=0; i<airConditioners.Count; i++)
            {
                var ac = airConditioners[i];
                WriteLine($"{i + 1}) {ac.Name}\n{ac}\n");
            }
        }

        private void ShowChoices()
        {
            WriteLine("1 - Add air conditioner \n" +
                "2 - Remove air conditioner \n" +
                "3 - Switch on air conditioner \n" +
                "4 - Switch off air conditioner \n" +
                "5 - Switch air conditioner mode to dry \n" +
                "6 - Switch air conditioner mode to hot \n" +
                "7 - Switch air conditioner mode to cool \n" +
                "8 - Switch air conditioner power to powerful \n" +
                "9 - Switch air conditioner power to normal \n" +
                "10 - Switch air conditioner power to weak \n" +
                "11 - Return to device selection menu");
        }

        public void ShowMenu(AirConditionerController controller)
        {
            bool exit = false;
            while(!exit)
            {
                Clear();
                Write("\x1b[3J");
                controller.ShowAirConditioners();
                controller.ShowChoices();
                Write("Select an option: ");
                string? choice = ReadLine();

                WriteLine();

                switch(choice)
                {
                    case "1":
                        controller.AddAirConditioner();
                        break;
                    case "2":
                        controller.RemoveAirConditioner();
                        break;
                    case "3":
                        controller.SwitchOn();
                        break;
                    case "4":
                        controller.SwitchOff();
                        break;
                    case "5":
                        controller.SwitchToDryMode();
                        break;
                    case "6":
                        controller.SwitchToHotMode();
                        break;
                    case "7":
                        controller.SwitchToCoolMode();
                        break;
                    case "8":
                        controller.SetPowerToPowerful();
                        break;
                    case "9":
                        controller.SetPowerToNormal();
                        break;
                    case "10":
                        controller.SetPowerToWeak();
                        break;
                    case "11":
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

        private string? SelectAirConditioner()
        {
            var airConditioners = new AirConditionerGetAllQuery(_repository).Execute();
            if(airConditioners.Count == 0)
            {
                WriteLine("There are no air conditioners available.");
                return null;
            }

            Write("Insert air conditioner number: ");
            if(!int.TryParse(ReadLine(), out int n))
            {
                WriteLine("Invalid number.");
                return null;
            }

            if(n < 1 || n > airConditioners.Count)
            {
                WriteLine("Inserted number goes out of range (no corresponding air conditioner).");
                return null;
            }

            try
            {
                return airConditioners[n - 1].Id.ToString();
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}.");
                return null;
            }
        }
    }
}
