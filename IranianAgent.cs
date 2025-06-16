using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Security;


public enum AgentRank
{
    Junior = 2,
    SectionChief = 4,
    UnitCommander = 6,
    HighCommander = 8

}

abstract class IranianAgent
{
    public static Sensor[] allSensors = Sensor.possibleSensors;
    public string Name { get; }
    public int Id { get; }

    public Sensor[] AgentVulnerabilityList { get; protected set; }
    public List<Sensor> AttachedSensors { get; } = new List<Sensor>();
    public Dictionary<Sensor, int> secretWeknesses { get; } = new Dictionary<Sensor, int>();

    public Dictionary<Sensor, int> AttachedSensorsDict { get; } = new Dictionary<Sensor, int>();
    public void AttachSensor(Sensor sensor)
    {
        AttachedSensors.Add(sensor);
        if (AttachedSensorsDict.ContainsKey(sensor))
        {
            AttachedSensorsDict[sensor]++;
            
        }
        else
        {
            AttachedSensorsDict[sensor] = 1;
        }
    }
    protected IranianAgent(string name, int id)
    {
        Name = name;
        Id = id;
    }

    protected void GenerateRandomVulnerabilities(AgentRank rank)
    {
        Random rnd = new Random();
        int count = (int)rank;

        AgentVulnerabilityList = new Sensor[count];

        for (int i = 0; i < count; i++)
        {
            Sensor chosen = allSensors[rnd.Next(allSensors.Length)];
            AgentVulnerabilityList[i] = chosen;

            if (secretWeknesses.ContainsKey(chosen))
                secretWeknesses[chosen]++;
            else
                secretWeknesses[chosen] = 1;
        }
    }
}
