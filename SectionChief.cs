class SectionChief:IranianAgent
{
    private const AgentRank rank = AgentRank.SectionChief;

    public SectionChief(string name, int id) : base(name, id)
    {

        GenerateRandomVulnerabilities(rank);

    }
}