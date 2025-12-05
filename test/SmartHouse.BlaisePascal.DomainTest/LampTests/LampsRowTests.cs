using SmartHouse.BlaisePascal.Domain.ElectroDomestics.LuminousDevice;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.Shared;

namespace SmartHouse.BlaisePascal.DomainTest.LampTests
{
    public class LampsRowTests
    {
        //[Fact]
        //public void Constructor_WhenNameIsNullOrWhiteSpace_ThrowArgumentException()
        //{
        //    List<AbstractLamp> lamps = new List<AbstractLamp>();
        //    Assert.Throws<ArgumentException> (() => LampsRow newLampsRow = new LampsRow(null, lamps))
        //}

        //Constructor Tests
        [Fact]
        public void Constructor_WhenCreatingANewEmptyLampsRow_LampsRowIsEmpty()
        {
            LampsRow newLampsRow = new LampsRow("n");
            Assert.Empty(newLampsRow.LampList);
        }

        [Fact]
        public void Constructor_WhenCreatingNewLampsRowWith2Lamps_LampsRowHas2Lamps()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("notti");
            newLampsRow.AddLamp("giova");
            Assert.Equal(2, newLampsRow.LampList.Count);
        }

        //AddLamp tests
        [Fact]
        public void AddLamp_WhenAddingANewLamp_AddNewLamp()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("Ciao");
            Assert.IsType<Lamp>(newLampsRow.LampList[0]);
        }

        [Fact]
        public void AddLamp_WhenAddingNewLampWithEmptyOrNullName_ThrowArgumentException()
        {
            LampsRow newLampsRow = new LampsRow("n");
            Assert.Throws<ArgumentException>(() => newLampsRow.AddLamp(""));
            Assert.Throws<ArgumentException>(() => newLampsRow.AddLamp(" "));
        }

        [Fact]
        public void AddEcoLamp_WhenAddingNewEcoLampWithEmptyOrNullName_ThrowArgumentException()
        {
            LampsRow newLampsRow = new LampsRow("n");
            Assert.Throws<ArgumentException>(() => newLampsRow.AddLamp(""));
            Assert.Throws<ArgumentException>(() => newLampsRow.AddLamp(" "));
        }

        [Fact]
        public void AddEcoLamp_WhenAddingANewEcoLamp_AddNewEcoLamp()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddEcoLamp("Ciao");
            Assert.IsType<EcoLamp>(newLampsRow.LampList[0]);
        }

        [Fact]
        public void AddLamp_WhenAddingNewLamp_AddNewLamp()
        {
            LampsRow newLampsRow = new LampsRow("n");
            AbstractLamp lamp = new Lamp("ok");
            newLampsRow.AddLamp(lamp);
            Assert.IsType<Lamp>(newLampsRow.LampList[0]);
        }

        [Fact]
        public void AddLamp_WhenAddingNewEcoLamp_AddNewEcoLamp()
        {
            LampsRow newLampsRow = new LampsRow("n");
            AbstractLamp lamp = new EcoLamp("ok");
            newLampsRow.AddLamp(lamp);
            Assert.IsType<EcoLamp>(newLampsRow.LampList[0]);
        }

        [Fact]
        public void AddLampInPosition_WhenAddingNewLamp_AddNewLamp()
        {
            LampsRow newLampsRow = new LampsRow("nix");
            newLampsRow.AddEcoLamp("john");
            newLampsRow.AddEcoLamp("jake");
            AbstractLamp lampToTest = new Lamp("ok");
            newLampsRow.AddLampInPosition(lampToTest, 2);
            Assert.IsType<Lamp>(newLampsRow.LampList[2]);
            Assert.Equal("ok", newLampsRow.LampList[2].Name);
            Assert.Equal(3, newLampsRow.LampList.Count);
        }

        //Toggle tests
        [Fact]
        public void ToggleAll_WhenAllLampsAreOff_ToggleAllLampsToOn()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("ok");
            newLampsRow.AddLamp("okay");
            newLampsRow.Toggle();
            for (int i = 0; i < newLampsRow.LampList.Count; i++)
                Assert.Equal(DeviceStatus.On, newLampsRow.LampList[i].Status);
        }

        [Fact]
        public void ToggleAll_WhenAllLampsAreOn_ToggleAllLampsToOff()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("ok");
            newLampsRow.AddLamp("okay");
            newLampsRow.Toggle();
            newLampsRow.Toggle();
            for (int i = 0; i < newLampsRow.LampList.Count; i++)
                Assert.Equal(DeviceStatus.Off, newLampsRow.LampList[i].Status);
        }

        [Fact]
        public void ToggleWithId_WhenEnteringAnId_ToggleLampWithThatId()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giova");
            newLampsRow.Toggle(newLampsRow.LampList[0].Id);
            Assert.Equal(DeviceStatus.On, newLampsRow.LampList[0].Status);
        }

        [Fact]
        public void ToggleWithName_WhenEnteringAName_ToggleLampWithThatName()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giova");
            newLampsRow.Toggle("giova");
            Assert.Equal(DeviceStatus.On, newLampsRow.LampList[0].Status);
        }

        //SwitchOff tests
        [Fact]
        public void SwitchOffAll_WhenAllLampsAreOff_ThrowsAllArgumentExceptions()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            Assert.Throws<InvalidOperationException>(() => newLampsRow.SwitchOff());
        }

        [Fact]
        public void SwitchOffAll_WhenAllLampsAreOn_SwitchesAllLampsOff()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            newLampsRow.Toggle();
            newLampsRow.SwitchOff();
            for (int i = 0; i < newLampsRow.LampList.Count; i++)
                Assert.Equal(DeviceStatus.Off, newLampsRow.LampList[i].Status);
        }

        [Fact]
        public void SwitchOffWithId_WhenEnteringAnId_SwitchesOffLampWithThatId()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giova");
            newLampsRow.Toggle();
            newLampsRow.SwitchOff(newLampsRow.LampList[0].Id);
            Assert.Equal(DeviceStatus.Off, newLampsRow.LampList[0].Status);
        }

        [Fact]
        public void SwitchOffWithName_WhenEnteringAName_SwitchesOffLampWithThatName()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giova");
            newLampsRow.Toggle();
            newLampsRow.SwitchOff("giova");
            Assert.Equal(DeviceStatus.Off, newLampsRow.LampList[0].Status);
        }

        //SwitchOn tests
        [Fact]
        public void SwitchOnAll_WhenAllLampsAreOn_ThrowsAllArgumentExceptions()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            newLampsRow.Toggle();
            Assert.Throws<InvalidOperationException>(() => newLampsRow.SwitchOn());
        }

        [Fact]
        public void SwitchOnAll_WhenAllLampsAreOn_SwitchesAllLampsOn()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            newLampsRow.SwitchOn();
            for (int i = 0; i < newLampsRow.LampList.Count; i++)
                Assert.Equal(DeviceStatus.On, newLampsRow.LampList[i].Status);
        }

        [Fact]
        public void SwitchOnWithId_WhenEnteringAnId_SwitchesOnLampWithThatId()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giova");
            newLampsRow.SwitchOn(newLampsRow.LampList[0].Id);
            Assert.Equal(DeviceStatus.On, newLampsRow.LampList[0].Status);
        }

        [Fact]
        public void SwitchOnWithName_WhenEnteringAName_SwitchesOnLampWithThatName()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giova");
            newLampsRow.SwitchOn("giova");
            Assert.Equal(DeviceStatus.On, newLampsRow.LampList[0].Status);
        }

        //SetIntensity tests
        [Fact]
        public void SetIntesnityForAllLamps_WhenEnteringAnIntensity_SetsAllLampsAtThatIntensity()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForAllLamps(40);
            for (int i = 0; i < newLampsRow.LampList.Count; i++)
                Assert.Equal(40, newLampsRow.LampList[i].Intensity);
        }

        [Fact]
        public void SetIntesnityForLampInPosition_WhenEnteringAnIntensityAndPosition_SetsLampWithThatPositionAtThatIntensity()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForLamp(40, 2);
            Assert.Equal(40, newLampsRow.LampList[2].Intensity);
        }

        [Fact]
        public void SetIntesnityForLampByName_WhenEnteringAnIntensityAndName_SetsLampWithThatNameAtThatIntensity()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForLamp(40, "2");
            Assert.Equal(40, newLampsRow.LampList[2].Intensity);
        }

        [Fact]
        public void SetIntesnityForLampById_WhenEnteringAnIntensityAndAnId_SetsLampWithThatIdAtThatIntensity()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForLamp(40, newLampsRow.LampList[2].Id);
            Assert.Equal(40, newLampsRow.LampList[2].Intensity);
        }

        //RemoveLamp tests
        [Fact] //DA CONTROLLARE
        public void RemoveAllLamps_RemovesAllLamps()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("ciao");
            newLampsRow.AddEcoLamp("buongiorno");
            newLampsRow.AddLamp("buonasera");
            newLampsRow.RemoveAllLamps();
            Assert.Empty(newLampsRow.LampList);
        }

        [Fact]
        public void RemoveById_WhenEnteringAnId_RemovesLampWithThatId()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giova");
            newLampsRow.RemoveLamp(newLampsRow.LampList[0].Id);
            Assert.Empty(newLampsRow.LampList);
        }

        [Fact]
        public void RemoveByName_WhenEnteringAName_RemovesLampWithThatName()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giova");
            newLampsRow.RemoveLamp("giova");
            Assert.Empty(newLampsRow.LampList);
        }

        [Fact]
        public void RemoveInPosition_WhenEnteringAPosition_RemovesLampInThatPosition()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giova");
            newLampsRow.RemoveLampInPosition(0);
            Assert.Empty(newLampsRow.LampList);
        }

        [Fact]
        public void RemoveInPositionById_WhenEnteringAnIdAndAPosition_RemovesLampInThatPositionIfItHasTheSameId()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giova");
            newLampsRow.RemoveLampInPosition(newLampsRow.LampList[0].Id, 0);
            Assert.Empty(newLampsRow.LampList);
        }

        [Fact]
        public void RemoveInPositionByName_WhenEnteringANameAndAPosition_RemovesLampInThatPositionIfItHasTheSameName()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giova");
            newLampsRow.RemoveLampInPosition("giova", 0);
            Assert.Empty(newLampsRow.LampList);
        }

        //Dimmer tests
        [Fact]
        public void DimmerAllLamps_WhenEnteringAValue_DimmersAllLampsIntesnitiesWithThatValue()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForAllLamps(40);
            newLampsRow.DimmerAllLamps(10);
            for (int i = 0; i < newLampsRow.LampList.Count; i++)
                Assert.Equal(30, newLampsRow.LampList[i].Intensity);
        }

        [Fact]
        public void DimmerById_WhenEnteringAnIdAndAnAmount_DimmersLampWithThatIdWithThatAmount()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giova");
            newLampsRow.Toggle();
            newLampsRow.SetIntensityForAllLamps(40);
            newLampsRow.DimmerLamp(newLampsRow.LampList[0].Id, 10);
            Assert.Equal(30, newLampsRow.LampList[0].Intensity);
        }

        [Fact]
        public void DimmerWithName_WhenEnteringANameAndAnAmount_DimmersLampWithThatNameWiththatAmount()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giova");
            newLampsRow.Toggle();
            newLampsRow.SetIntensityForAllLamps(40);
            newLampsRow.DimmerLamp("giova", 10);
            Assert.Equal(30, newLampsRow.LampList[0].Intensity);
        }

        [Fact]
        public void DimmerLampInPosition_WhenEnteringAnAmountAndPosition_DimmersLampWithThatPositionWithThatValue()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForLamp(40, 2);
            newLampsRow.DimmerLampInPosition(2, 10);
            Assert.Equal(30, newLampsRow.LampList[2].Intensity);
        }

        [Fact]
        public void DimmerLampInPositionByName_WhenEnteringAnAmountAndANameAndAPosition_DimmersLampWithThatPositionWithThatValueIfItHasTheSameName()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForLamp(40, 2);
            newLampsRow.DimmerLampInPosition("2", 2, 10);
            Assert.Equal(30, newLampsRow.LampList[2].Intensity);
        }

        [Fact]
        public void DimmerLampInPositionById_WhenEnteringAnAmountAndAnIdAndAPosition_DimmersLampWithThatPositionWithThatValueIfItHasTheSameId()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForLamp(40, 2);
            newLampsRow.DimmerLampInPosition(newLampsRow.LampList[2].Id, 2, 10);
            Assert.Equal(30, newLampsRow.LampList[2].Intensity);
        }

        //Brighten tests
        [Fact]
        public void BrightenAllLamps_WhenEnteringAValue_BrightensAllLampsIntesnitiesWithThatValue()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForAllLamps(40);
            newLampsRow.BrightenAllLamps(10);
            for (int i = 0; i < newLampsRow.LampList.Count; i++)
                Assert.Equal(50, newLampsRow.LampList[i].Intensity);
        }

        [Fact]
        public void BrightenById_WhenEnteringAnIdAndAnAmount_BrightensLampWithThatIdWithThatAmount()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giova");
            newLampsRow.Toggle();
            newLampsRow.SetIntensityForAllLamps(40);
            newLampsRow.BrightenLamp(newLampsRow.LampList[0].Id, 10);
            Assert.Equal(50, newLampsRow.LampList[0].Intensity);
        }

        [Fact]
        public void BrightenWithName_WhenEnteringANameAndAnAmount_BrightensLampWithThatNameWiththatAmount()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giova");
            newLampsRow.Toggle();
            newLampsRow.SetIntensityForAllLamps(40);
            newLampsRow.BrightenLamp("giova", 10);
            Assert.Equal(50, newLampsRow.LampList[0].Intensity);
        }

        [Fact]
        public void BrightenLampInPosition_WhenEnteringAnAmountAndPosition_BrightensLampWithThatPositionWithThatValue()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForLamp(40, 2);
            newLampsRow.BrightenLampInPosition(2, 10);
            Assert.Equal(50, newLampsRow.LampList[2].Intensity);
        }

        [Fact]
        public void BrightenLampInPositionByName_WhenEnteringAnAmountAndANameAndAPosition_BrightensLampWithThatPositionWithThatValueIfItHasTheSameName()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForLamp(40, 2);
            newLampsRow.BrightenLampInPosition("2", 2, 10);
            Assert.Equal(50, newLampsRow.LampList[2].Intensity);
        }

        [Fact]
        public void BrightenLampInPositionById_WhenEnteringAnAmountAndAnIdAndAPosition_BrightensLampWithThatPositionWithThatValueIfItHasTheSameId()
        {
            LampsRow newLampsRow = new LampsRow("n");
            for (int i = 0; i < 5; i++)
                newLampsRow.AddLamp($"{i}");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForLamp(40, 2);
            newLampsRow.BrightenLampInPosition(newLampsRow.LampList[2].Id, 2, 10);
            Assert.Equal(50, newLampsRow.LampList[2].Intensity);
        }

        //FindLamp tests
        [Fact]
        public void FindLampWithMaxIntensity_WhenThirdLampHas70Intensity_ReturnsThirdLamp()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giorgini");
            newLampsRow.AddEcoLamp("pio");
            newLampsRow.AddLamp("gianluca");
            newLampsRow.AddLamp("pera");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForLamp(70, "gianluca");
            Assert.Equal(newLampsRow.LampList[2], newLampsRow.FindLampWithMaxIntensity());
        }

        [Fact]
        public void FindLampWithMinIntensity_WhenThirdLampHas0Intensity_ReturnsThirdLamp()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giorgini");
            newLampsRow.AddEcoLamp("pio");
            newLampsRow.AddLamp("gianluca");
            newLampsRow.AddLamp("pera");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForAllLamps(70);
            newLampsRow.SetIntensityForLamp(0, "gianluca");
            Assert.Equal(newLampsRow.LampList[2], newLampsRow.FindLampWithMinIntensity());
        }

        [Fact]
        public void FindLampByIntensityRange_WhenRangeIs40To50AndThirdAndSecondAreInThatRange_ReturnsThirdAndSecondLamp()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giorgini");
            newLampsRow.AddEcoLamp("pio");
            newLampsRow.AddLamp("gianluca");
            newLampsRow.AddLamp("pera");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForAllLamps(10);
            newLampsRow.SetIntensityForLamp(50, "gianluca");
            newLampsRow.SetIntensityForLamp(40, "pio");
            List<AbstractLamp> lampsInRange = [newLampsRow.LampList[1], newLampsRow.LampList[2]];
            Assert.Equal(lampsInRange, newLampsRow.FindLampsByIntensityRange(40, 50));
        }

        [Fact]
        public void FindAllOn_WhenOnlyThirdAndSecondLampAreOn_ReturnsThirdAndSecondLamp()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giorgini");
            newLampsRow.AddEcoLamp("pio");
            newLampsRow.AddLamp("gianluca");
            newLampsRow.AddLamp("pera");
            newLampsRow.SwitchOn("pio");
            newLampsRow.SwitchOn("gianluca");
            List<AbstractLamp> lampsThatAreOn = [newLampsRow.LampList[1], newLampsRow.LampList[2]];
            Assert.Equal(lampsThatAreOn, newLampsRow.FindAllOn());
        }

        [Fact]
        public void FindAllOff_WhenOnlyThirdAndSecondLampAreOff_ReturnsThirdAndSecondLamp()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giorgini");
            newLampsRow.AddEcoLamp("pio");
            newLampsRow.AddLamp("gianluca");
            newLampsRow.AddLamp("pera");
            newLampsRow.SwitchOn();
            newLampsRow.SwitchOff("pio");
            newLampsRow.SwitchOff("gianluca");
            List<AbstractLamp> lampsThatAreOn = [newLampsRow.LampList[1], newLampsRow.LampList[2]];
            Assert.Equal(lampsThatAreOn, newLampsRow.FindAllOff());
        }

        [Fact]
        public void FindLampById_WhenEnteringThirdLampId_ReturnsThirdLamp()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giorgini");
            newLampsRow.AddEcoLamp("pio");
            newLampsRow.AddLamp("gianluca");
            newLampsRow.AddLamp("pera");
            Assert.Equal(newLampsRow.LampList[2], newLampsRow.FindLampById(newLampsRow.LampList[2].Id));
        }

        [Fact]
        public void FindLampByName_WhenEnteringThirdLampName_ReturnsThirdLamp()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giorgini");
            newLampsRow.AddEcoLamp("pio");
            newLampsRow.AddLamp("gianluca");
            newLampsRow.AddLamp("pera");
            Assert.Equal(newLampsRow.LampList[2], newLampsRow.FindLampByName("gianluca"));
        }

        [Fact]
        public void SortByIntensity_WhenEnteringDescendingWithFalse_ReturnsListOfLampsSortedByIncreasingIntensities()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giorgini");
            newLampsRow.AddEcoLamp("pio");
            newLampsRow.AddLamp("gianluca");
            newLampsRow.AddEcoLamp("pera");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForLamp(3, "giorgini");
            newLampsRow.SetIntensityForLamp(5, "pio");
            newLampsRow.SetIntensityForLamp(2, "gianluca");
            newLampsRow.SetIntensityForLamp(4, "pera");
            List<AbstractLamp> sortedLamps = [newLampsRow.LampList[2], newLampsRow.LampList[0], newLampsRow.LampList[3], newLampsRow.LampList[1]];
            Assert.Equal(sortedLamps, newLampsRow.SortByIntensity(false));
        }

        [Fact]
        public void SortByIntensity_WhenEnteringDescendingWithTrue_ReturnsListOfLampsSortedByDescendingIntensities()
        {
            LampsRow newLampsRow = new LampsRow("n");
            newLampsRow.AddLamp("giorgini");
            newLampsRow.AddEcoLamp("pio");
            newLampsRow.AddLamp("gianluca");
            newLampsRow.AddEcoLamp("pera");
            newLampsRow.SwitchOn();
            newLampsRow.SetIntensityForLamp(3, "giorgini");
            newLampsRow.SetIntensityForLamp(5, "pio");
            newLampsRow.SetIntensityForLamp(2, "gianluca");
            newLampsRow.SetIntensityForLamp(4, "pera");
            List<AbstractLamp> sortedLamps = [newLampsRow.LampList[1], newLampsRow.LampList[3], newLampsRow.LampList[0], newLampsRow.LampList[2]];
            Assert.Equal(sortedLamps, newLampsRow.SortByIntensity(true));
        }
    }
}
