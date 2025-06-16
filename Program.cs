using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JuniorAgent agent1 = new JuniorAgent("Ali", 5678);
            Investigationmanager.Game(agent1);
        }
    }
}
