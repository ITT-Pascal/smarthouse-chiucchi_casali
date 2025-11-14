using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Domain
{
    public class LampsRow
    {
        public List<AbstractLamp> Lamp { get; set; }

        public int Quantity { get; set; }
        
        
        public LampsRow(int quantity, AbstractLamp lamp)
        {
            Quantity = quantity;

            Lamp = new List<AbstractLamp>();

            for (int i = 0; i < Quantity; i++)
                Lamp.Add(lamp);
        }



        public void SwitchOff()
        {
            for (int i = 0; i < Quantity; i++)
                Lamp[i].SwitchOff();
        }

        public void SwitchOff(Guid Id) //Switch Off by ID
        {
            for (int i = 0; i < Quantity; i++)
            {
                if (Id == Lamp[i].Id)
                    Lamp[i].SwitchOff();
            }
        }

        public void SwitchOn() //Switch on all
        {
            for (int i = 0; i < Quantity; i++)
                Lamp[i].SwitchOn();
        }

        public void SwitchOn(Guid Id) //Switch on by ID
        {
            for(int i = 0; i < Quantity; i++)
            {
                if (Id == Lamp[i].Id)
                    Lamp[i].SwitchOn();
            }
        }

        public void SwitchOffOne(string name) 
        {
            if (name != null)
                Lamp[name].SwitchOff();
            else
                throw new ArgumentOutOfRangeException("position must be between 0 and Quantity", nameof(name));
        }


        public void SwitchOnOne(int name)
        {
            if (name != null)
                Lamp[name].SwitchOn();
            else
                throw new ArgumentOutOfRangeException("position must be between 0 and Quantity", nameof(name));
        }


        public void ChangeBrightness(int brightness)
        {
            for (int i = 0; i < Quantity; i++)
                Lamp[i].ChangeBrightness(brightness);
        }

        public void ChangeOneBrightness(int brightness, int position)
        {
            if (position >= 0 && position < Quantity)
                Lamp[position].ChangeBrightness(brightness);
            else
                throw new ArgumentOutOfRangeException("position must be between 0 and Quantity", nameof(position));
        }
    }
}









//public void SwitchOffOne(int position)
//{
//    if (position >= 0 && position < Quantity)
//        Lamp[position].TurnOff();
//    else
//        throw new ArgumentOutOfRangeException("position must be between 0 and Quantity", nameof(position));
//}


//public void SwitchOnOne(int position)
//{
//    if (position >= 0 && position < Quantity)
//        Lamp[position].TurnOn();
//    else
//        throw new ArgumentOutOfRangeException("position must be between 0 and Quantity", nameof(position));
//}

