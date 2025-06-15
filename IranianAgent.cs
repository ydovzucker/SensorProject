using System.Collections.Generic;
using System.Security;

abstract class IranianAgent
{
    public readonly string name;
    public readonly int id;
    private readonly Sensor[] agentVulnerabilityList;
    private readonly Sensor[] attachedSensors;


    public IranianAgent(string name,int id)
    {
        this.name = name;
        this.id = id;
        

    }

}