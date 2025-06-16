class UnitCommander : IranianAgent
{
    private const AgentRank rank = AgentRank.UnitCommander;

    public UnitCommander(string name, int id) : base(name, id)
    {

        GenerateRandomVulnerabilities(rank);

    }
}