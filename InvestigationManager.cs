using System;
using System.Collections.Generic;
using System.Linq;

class Investigationmanager
{

    public static int EvaluateAgentGuess(IranianAgent agent)
    {
        int correctGuesses = 0;

        foreach (KeyValuePair<string, int> entry in agent.AttachedSensorsDict)
        {
            string sensorName = entry.Key;
            int numberAttached = entry.Value;

            if (agent.secretWeaknesses.ContainsKey(sensorName))
            {
                int numberOfWeaknesses = agent.secretWeaknesses[sensorName];
                correctGuesses += numberOfWeaknesses;
            }
        }

        return correctGuesses;
    }


    public static Sensor GetSensorFromUserInput()
    {
        List<Type> sensorTypes = SensorFactory.GetPossibleSensors();
        Console.WriteLine("Choose a sensor to attach by entering its number:");
        for (int i = 0; i < sensorTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {sensorTypes[i].Name}");
        }
        
        int choice;
        bool valid = int.TryParse(Console.ReadLine(), out choice);

        if (!valid || choice < 1 || choice > sensorTypes.Count )
        {
            Console.WriteLine("Invalid choice. Try again.");
            return null;
        }
        Type selectedType = sensorTypes[choice - 1];

        try
        {
            object sensorObject = Activator.CreateInstance(selectedType);
            Sensor selectedSensor = (Sensor)sensorObject;
            return selectedSensor;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating sensor instance: {ex.Message}");
            return null;
        }
    }

    public static void Game(IranianAgent iranianAgent)
    {
        Console.WriteLine("=== WELCOME TO THE SURVEILLANCE PROGRAM ===");
        Console.WriteLine("Tracking agents via sensor network...");
        Console.WriteLine("Trust no one. Watch everyone.");

        int correctGuesses = 0;

        while (correctGuesses < iranianAgent.AgentVulnerabilityArray.Length)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Attach a sensor");
            Console.WriteLine("3. Exit");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid input. Please enter 1, 2 or 3.");
                continue;  
            }

            switch (choice)
            {
                case 1:
                    Sensor selectedSensor = GetSensorFromUserInput();
                    if (selectedSensor == null)
                    {
                        
                        continue;
                    }
                    iranianAgent.AttachSensor(selectedSensor);
                    correctGuesses = EvaluateAgentGuess(iranianAgent);
                    Console.WriteLine($"You guessed {correctGuesses} out of {iranianAgent.AgentVulnerabilityArray.Length} vulnerabilities for Agent {iranianAgent.Name}");
                    break;

                
                case 2:
                    Console.WriteLine("Exiting the program...");
                    return;  

                default:
                    Console.WriteLine("Please select a valid option (1, or 2).");
                    break;
            }
        }

        Console.WriteLine("✅ Mission complete. All vulnerabilities discovered.");
    }
}




   

