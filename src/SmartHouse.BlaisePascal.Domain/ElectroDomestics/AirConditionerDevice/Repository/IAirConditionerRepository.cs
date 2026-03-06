namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditionerDevice.Repository
{
    public interface IAirConditionerRepository
    {
        void Add(AirConditioner airConditioner);
        void Update(AirConditioner airConditioner);
        void Remove(Guid id);
        AirConditioner GetById(Guid id);
        List<AirConditioner> GetAll();
    }
}
