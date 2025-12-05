namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.AirConditioner.ScrappedMaterial
{
    public class Multi_AirConditioner
    {
        public Abstract_AirConditioner Conditioner { get; private set; }
        public Multi_AirConditioner(Abstract_AirConditioner conditioner)
        {
            Conditioner = conditioner;
        }

        
        
        
        //TODO
        
        
        //Cambia la modalita' del condizionatore
        //public void ChangeMode()
        //{
        //    if(Conditioner.Automatic == true)
        //    {
        //        if(Conditioner.AmbientTemperature == 20)
        //        {

        //        }
        //    }
        //}
    }
}
