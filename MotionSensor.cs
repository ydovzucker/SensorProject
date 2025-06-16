class MotionSensor : Sensor
{
    public override string NameOfSensor => "MotionSensor";

    public override bool Activate(bool isActive)
    {
        return isActive;
    }
}