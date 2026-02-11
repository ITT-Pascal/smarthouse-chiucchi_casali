using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.ValueObjects;

namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice
{
    public sealed class MatrixLed: ILampFamily
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

            foreach (AbstractLamp lmp in MatrixLamp)
                if (lmp != null)
                    c++;

            if (c == MatrixLamp.Length)
                throw new Exception("The matrix is alredy full");

            MatrixLamp[FindEmptySpot().row, FindEmptySpot().column] = lamp;
        }

        private (int row, int column) FindEmptySpot()
        {
            for (int i = 0; i < MatrixLamp.GetLength(0); i++)
                for (int j = 0; j < MatrixLamp.GetLength(1); j++)
                    if (MatrixLamp[i, j] == null)
                        return (i, j);
            
            return (-1, -1);
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
                if (l.Name == name)
                    l?.SwitchOn();
        }

        public void SwitchOn(Guid id)
        {
            foreach (AbstractLamp l in MatrixLamp)
                if (l.Id == id)
                    l?.SwitchOn();
        }

        public void SwitchOnInPosition(int row, int column)
        {
            MatrixLamp[row, column]?.SwitchOn();
        }

        public void AllSwitchOn()
        {
            foreach (AbstractLamp l in MatrixLamp)
                l?.SwitchOn();
        }

        // ---- SWITCH OFF
        public void SwitchOff(string name)
        {
            foreach (AbstractLamp l in MatrixLamp)
                if (l.Name == name)
                    l?.SwitchOff();
        }

        public void SwitchOff(Guid id)
        {
            foreach (AbstractLamp l in MatrixLamp)
                if (l.Id == id)
                    l?.SwitchOff();
        }

        public void SwitchOffInPosition(int row, int column)
        {
            MatrixLamp[row, column]?.SwitchOff();
        }

        public void AllSwitchOff()
        {
            foreach (AbstractLamp l in MatrixLamp)
                l?.SwitchOff();
        }

        // ---- TOGGLE ----
        public void Toggle(string name)
        {
            foreach (AbstractLamp l in MatrixLamp)
                if (l.Name == name)
                    l?.Toggle();
        }

        public void Toggle(Guid id)
        {
            foreach (AbstractLamp l in MatrixLamp)
                if (l.Id == id)
                    l?.Toggle();
        }

        public void ToggleInPosition(int row, int column)
        {
            MatrixLamp[row, column]?.Toggle();
        }

        public void AllToggle ()
        {
            foreach (AbstractLamp l in MatrixLamp)
                l?.Toggle();
        }

        // ---- SET INTENSITY ----
        public void SeIntensity(string name, Intensity newIntensity)
        {
            foreach (AbstractLamp l in MatrixLamp)
                if (l.Name == name)
                    l?.SetIntensity(newIntensity);
        }

        public void SeIntensity(Guid id, Intensity newIntensity)
        {
            foreach (AbstractLamp l in MatrixLamp)
                if (l.Id == id)
                    l?.SetIntensity(newIntensity);
        }

        public void SetIntensityInPosition(int row, int column, Intensity newIntensity)
        {
            MatrixLamp[row, column]?.SetIntensity(newIntensity);
        }

        public void SetAllIntensity(Intensity newIntensity)
        {
            foreach (AbstractLamp l in MatrixLamp)
                l?.SetIntensity(newIntensity);
        }

        // ---- DIMMER ----
        public void Dimmer(string name, int amount)
        {
            foreach (AbstractLamp l in MatrixLamp)
                if (l.Name == name)
                    l?.Dimmer(amount);
        }

        public void Dimmer(Guid id, int amount)
        {
            foreach (AbstractLamp l in MatrixLamp)
                if (l.Id == id)
                    l?.Dimmer(amount);
        }

        public void DimmerInPosition(int row, int column, int amount)
        {
            MatrixLamp[row, column]?.Dimmer(amount);
        }

        public void DimmerAll(int amount)
        {
            foreach (AbstractLamp l in MatrixLamp)
                l?.Dimmer(amount);
        }

        // ---- BRIGHTEN ----
        public void Brighten(string name, int amount)
        {
            foreach (AbstractLamp l in MatrixLamp)
                if (l.Name == name)
                    l?.Brighten(amount);
        }

        public void Brighten(Guid id, int amount)
        {
            foreach (AbstractLamp l in MatrixLamp)
                if (l.Id == id)
                    l?.Brighten(amount);
        }

        public void BrightenInPosition(int row, int column, int amount)
        {
            MatrixLamp[row, column]?.Brighten(amount);
        }

        public void BrightenAll(int amount)
        {
            foreach (AbstractLamp l in MatrixLamp)
                l?.Brighten(amount);
        }
    }
}
