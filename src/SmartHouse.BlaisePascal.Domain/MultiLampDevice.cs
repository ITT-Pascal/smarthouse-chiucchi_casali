using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.BlaisePascal.Domain
{
    public class MultiLampDevice
    {
        public List<AbstractLamp> Lamp;

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
        public void ChangeBrightness(bool lamp, int brightness, int position)
        {
            for (int i = 0; i < Quantity; i++)
            {
                Lamp[i].ChangeBrightness(brightness);
            }
        }
    }
}

