namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared
{
    public sealed record Name
    {
        public string _name { get; }

        private Name(string name)
        {
            _name = name;
        }

        public static Name Create(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Name is invalid");
            return new Name(name);
        }
    }
}
