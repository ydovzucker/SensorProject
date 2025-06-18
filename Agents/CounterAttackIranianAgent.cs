using System;
using System.Collections.Generic;
using Agent.Sensors;

namespace Agent.Agents
{
    class CounterAttackIranianAgent : IranianAgent
    {
        private const AgentRank rank = AgentRank.CounterAttackIranianAgent;
        private static Random rnd = new Random();
        int amountOfTurns = 0;
        public CounterAttackIranianAgent(string name, int id) : base(name, id)
        {

            GenerateRandomVulnerabilities(rank);

        }

        public void checkAmountOfTurns(){
            amountOfTurns += 1;

            if (amountOfTurns > 3)
            {
                if (AttachedSensors.Count > 0)
                {
                    int indexToRemove = rnd.Next(AttachedSensors.Count);
                    Sensor sensorToRemove = AttachedSensors[indexToRemove];
                    AttachedSensors.RemoveAt(indexToRemove);
                    string sensorName = sensorToRemove.GetType().Name;
                    if (AttachedSensorsDict.ContainsKey(sensorName)) // 9
                    {
                        AttachedSensorsDict[sensorName] -= 1;
                        if (AttachedSensorsDict[sensorName] <= 0) 
                        {
                            AttachedSensorsDict.Remove(sensorName); 
                        }
                    }
                    Console.WriteLine("Counterattack! Agent removed one of your sensors.");

                }
            }
            amountOfTurns = 0;
        }
    }
}