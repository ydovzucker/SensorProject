using System.Runtime.CompilerServices;

namespace Agent.Agents
{
    class JuniorAgent : IranianAgent
    {
        private const AgentRank rank = AgentRank.Junior;

        public JuniorAgent(string name, int id) : base(name, id)
        {

            GenerateRandomVulnerabilities(rank);

        }

    }
}