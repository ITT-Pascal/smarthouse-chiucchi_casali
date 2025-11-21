using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.BlaisePascal.Domain
{
    public class LampsRow
    {
        //Properties
        public List<AbstractLamp> LampList { get; set; } = new List<AbstractLamp>();
        public string Name { get; set; }
        //public int Quantity { get; set; }


        //Constructor
        public LampsRow(string name, List<AbstractLamp> lamps)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name of the lamps row cannot be null or white spaces.", nameof(name));
            if (lamps == null)
                throw new ArgumentNullException(nameof(lamps));
            foreach (var lamp in lamps)
            {
                if (lamp == null)
                    throw new ArgumentNullException(nameof(lamp));
                LampList.Add(lamp);
            }
            if (LampList.Count == 0)
                throw new ArgumentException("Must have at least one lamp in a row of lamps.", nameof(LampList));
            Name = name;
        }

        //public LampsRow(int quantity, AbstractLamp lamp)
        //{
        //    Quantity = quantity;

        //    LampList = new List<AbstractLamp>();

        //    for (int i = 0; i < Quantity; i++)
        //        LampList.Add(lamp);
        //}



        //Methods

        // ---- SWITCH OFF ----
        public void SwitchOff() //Switch Off all
        {
            for (int i = 0; i < LampList.Count; i++)
                LampList[i].SwitchOff();
        }

        public void SwitchOff(Guid Id) //Switch Off by ID
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (Id == LampList[i].Id)
                    LampList[i].SwitchOff();
            }
        }

        public void SwitchOff(string name) //Switch Off by name
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (name == LampList[i].Name)
                    LampList[i].SwitchOff();
            }
        }

        // ---- SWITCH ON ----
        public void SwitchOn() //Switch On all
        {
            for (int i = 0; i < LampList.Count; i++)
                LampList[i].SwitchOn();
        }

        public void SwitchOn(Guid Id) //Switch On by ID
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (Id == LampList[i].Id)
                    LampList[i].SwitchOn();
            }
        }

        public void SwitchOn(string name) //Switch On by name
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (name == LampList[i].Name)
                    LampList[i].SwitchOn();
            }
        }

        // ---- SET INTENSITY ----
        public void SetIntensityForAllLamps(int brightness) //Set intensity for all lamps
        {
            for (int i = 0; i < LampList.Count; i++)
                LampList[i].SetIntensity(brightness);
        }

        public void SetIntensityForLamp(int brightness, int position) => LampList[position].SetIntensity(brightness); //Sets ONE lamp's brightness by position

        public void SetIntensityForLamp(int brightness, string name) //Sets ONE lamp's brightness by name 
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (name == LampList[i].Name)
                    LampList[i].SetIntensity(brightness);
            }
        }

        public void SetIntensityForLamp(int brightness, Guid Id) //Sets ONE lamp's brightness by ID 
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (Id == LampList[i].Id)
                    LampList[i].SetIntensity(brightness);
            }
        }

        // ---- ADD LAMP ----
        public void AddLamp(AbstractLamp lamp) => LampList.Add(lamp); //Appends one new lamp

        public void AddLampInPosition(AbstractLamp lamp, int position) => LampList.Insert(position, lamp); //Adds one lamp in a specified index

        // ---- REMOVE LAMP ----
        public void RemoveAllLamps() //Removes all lamps
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                LampList.Remove(LampList[i]);
            }
        }

        public void RemoveLamp(Guid Id) //Remove one lamp by Id
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (Id == LampList[i].Id)
                    LampList.Remove(LampList[i]);
            }
        }

        public void RemoveLamp(string name) //Remove one lamp by Name
        {
            for (int i = 0; i < LampList.Count; i++)
            {
                if (name == LampList[i].Name)
                    LampList.Remove(LampList[i]);
            }
        }

        public void RemoveLampInPosition(int position) => LampList.Remove(LampList[position]); //RemoveLampInPosition by position

        public void RemoveLampInPosition(Guid Id, int position) //RemoveLampInPosition by ID + position
        {
            if (Id == LampList[position].Id)
                LampList.Remove(LampList[position]);
        }

        public void RemoveLampInPosition(string name, int position) //RemoveLampInPosition by Name + position
        {
            if (name == LampList[position].Name)
                LampList.Remove(LampList[position]);
        }

        // ---- FIND LAMP ----
        public AbstractLamp? FindLampWithMaxIntensity()
        {
            int value = 0;
            for(int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Intensity > value)
                    value = LampList[i].Intensity;
            }
            AbstractLamp lamp = new Lamp("lamp");
            for(int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Intensity == value)
                    lamp = LampList[i];
            }
            return (AbstractLamp)lamp;
        }

        public AbstractLamp? FindLampWithMinIntensity()
        {
            int value = 101;
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Intensity < value)
                    value = LampList[i].Intensity;
            }
            AbstractLamp lamp = new Lamp("lamp");
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Intensity == value)
                    lamp = LampList[i];
            }
            return (AbstractLamp)lamp;
        }

        public List<AbstractLamp> FindLampsByIntensityRange(int min, int max)
        {
            List<AbstractLamp> lampsInRange = [];
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Intensity > min && LampList[i].Intensity < max)
                    lampsInRange.Add(LampList[i]);
            }
            return lampsInRange;
        }

        public List<AbstractLamp> FindAllOn()
        {
            List<AbstractLamp> lampsOn = [];
            for(int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Status == DeviceStatus.On)
                    lampsOn.Add(LampList[i]);
            }
            return lampsOn;
        }

        public List<AbstractLamp> FindAllOff()
        {
            List<AbstractLamp> lampsOff = [];
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Status == DeviceStatus.Off)
                    lampsOff.Add(LampList[i]);
            }
            return lampsOff;
        }

        public AbstractLamp? FindLampById(Guid id)
        {
            AbstractLamp lamp = new Lamp("lamp");
            for (int i = 0; i < LampList.Count; i++)
            {
                if (LampList[i].Id == id)
                    lamp = LampList[i];
            }
            return (AbstractLamp)lamp;
        }

        public List<int> SortByIntensity(bool descending) //TODO BETTER
        {
            List<int> intensities = [];
            for (int i = 0; i < LampList.Count; i++)
                intensities.Add(LampList[i].Intensity);
            intensities.Sort();
            return intensities;
        }
    }
}

