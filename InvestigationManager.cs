using System;
using System.Collections.Generic;
using System.Linq;

class Investigationmanager
{

    public static int EvaluateAgentGuess(IranianAgent agent)
    {
        int correctGuesses = 0;


        
        
            foreach (KeyValuePair<Sensor, int> entry in agent.AttachedSensorsDict)
            {
                Sensor currSensor = entry.Key;
                int numberAttached = entry.Value;
                if (agent.secretWeknesses.ContainsKey(currSensor))
                {
                    int numberOfweeknesse = agent.secretWeknesses[currSensor];
                    correctGuesses += numberOfweeknesse;
                }
            }
            return correctGuesses;

            

     }
    











    public static Sensor GetSensorFromUserInput()
    {
        Console.WriteLine("Choose a sensor to attach by entering its number:");
        Console.WriteLine("1. MotionSensor");
        Console.WriteLine("2. HeatSensor");
        Console.WriteLine("3. CellularSensor");
        Console.WriteLine("4. ThermalSensor");

        int choice;
        bool valid = int.TryParse(Console.ReadLine(), out choice);

        if (!valid || choice < 1 || choice > 4)
        {
            Console.WriteLine("Invalid choice. Try again.");
            return null;
        }

        switch (choice)
        {
            case 1: return new MotionSensor();
            case 2: return new HeatSensor();
            case 3: return new CellularSensor();
            case 4: return new ThermalSensor();
            default: return null;
        }
    }

    public static void Game(IranianAgent iranianAgent)
    {
        Console.WriteLine("=== WELCOME TO THE SURVEILLANCE PROGRAM ===");
        Console.WriteLine("Tracking agents via sensor network...");
        Console.WriteLine("Trust no one. Watch everyone.");

        Sensor selectedSensor = GetSensorFromUserInput();
        iranianAgent.AttachSensor(selectedSensor);
        int correctGuesses = 0;
        while (correctGuesses < IranianAgent.possibleSensors.Count())
        {
             correctGuesses = EvaluateAgentGuess(iranianAgent);

            Console.WriteLine($"you  guessed {correctGuesses} out of {iranianAgent.AgentVulnerabilityList.Length} vulnerabilities for Agent {iranianAgent.Name} ");
        }
            

    }
}




   

