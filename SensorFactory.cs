using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class SensorFactory
{
    public static List<Type> GetPossibleSensors()
    {
        
            List<Type> allTypes = Assembly.GetExecutingAssembly().GetTypes().ToList();

        List<Type> sensorTypes = new List<Type>();

        foreach (Type t in allTypes)
        {

            if (typeof(Sensor).IsAssignableFrom(t) && !t.IsAbstract)
            {
                sensorTypes.Add(t);
            }
        }
        return sensorTypes;
    }
    }
