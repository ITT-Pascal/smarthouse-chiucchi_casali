using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Domain
{
    public class MultiLampDevice
    {
        public List<AbstractLamp> Lamp { get; set; }

        public int Quantity { get; set; }
        
        
        public MultiLampDevice(int quantity, AbstractLamp lamp)
        {
            Quantity = quantity;

            Lamp = new List<AbstractLamp>();

            for (int i = 0; i < Quantity; i++)
            {
                Lamp.Add(lamp);
            }
        }



        public void TurnOff()
        {
            for (int i = 0; i < Quantity; i++)
            {
                Lamp[i].TurnOff();
            }
        }


        public void TurnOn()
        {
            for (int i = 0; i < Quantity; i++)
            {
                Lamp[i].TurnOn();
            }
        }
        

        public void ChangeBrightness(int brightness)
        {
            for (int i = 0; i < Quantity; i++)
            {
                Lamp[i].ChangeBrightness(brightness);
            }
        }


        public void TurnOffOne(int position)
        {
            if (position >= 0 && position < Quantity)
            {
                Lamp[position].TurnOff();
            }
            else
            {
                throw new ArgumentOutOfRangeException("position must be between 0 and Quantity", nameof(position));
            }
        }
        

        public void TurnOnOne(int position)
        {
            if (position >= 0 && position < Quantity)
            {
                Lamp[position].TurnOn();
            }
            else
            {
                throw new ArgumentOutOfRangeException("position must be between 0 and Quantity", nameof(position));
            }
        }

        public void ChangeOneBrightness(int brightness, int position)
        {
            if (position >= 0 && position < Quantity)
            {
                Lamp[position].ChangeBrightness(brightness);
            }
            else
            {
                throw new ArgumentOutOfRangeException("position must be between 0 and Quantity", nameof(position));
            }
        }
    }
}

