class HighCommander : IranianAgent
{
    private const AgentRank rank = AgentRank.HighCommander;

    public HighCommander(string name, int id) : base(name, id)
    {

        GenerateRandomVulnerabilities(rank);

    }
}