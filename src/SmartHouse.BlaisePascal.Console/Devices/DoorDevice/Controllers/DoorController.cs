using SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Commands;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.DoorDevice.Queries;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice.Repositories;
using static System.Console;

namespace SmartHouse.BlaisePascal.Console.Devices.DoorDevice.Controllers
{
    public class DoorController
    {
        private readonly IDoorRepository _repository;

        public DoorController(IDoorRepository repository)
        {
            _repository = repository;
        }

        public void AddDoor()
        {
            Write("Insert door name: ");
            string name = ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                WriteLine("Inserted name is invalid.");
                return;
            }
            Write("Insert new door's PIN: ");
            if (!int.TryParse(ReadLine(), out int pin))
                WriteLine("Invalid PIN.");
            new AddDoorCommand(_repository).Execute(name, pin);
            WriteLine("Door added succesfully!");
        }

        public void RemoveDoor()
        {
            Guid id = new Guid(SelectDoor());
            if (id == null)
            {
                WriteLine("Selected door does not exist.");
                return;
            }
            try
            {
                new RemoveDoorCommand(_repository).Execute(id);
                WriteLine("Door removed succesfully!");
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}.");
            }
        }

        public void SwitchOn()
        {
            Guid id = new Guid(SelectDoor());
            if (id == null)
            {
                WriteLine("Selected door does not exist.");
                return;
            }
            try
            {
                if (new DoorCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected door is already on.");
                else
                {
                    new DoorSwitchOnCommand(_repository).Execute(id);
                    WriteLine("Selected door switched on succesfully!");
                }
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        public void SwitchOff()
        {
            Guid id = new Guid(SelectDoor());
            if (id == null)
            {
                WriteLine("Selected door does not exist.");
                return;
            }
            try
            {
                if (!new DoorCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected door is already off.");
                else
                {
                    new DoorSwitchOffCommand(_repository).Execute(id);
                    WriteLine("Selected door switched off succesfully!");
                }
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        public void Open()
        {
            Guid id = new Guid(SelectDoor());
            if (id == null)
            {
                WriteLine("Selected door does not exist.");
                return;
            }
            try
            {
                if (!new DoorCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected door is off. To use this function it must be turned on.");
                else if (new DoorCheckIsLockedQuery(_repository).Execute(id))
                    WriteLine("Selected door is locked so it cannot be opened.");
                else if (new DoorCheckIsOpenQuery(_repository).Execute(id))
                    WriteLine("Selected door is already open.");
                else
                {
                    new OpenDoorCommand(_repository).Execute(id);
                    WriteLine("Selected door has been opened.");
                }
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        public void Close()
        {
            Guid id = new Guid(SelectDoor());
            if (id == null)
            {
                WriteLine("Selected door does not exist.");
                return;
            }
            try
            {
                if (!new DoorCheckIsOnQuery(_repository).Execute(id))
                    WriteLine("Selected door is off. To use this function it must be turned on.");
                else if (!new DoorCheckIsOpenQuery(_repository).Execute(id))
                    WriteLine("Selected door is already closed.");
                else
                {
                    new CloseDoorCommand(_repository).Execute(id);
                    WriteLine("Selected door has been closed.");
                }
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        public void Lock()
        {
            Guid id = new Guid(SelectDoor());
            if (id == null)
            {
                WriteLine("Selected door does not exist.");
                return;
            }
            if (!new DoorCheckIsOnQuery(_repository).Execute(id))
            {
                WriteLine("Selected door is off. To use this function it must be turned on.");
                return;
            }
            else if (new DoorCheckIsOpenQuery(_repository).Execute(id))
            {
                WriteLine("Selected door is open so it cannot be locked.");
            }
            else if (new DoorCheckIsLockedQuery(_repository).Execute(id))
            {
                WriteLine("Selected door is already locked.");
                return;
            }
            Write("Insert door's PIN: ");
            if (!int.TryParse(ReadLine(), out int currentPin))
                WriteLine("Invalid PIN.");
            try
            {
                new LockDoorCommand(_repository).Execute(id, currentPin);
                WriteLine("Selected door has been locked.");
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        public void Unlock()
        {
            Guid id = new Guid(SelectDoor());
            if (id == null)
            {
                WriteLine("Selected door does not exist.");
                return;
            }
            if (!new DoorCheckIsOnQuery(_repository).Execute(id))
            {
                WriteLine("Selected door is off. To use this function it must be turned on.");
                return;
            }
            else if (!new DoorCheckIsLockedQuery(_repository).Execute(id))
            {
                WriteLine("Selected door is already unlocked.");
                return;
            }
            Write("Insert door's PIN: ");
            if (!int.TryParse(ReadLine(), out int currentPin))
                WriteLine("Invalid PIN.");
            try
            {
                new UnlockDoorCommand(_repository).Execute(id, currentPin);
                WriteLine("Selected door has been unlocked.");
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        public void ChangePin()
        {
            Guid id = new Guid(SelectDoor());
            if (id == null)
            {
                WriteLine("Selected door does not exist.");
                return;
            }
            if (!new DoorCheckIsOnQuery(_repository).Execute(id))
            {
                WriteLine("Selected door is off. To use this function it must be turned on.");
                return;
            }
            else if (new DoorCheckIsLockedQuery(_repository).Execute(id))
            {
                WriteLine("Selected door is locked so PIN cannot be changed.");
                return;
            }
            Write("Insert door's current PIN: ");
            if (!int.TryParse(ReadLine(), out int currentPin))
                WriteLine("Invalid PIN.");
            Write("Insert door's new PIN: ");
            if (!int.TryParse(ReadLine(), out int newPin))
                WriteLine("Invalid PIN.");
            try
            {
                new DoorChangePinCommand(_repository).Execute(id, currentPin, newPin);
                WriteLine("Selected door's PIN has been changed.");
            }
            catch(ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}");
            }
        }

        private void ShowDoors()
        {
            var doors = new DoorGetAllQuery(_repository).Execute();
            WriteLine("Doors: ");
            if (doors.Count == 0)
            {
                WriteLine("There are no doors available.");
                return;
            }
            for(int i=0; i<doors.Count; i++)
            {
                var door = doors[i];
                WriteLine($"{i + 1}) {door.Name}\n{door}");
            }
        }

        private void ShowChoices()
        {
            WriteLine("1 - Add door \n" +
                "2 - Remove door \n" +
                "3 - Switch on door \n" +
                "4 - Switch off door \n" +
                "5 - Open door \n" +
                "6 - Close door \n" +
                "7 - Lock door \n" +
                "8 - Unlock door \n" +
                "9 - Change door's PIN \n" +
                "10 - Return to device selection menu");
        }

        public void ShowMenu(DoorController controller)
        {
            bool exit = false;
            while(!exit)
            {
                Clear();
                Write("\x1b[3J");
                controller.ShowDoors();
                controller.ShowChoices();
                Write("Select an option: ");
                string choice = ReadLine();

                WriteLine();

                switch (choice)
                {
                    case "1":
                        controller.AddDoor();
                        break;
                    case "2":
                        controller.RemoveDoor();
                        break;
                    case "3":
                        controller.SwitchOn();
                        break;
                    case "4":
                        controller.SwitchOff();
                        break;
                    case "5":
                        controller.Open();
                        break;
                    case "6":
                        controller.Close();
                        break;
                    case "7":
                        controller.Lock();
                        break;
                    case "8":
                        controller.Unlock();
                        break;
                    case "9":
                        controller.ChangePin();
                        break;
                    case "10":
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

        private string? SelectDoor()
        {
            var doors = new DoorGetAllQuery(_repository).Execute();
            if (doors.Count == 0)
            {
                WriteLine("There are no doors available.");
                return null;
            }

            Write("Insert door number: ");
            if (!int.TryParse(ReadLine(), out int n))
            {
                WriteLine("Invalid number.");
                return null;
            }

            if (n < 1 || n > doors.Count)
            {
                WriteLine("Inserted number goes out of range (no corresponding door).");
                return null;
            }

            try
            {
                return doors[n - 1].Id.ToString();
            }
            catch (ArgumentException exception)
            {
                WriteLine($"ERROR: {exception.Message}.");
                return null;
            }
        }
    }
}
