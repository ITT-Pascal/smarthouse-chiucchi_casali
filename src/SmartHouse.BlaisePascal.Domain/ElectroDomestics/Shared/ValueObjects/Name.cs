namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared.ValueObjects
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

        public static bool operator ==(Name n1, string n2) => n1._name == n2;
        public static bool operator !=(Name n1, string n2) => n1._name != n2;
        public static bool operator ==(string n1, Name n2) => n1 == n2._name;
        public static bool operator !=(string n1, Name n2) => n1 != n2._name;
    }
}
