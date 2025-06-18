namespace Agent.Sensors
{ 
class HeatSensor:Sensor
{
    public override string NameOfSensor => "HeatSensor";
    public override bool Activate(bool isActive)
    {
        return isActive;
    }
}
}