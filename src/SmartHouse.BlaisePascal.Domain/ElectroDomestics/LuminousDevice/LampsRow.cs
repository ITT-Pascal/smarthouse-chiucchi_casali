using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice
{
    public sealed class LampsRow
    {
        //Properties
        public List<AbstractLamp> LampList { get; set; } //= new List<AbstractLamp>();
        public string Name { get; set; }


        //Constructor
        public LampsRow(string name)
        {
            //if (string.IsNullOrWhiteSpace(name))
            //    throw new ArgumentException("Name of the lamps row cannot be null or white spaces.", nameof(name));
            Name = name;
            LampList = new List<AbstractLamp>();
        }

        public LampsRow(string name, List<AbstractLamp> lamps)
        {
            //if (string.IsNullOrWhiteSpace(name))
            //    throw new ArgumentException("Name of the lamps row cannot be null or white spaces.", nameof(name));
            Name = name;
            LampList = lamps;

            //if (lamps == null)
            //    throw new ArgumentNullException(nameof(lamps));
            //foreach (var lamp in lamps)
            //{
            //    if (lamp == null)
            //        throw new ArgumentNullException(nameof(lamp));
            //    LampList.Add(lamp);
            //}
            //if (LampList.Count == 0)
            //    throw new ArgumentException("Must have at least one lamp in a row of lamps.", nameof(LampList));
            //Name = name;
        }


        //Methods
        // ---- ADD LAMP ----
        public void AddLamp(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name of the lamp cannot be null or white spaces.", nameof(name));
            LampList.Add(new Lamp(name));
        }

        public void AddEcoLamp(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name of the eco lamp cannot be null or white spaces.", nameof(name));
            LampList.Add(new EcoLamp(name));
        }

        public void AddLamp(AbstractLamp lamp) => LampList.Add(lamp); //Appends one new lamp

        public void AddLampInPosition(AbstractLamp lamp, int position) => LampList.Insert(position, lamp); //Adds one lamp in a specified index

        // ---- TOGGLE ----
        public void Toggle() //Toggle all
        {
            for (int i = 0; i < LampList.Count; i++)
                LampList[i].Toggle();
        }

        public void Toggle(Guid Id) //Toggle by ID
        {
            for (int i = 0; i < LampList.Count; i++)
                if (Id == LampList[i].Id)
                    LampList[i].Toggle();
        }

        public void Toggle(string name) //Toggle by name
        {
            for (int i = 0; i < LampList.Count; i++)
                if (name == LampList[i].Name)
                    LampList[i].Toggle();
        }

        // ---- SWITCH OFF ----
        public void SwitchOff() //Switch Off all
        {
            for (int i = 0; i < LampList.Count; i++)
                LampList[i].SwitchOff();
        }

        public void SwitchOff(Guid Id) //Switch Off by ID
        {
            for (int i = 0; i < LampList.Count; i++)
                if (Id == LampList[i].Id)
                    LampList[i].SwitchOff();
        }

        public void SwitchOff(string name) //Switch Off by name
        {
            for (int i = 0; i < LampList.Count; i++)
                if (name == LampList[i].Name)
                    LampList[i].SwitchOff();
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
                if (Id == LampList[i].Id)
                    LampList[i].SwitchOn();
        }

        public void SwitchOn(string name) //Switch On by name
        {
            for (int i = 0; i < LampList.Count; i++)
                if (name == LampList[i].Name)
                    LampList[i].SwitchOn();
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
                if (name == LampList[i].Name)
                    LampList[i].SetIntensity(brightness);
        }

        public void SetIntensityForLamp(int brightness, Guid Id) //Sets ONE lamp's brightness by ID 
        {
            for (int i = 0; i < LampList.Count; i++)
                if (Id == LampList[i].Id)
                    LampList[i].SetIntensity(brightness);
        }

        // ---- REMOVE LAMP ----
        public void RemoveAllLamps() //Remove all lamps
        {
            LampList.Clear();
            //for (int i = 0; i < lamplist.count; i++) //REMOVE ONE BY ONE
            //    lamplist.removeat(i);
        }

        public void RemoveLamp(Guid Id) //Remove one lamp by Id
        {
            for (int i = 0; i < LampList.Count; i++)
                if (Id == LampList[i].Id)
                    LampList.RemoveAt(i);
        }

        public void RemoveLamp(string name) //Remove one lamp by Name
        {
            for (int i = 0; i < LampList.Count; i++)
                if (name == LampList[i].Name)
                    LampList.RemoveAt(i);
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
            AbstractLamp? lamp = LampList[0];
            foreach (AbstractLamp lam in LampList)
                if (lam.Intensity > lamp.Intensity)
                    lamp = lam;
            return lamp;

            //LONGER AND WORSE METHOD
            //int value = 0;
            //for(int i = 0; i < LampList.Count; i++)
            //{
            //    if (LampList[i].Intensity > value)
            //        value = LampList[i].Intensity;
            //}
            //AbstractLamp lamp = new Lamp("lamp");
            //for(int i = 0; i < LampList.Count; i++)
            //{
            //    if (LampList[i].Intensity == value)
            //        lamp = LampList[i];
            //}
            //return (AbstractLamp)lamp;
        }

        public AbstractLamp? FindLampWithMinIntensity()
        {
            AbstractLamp? lamp = LampList[0];
            foreach (AbstractLamp lam in LampList)
                if (lam.Intensity < lamp.Intensity)
                    lamp = lam;
            return lamp;

            //LONGER AND WORSE METHOD
            //int value = 101;
            //for (int i = 0; i < LampList.Count; i++)
            //{
            //    if (LampList[i].Intensity < value)
            //        value = LampList[i].Intensity;
            //}
            //AbstractLamp lamp = new Lamp("lamp");
            //for (int i = 0; i < LampList.Count; i++)
            //{
            //    if (LampList[i].Intensity == value)
            //        lamp = LampList[i];
            //}
            //return (AbstractLamp)lamp;
        }

        public List<AbstractLamp> FindLampsByIntensityRange(int min, int max)
        {
            List<AbstractLamp> lampsInRange = [];
            for (int i = 0; i < LampList.Count; i++)
                if (LampList[i].Intensity >= min && LampList[i].Intensity <= max)
                    lampsInRange.Add(LampList[i]);
            return lampsInRange;
        }

        public List<AbstractLamp> FindAllOn()
        {
            List<AbstractLamp> lampsOn = [];
            for(int i = 0; i < LampList.Count; i++)
                if (LampList[i].Status == DeviceStatus.On)
                    lampsOn.Add(LampList[i]);
            return lampsOn;
        }

        public List<AbstractLamp> FindAllOff()
        {
            List<AbstractLamp> lampsOff = [];
            for (int i = 0; i < LampList.Count; i++)
                if (LampList[i].Status == DeviceStatus.Off)
                    lampsOff.Add(LampList[i]);
            return lampsOff;
        }

        public AbstractLamp? FindLampById(Guid id)
        {
            AbstractLamp? lamp = LampList[0];
            foreach (AbstractLamp lam in LampList)
                if (lam.Id == id)
                    lamp = lam;
            return lamp;

            //WORSE METHOD
            //AbstractLamp? lamp = new Lamp("lamp");
            //for (int i = 0; i < LampList.Count; i++)
            //    if (LampList[i].Id == id)
            //        lamp = LampList[i];
            //return lamp;
        }

        public AbstractLamp? FindLampByName(string name)
        {
            AbstractLamp? lamp = LampList[0];
            foreach (AbstractLamp lam in LampList)
                if (lam.Name == name)
                    lamp = lam;
            return lamp;
        }

        public List<AbstractLamp> SortByIntensity(bool descending)
        {
            List<AbstractLamp> sortedLamps = [];
            if(descending)
                sortedLamps = LampList.OrderByDescending(l => l.Intensity).ToList();
            else
                sortedLamps = LampList.OrderBy(l => l.Intensity).ToList();
            return sortedLamps;


            // NOT COMPLETED METHOD

            //List<int> intensities = [];
            //for (int i = 0; i < LampList.Count; i++)
            //    intensities.Add(LampList[i].Intensity);
            //intensities.Sort();
            //return intensities;


            // ALTERNATIVE METHOD

            //List<AbstractLamp> sortedLamps = new List<AbstractLamp>();
            //AbstractLamp? lampToRemove = null;
            //if (descending)
            //    while (LampList.Count != 0)
            //    {
            //        lampToRemove = FindLampWithMaxIntensity();
            //        sortedLamps.Add(lampToRemove);
            //    }
            //else
            //    while (LampList.Count != 0)
            //    {
            //        lampToRemove = FindLampWithMinIntensity();
            //        sortedLamps.Add(lampToRemove);
            //    }
            //return sortedLamps;
        }

        // ---- DIMMER ----
        public void DimmerAllLamps(int amount)
        {
            for (int i = 0; i < LampList.Count; i++)
                LampList[i].Dimmer(amount);
        }

        public void DimmerLamp(Guid id, int amount)
        {
            for (int i = 0; i < LampList.Count; i++)
                if (LampList[i].Id == id)
                    LampList[i].Dimmer(amount);
        }

        public void DimmerLamp(string name, int amount)
        {
            for (int i = 0; i < LampList.Count; i++)
                if (LampList[i].Name == name)
                    LampList[i].Dimmer(amount);
        }

        public void DimmerLampInPosition(int position, int amount) => LampList[position].Dimmer(amount);

        public void DimmerLampInPosition(Guid id, int position, int amount)
        {
            if (LampList[position].Id == id)
                LampList[position].Dimmer(amount);
        }
        public void DimmerLampInPosition(string name, int position, int amount)
        {
            if (LampList[position].Name == name)
                LampList[position].Dimmer(amount);
        }

        // ---- BRIGHTEN ----
        public void BrightenAllLamps(int amount)
        {
            for (int i = 0; i < LampList.Count; i++)
                LampList[i].Brighten(amount);
        }

        public void BrightenLamp(Guid id, int amount)
        {
            for (int i = 0; i < LampList.Count; i++)
                if (LampList[i].Id == id)
                    LampList[i].Brighten(amount);
        }

        public void BrightenLamp(string name, int amount)
        {
            for (int i = 0; i < LampList.Count; i++)
                if (LampList[i].Name == name)
                    LampList[i].Brighten(amount);
        }

        public void BrightenLampInPosition(int position, int amount) => LampList[position].Brighten(amount);

        public void BrightenLampInPosition(Guid id, int position, int amount)
        {
            if (LampList[position].Id == id)
                LampList[position].Brighten(amount);
        }
        public void BrightenLampInPosition(string name, int position, int amount)
        {
            if (LampList[position].Name == name)
                LampList[position].Brighten(amount);
        }
    }
}
//public LampsRow(int quantity, AbstractLamp lamp)
//{
//    Quantity = quantity;
//    LampList = new List<AbstractLamp>();
//    for (int i = 0; i < Quantity; i++)
//        LampList.Add(lamp);
//}