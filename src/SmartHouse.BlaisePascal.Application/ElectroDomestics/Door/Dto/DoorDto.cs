namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.Door.Dto
{
    public class DoorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Pin { get; set; }
        public string DoorStatus { get; set; }
        public string LockStatus { get; set; }
        public DateTime CreationTime_UTC { get; set; }
        public DateTime LastModification_UTC { get; set; }

        public override string ToString()
        {
            return
                $"Id: {Id}.\n" +
                $"Name: {Name}.\n" +
                $"Status: {Status}.\n" +
                $"Pin: {Pin}.\n" +
                $"DoorStatus: {DoorStatus}.\n" +
                $"LockStatus: {LockStatus}.\n" +
                $"CreationTime: {CreationTime_UTC}.\n" +
                $"LastModification: {LastModification_UTC}.";
        }
    }
}
