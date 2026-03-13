namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.LuminousDevice.Lamps.Commands
{
    public class LampDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public double Intensity { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime LastModifiedAtUtc { get; set; }

        public override string ToString()
        {
            return
                $"Id: {Id}.\n" +
                $"Name: {Name}.\n" +
                $"Status: {Status}.\n" +
                $"Intensity: {Intensity}.\n" +
                $"CreatedAt: {CreatedAtUtc}.\n" +
                $"LastModifiedAt: {LastModifiedAtUtc}.";
        }
    }
}
