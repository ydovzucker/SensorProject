using System.Runtime.CompilerServices;

class JuniorAgent:IranianAgent
{
    private const AgentRank rank = AgentRank.Junior;

    public JuniorAgent(string name, int id):base(name,id)
    {

        GenerateRandomVulnerabilities(rank);

    }

}