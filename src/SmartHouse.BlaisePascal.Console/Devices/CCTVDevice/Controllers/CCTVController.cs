using SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Commands;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Queries;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Commands;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;
using static System.Console;

namespace SmartHouse.BlaisePascal.Console.Devices.CCTVDevice.Controllers
{
    public class CCTVController
    {
        private readonly ICCTVRepository _repository;

        public CCTVController(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void AddCCTV()
        {
            Write("Insert CCTV name: ");
            string name = ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                WriteLine("Inserted name is invalid.");
                return;
            }
            new AddCCTVCommand(_repository).Execute(name);
            WriteLine("Air conditioner added succesfully!");
        }

        public void RemoveAirConditioner()
        {
            Guid id = new Guid(SelectAirConditioner());
            if (id == null)
            {
                WriteLine("Selected air conditioner does not exist.");
                return;
            }
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
            Guid id = new Guid(SelectAirConditioner());
            if (id == null)
            {
                WriteLine("Selected air conditioner does not exist.");
                return;
            }
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
            Guid id = new Guid(SelectAirConditioner());
            if (id == null)
            {
                WriteLine("Selected air conditioner does not exist.");
                return;
            }
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
    }
}
