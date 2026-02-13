namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditioner.Repository
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
