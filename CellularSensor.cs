class CellularSensor:Sensor
{
    public override string NameOfSensor => "CellularSensor";
    public override bool Activate(bool isActive)
    {
        return isActive;
    }
}