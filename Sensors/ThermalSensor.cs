namespace Agent.Sensors
{
    class ThermalSensor : Sensor
    {
        public override string NameOfSensor => "ThermalSEnsor";
        public override bool Activate(bool isActive)
        {
            return isActive;
        }

    }
}