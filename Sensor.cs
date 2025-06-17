abstract class Sensor
{
    public abstract string NameOfSensor { get; }
    //public static readonly Sensor[] possibleSensors = new Sensor[]
    //{
    //    new MotionSensor(),
    //    new HeatSensor(),
    //    new CellularSensor(),
    //    new ThermalSensor()
    //};


    public virtual bool Activate(bool isActive)
    {
        return isActive;
    }
}