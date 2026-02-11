namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice.Repositories
{
    public interface ILampRepositories
    {
        void Add(Lamp lamp);
        void Update(Lamp lamp);
        void Remove(Guid id);
        Lamp GetById(Guid id);
        List<Lamp> GetAll();
    }
}
