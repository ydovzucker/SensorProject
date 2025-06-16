abstract class Sensor
{
    public abstract string NameOfSensor { get; }

    public virtual bool Activate(bool isActive)
    {
        return isActive;
    }
}