using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Domain
{
    public class LampsRow
    {
        public List<AbstractLamp> LampList { get; set; }

        public int Quantity { get; set; }


        public LampsRow(int quantity, AbstractLamp lamp)
        {
            Quantity = quantity;

            LampList = new List<AbstractLamp>();

            for (int i = 0; i < Quantity; i++)
                LampList.Add(lamp);
        }



        public void SwitchOff()
        {
            for (int i = 0; i < Quantity; i++)
                LampList[i].SwitchOff();
        }

        public void SwitchOff(Guid Id) //Switch Off by ID
        {
            for (int i = 0; i < Quantity; i++)
            {
                if (Id == LampList[i].Id)
                    LampList[i].SwitchOff();
            }
        }
        public void SwitchOff(string name) //Switch Off by name
        {
            if (name != null)
                LampList[name].SwitchOff();
            else
                throw new ArgumentOutOfRangeException("position must be between 0 and Quantity", nameof(name));
        }

        public void SwitchOn() //Switch On all
        {
            for (int i = 0; i < Quantity; i++)
                LampList[i].SwitchOn();
        }

        public void SwitchOn(Guid Id) //Switch On by ID
        {
            for (int i = 0; i < Quantity; i++)
            {
                if (Id == LampList[i].Id)
                    LampList[i].SwitchOn();
            }
        }

        public void SwitchOn(string name) //Switch On by name
        {
            if (name != null)
                LampList[name].SwitchOn();
            else
                throw new ArgumentOutOfRangeException("position must be between 0 and Quantity", nameof(name));
        }


        public void SetBrightnessForAllLamps(int brightness)
        {
            for (int i = 0; i < Quantity; i++)
                LampList[i].SetBrightness(brightness);
        }

        public void SetBrightnessForLamp(int brightness, int position) //sets ONE lamp's brightness by position
        {
            if (position >= 0 && position < Quantity)
                LampList[position].SetBrightness(brightness);
            else
                throw new ArgumentOutOfRangeException("position must be between 0 and Quantity", nameof(position));
        }

        public void SetBrightnessForLamp(int brightness, string name) //sets ONE lamp's brightness by name 
        {
  
        }

        public void SetBrightnessForLamp(int brightness, Guid Id) //sets ONE lamp's brightness by ID 
        {
           
        }


        public void AddLamp(AbstractLamp lamp)
        {
            LampList.Add(lamp);
        }

        public void AddLampInPosition(AbstractLamp lamp, int position)
        {
            LampList.Insert(position, lamp);
        }

        public void RemoveLamp(Guid Id)
        {
            for (int i = 0; i < Quantity; i++)
            {
                if (Id == LampList[i].Id)
                    LampList.Remove(LampList[i]);
            }
        }

        public void RemoveLamp(string name)
        {
            for (int i = 0; i < Quantity; i++)
            {
                if (name == LampList[i].Name)
                    LampList.Remove(LampList[i]);
            }
        }

        //TODO RemoveLampInPosition methods

        public void RemoveLampInPosition(Guid Id, int position) //RemoveLampInPosition by ID + position
        {

        }

        public void RemoveLampInPosition(string name, int position) //RemoveLampInPosition by name + position
        {
            
        }
        
    }
}

