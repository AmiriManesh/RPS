using System;
using System.Collections.Generic;

public class HandManager
{
    // Dictionary to store registered hands (type name -> type)
    private Dictionary<string, Type> handRegistry = new Dictionary<string, Type>();

    // Register a hand type dynamically
    public void RegisterHand(string name, Type handType)
    {
        if (!typeof(IHand).IsAssignableFrom(handType))
        {
            throw new ArgumentException($"{handType} does not implement IHand interface.");
        }

        handRegistry[name] = handType;
    }

    // Create an instance of the registered hand dynamically
    public IHand CreateHand(string name)
    {
        if (handRegistry.ContainsKey(name))
        {
            return (IHand)Activator.CreateInstance(handRegistry[name]);
        }
        throw new ArgumentException($"Hand type '{name}' is not registered.");
    }

    // Get all registered hand names in a list
    public List<string> GetRegisteredHandNames()
    {
        return new List<string>(handRegistry.Keys);
    }
}