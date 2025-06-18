using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Security;
using Agent.Sensors;

namespace Agent.Agents
{

    public enum AgentRank
    {
        Junior = 2,
        SectionChief = 4,
        CounterAttackIranianAgent = 4,
        UnitCommander = 6,
        HighCommander = 8
        

    }

    abstract class IranianAgent
    {
        public static List<Type> allSensors = SensorFactory.GetPossibleSensors();
        public string Name { get; }
        public int Id { get; }

        public Sensor[] AgentVulnerabilityArray { get; protected set; }
        public  List<Sensor> AttachedSensors { get; } = new List<Sensor>();
        public Dictionary<string, int> secretWeaknesses { get; } = new Dictionary<string, int>();
        public  Dictionary<string, int> AttachedSensorsDict { get; } = new Dictionary<string, int>();
        public void AttachSensor(Sensor sensor)
        {
            AttachedSensors.Add(sensor);
            string sensorName = sensor.GetType().Name;

            if (AttachedSensorsDict.ContainsKey(sensorName))
                AttachedSensorsDict[sensorName]++;
            else
                AttachedSensorsDict[sensorName] = 1;
        }
        protected IranianAgent(string name, int id)
        {
            Name = name;
            Id = id;
        }
        private static Random rnd = new Random();

        protected void GenerateRandomVulnerabilities(AgentRank rank)
        {
            int count = (int)rank;
            AgentVulnerabilityArray = new Sensor[count];

            for (int i = 0; i < count; i++)
            {
                Type randomSensorType = allSensors[rnd.Next(allSensors.Count)];
                Sensor sensor = (Sensor)Activator.CreateInstance(randomSensorType);
                AgentVulnerabilityArray[i] = sensor;

                string sensorName = sensor.GetType().Name;

                if (secretWeaknesses.ContainsKey(sensorName))
                    secretWeaknesses[sensorName]++;
                else
                    secretWeaknesses[sensorName] = 1;
            }
        }
    }
}
