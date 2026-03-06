namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.AirConditionerDevice.Dto
{
    public class AirConditionerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Mode { get; set; }
        public string Power { get; set; } 
        public double AirTemperature { get; set; }
        public DateTime CreationTime_UTC { get; set; }
        public DateTime LastModification_UTC { get; set; }

        public override string ToString()
        {
            return
                $"Id: {Id}.\n" +
                $"Name: {Name}.\n" +
                $"Status: {Status}.\n" +
                $"Mode: {Mode}.\n" +
                $"Power: {Power}.\n" +
                $"AirTemperature: {AirTemperature}.\n" +
                $"CreationTime: {CreationTime_UTC}.\n" +
                $"LastModification: {LastModification_UTC}.";
        }
    }
}
