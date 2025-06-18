using System;
using System.Collections.Generic;
using System.Linq;
using Agent.Sensors;
using Agent.Agents;
using System.Threading;


namespace Agent.Manager
{
    class Investigationmanager
    {

        public static int EvaluateAgentGuess(IranianAgent agent)
        {
            int correctGuesses = 0;

            Dictionary<string, int> activeSensorsCount = new Dictionary<string, int>();

            foreach (Sensor sensor in agent.AttachedSensors)
            {
                try
                {
                    bool isActive = sensor.Activate(true);
                    if (isActive)
                    {
                        string sensorName = sensor.GetType().Name;
                        if (activeSensorsCount.ContainsKey(sensorName))
                            activeSensorsCount[sensorName]++;
                        else
                            activeSensorsCount[sensorName] = 1;
                    }
                    else
                    {
                        Console.WriteLine($"Sensor {sensor.GetType().Name} is broken and cannot be activated.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error activating sensor {sensor.GetType().Name}: {ex.Message}");
                }
            }

            foreach (var entry in activeSensorsCount)
            {
                string sensorName = entry.Key;
                int numberActive = entry.Value;

                if (agent.secretWeaknesses.ContainsKey(sensorName))
                {
                    int numberOfWeaknesses = agent.secretWeaknesses[sensorName];
                    correctGuesses += Math.Min(numberActive, numberOfWeaknesses);
                }
            }

            return correctGuesses;
        }
        public void ActivateSensor(Sensor sensor)
        {
            sensor.Activate(true);
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

            if (!valid || choice < 1 || choice > sensorTypes.Count)
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
        
        public void CheckActivatedThreeTimes()
        {

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
                Console.WriteLine("2. Exit");

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
                        Console.WriteLine($"Result: {correctGuesses}/{iranianAgent.AgentVulnerabilityArray.Length}");
                        break;


                    case 2:
                        Console.WriteLine("Exiting the program...");
                        return;

                    default:
                        Console.WriteLine("Please select a valid option (1, or 2).");
                        break;
                }
            }

            Console.WriteLine("Mission complete. All vulnerabilities discovered.");
        }
    }
}




   

