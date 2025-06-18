using System;

namespace Agent.Sensors
{
    class PulseSensor : Sensor
    {
        public override string NameOfSensor => "PulseSensor";

        private int activateCount = 0;
        private const int maxActivations = 3;

        public override bool Activate(bool isActive)
        {
            if (!isActive) return false;

            activateCount++;

            if (activateCount > maxActivations)
            {
                Console.WriteLine($"{NameOfSensor} is broken after {maxActivations} activations.");
                return false; 
            }

            return true; 
        }
    }
}
