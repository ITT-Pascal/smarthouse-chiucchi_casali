using SmartHouse.BlaisePascal.Console.Devices.AirConditionerDevice.Controllers;
using SmartHouse.BlaisePascal.Console.Devices.CCTVDevice.Controllers;
using SmartHouse.BlaisePascal.Console.Devices.DoorDevice.Controllers;
using SmartHouse.BlaisePascal.Console.Devices.Illumination.Lamps.Controllers;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice.Repositories;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.DoorDevice.Repositories;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Repositories;
using SmartHouse.BlaisePascal.Infrastructure.Repositories.Devices.AirConditionerDevice.InMemory;
using SmartHouse.BlaisePascal.Infrastructure.Repositories.Devices.CCTVDevice.InMemory;
using SmartHouse.BlaisePascal.Infrastructure.Repositories.Devices.DoorDevice.InMemory;
using SmartHouse.BlaisePascal.Infrastructure.Repositories.Devices.Lighting.Lamps.InMemory;
using static System.Console;
class Program
{
    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Clear();
            Write("\x1b[3J");

            WriteLine("1 - Lamps \n" + 
                "2 - Air conditioner \n" + 
                "3 - CCTV \n" + 
                "4 - Door \n" + 
                "5 - Thermostat \n" + 
                "6 - Exit");

            Write("Choose an option: ");
            string? choice = ReadLine();

            switch(choice)
            {
                case "1":
                    ILampRepository lampRepository = new InMemoryLampRepository();
                    LampController lampController = new LampController(lampRepository);
                    lampController.ShowMenu(lampController);
                    break;
                case "2":
                    IAirConditionerRepository airConditionerRepository = new InMemoryAirConditionerRepository();
                    AirConditionerController airConditionerController = new AirConditionerController(airConditionerRepository);
                    airConditionerController.ShowMenu(airConditionerController);
                    break;
                case "3":
                    ICCTVRepository cctvRepository = new InMemoryCCTVRepository();
                    CCTVController cctvController = new CCTVController(cctvRepository);
                    cctvController.ShowMenu(cctvController);
                    break;
                case "4":
                    IDoorRepository doorRepository = new InMemoryDoorRepository();
                    DoorController doorController = new DoorController(doorRepository);
                    doorController.ShowMenu(doorController);
                    break;
                case "5":
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    WriteLine("Invalid choice.");
                    break;
            }
        }
        Clear();
        Write("\x1b[3J");
        WriteLine("Bye bye! (viva i test!)");
        Write("\nPress enter to close the menu.");
    }
}