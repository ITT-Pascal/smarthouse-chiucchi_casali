using System.Xml.Linq;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice
{
    public sealed class MatrixLed
    {
        public AbstractLamp[,] MatrixLamp { get; private set; }
        public string Name { get; private set; }

        public MatrixLed(string name, AbstractLamp[,] matrixLamp)
        {
            Name = name;
            MatrixLamp = matrixLamp;
        }

        // ---- ADD LAMP ----
        public void AddLamp(AbstractLamp lamp)
        {
            int c = 0;

            foreach(AbstractLamp lmp in MatrixLamp)
                if(lmp != null)
                    c++;

            if (c == MatrixLamp.Length)
                throw new Exception("The matrix is alredy full");

            for(int i =0; i < MatrixLamp.GetLength(0); i++)
                for(int j = 0; j < MatrixLamp.GetLength(1); j++)
                    if (MatrixLamp[i, j] == null)
                        MatrixLamp[i, j] = lamp;
        }

        public void AddLampInPosition(AbstractLamp lamp, int row, int column)
        {
            int c = 0;

            foreach (AbstractLamp lmp in MatrixLamp)
                if (lmp != null)
                    c++;

            if (c == MatrixLamp.Length)
                throw new Exception("The matrix is alredy full");

            if (MatrixLamp[row, column] != null)
                throw new Exception("The index is already assigned.");

            MatrixLamp[row, column] = lamp;
        }

        // ---- REMOVE LAMP ----
        public void RemoveLamp(string name)
        {
            for (int i = 0; i < MatrixLamp.GetLength(0); i++)
                for (int j = 0; j < MatrixLamp.GetLength(1); j++)
                    if (MatrixLamp[i, j] != null)
                        if (MatrixLamp[i, j].Name == name)
                            MatrixLamp[i, j] = null;
        }

        public void RemoveLamp(Guid id)
        {
            for (int i = 0; i < MatrixLamp.GetLength(0); i++)
                for (int j = 0; j < MatrixLamp.GetLength(1); j++)
                    if (MatrixLamp[i, j] != null)
                        if (MatrixLamp[i, j].Id == id)
                            MatrixLamp[i, j] = null;
        }

        public void RemoveLampInPosition(int row, int column)
        {
            MatrixLamp[row, column] = null;
        }

        public void RemoveAllLamps()
        {
            for (int i = 0; i < MatrixLamp.GetLength(0); i++)
                for (int j = 0; j < MatrixLamp.GetLength(1); j++)
                    MatrixLamp[i, j] = null;
        }

        // ---- SWITCH ON ----
        public void SwitchOn(string name)
        {
            foreach (AbstractLamp l in MatrixLamp)
                if (l != null)
                    if (l.Name == name)
                        l.SwitchOn();
        }

        public void SwitchOn(Guid id)
        {
            foreach (AbstractLamp l in MatrixLamp)
                if (l != null)
                    if (l.Id == id)
                        l.SwitchOn();
        }

        public void SwitchOnInPosition(int row, int column)
        {
            MatrixLamp[row, column]?.SwitchOn();
        }

        public void AllSwitchOn()
        {
            foreach (AbstractLamp l in MatrixLamp)
                l.SwitchOn();
        }

        // ---- SWITCH OFF
        public void SwitchOff(string name)
        {
            foreach (AbstractLamp l in MatrixLamp)
                if (l != null)
                    if (l.Name == name)
                        l.SwitchOff();
        }

        public void SwitchOff(Guid id)
        {
            foreach (AbstractLamp l in MatrixLamp)
                if (l != null)
                    if (l.Id == id)
                        l.SwitchOff();
        }

        public void SwitchOffInPosition(int row, int column)
        {
            MatrixLamp[row, column]?.SwitchOff();
        }

        public void AllSwitchOff()
        {
            foreach (AbstractLamp l in MatrixLamp)
                l.SwitchOff();
        }
    }
}
