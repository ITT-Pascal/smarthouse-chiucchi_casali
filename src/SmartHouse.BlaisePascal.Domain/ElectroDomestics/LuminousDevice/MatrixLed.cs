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

        public void RemoveLamp(string name)
        {
            for (int i = 0; i < MatrixLamp.GetLength(0); i++)
                for (int j = 0; j < MatrixLamp.GetLength(1); j++)
                    if (MatrixLamp[i, j] != null)
                        if (MatrixLamp[i, j].Name == name)
                            MatrixLamp[i, j] = null;
        }
    }
}
