using System.Collections.Generic;

public static class SaveManager
{
    static Dictionary<IStateful, Dictionary<string, string>> savedObjects = new Dictionary<IStateful, Dictionary<string, string>>();

    public static void RegisterStatefulObject(IStateful caller)
    {
        Dictionary<string, string> properties = caller.GetState();
        savedObjects.Add(caller, properties);
    }

    public static void DeregisterStatefulObject(IStateful caller)
    {
        savedObjects.Remove(caller);
    }

}