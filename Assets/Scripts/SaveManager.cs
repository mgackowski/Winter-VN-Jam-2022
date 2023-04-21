using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "SOs/SaveManager")]
public class SaveManager : ScriptableObject
{
    [SerializeField] bool autosaveEnabled;
    [SerializeField] Dictionary<IStateful, Dictionary<string, string>> savedObjects = new Dictionary<IStateful, Dictionary<string, string>>();

    public void RegisterStatefulObject(IStateful caller)
    {
        //Dictionary<string, string> properties = caller.GetState();
        savedObjects.Add(caller, new Dictionary<string, string>());
    }

    public void DeregisterStatefulObject(IStateful caller)
    {
        savedObjects.Remove(caller);
    }

    public void Autosave()
    {
        if (!autosaveEnabled) return;
        UpdateAllStates();
    }

    public void UpdateAllStates()
    {
        List<IStateful> keys = new List<IStateful>(savedObjects.Keys);
        foreach (IStateful key in keys)
        {
            key.GetState().ToList().ForEach(x => savedObjects[key][x.Key] = x.Value);
        }
        Debug.Log("Saved state: " + savedObjects);
    }

    public void LoadFromSaved()
    {
        List<IStateful> keys = new List<IStateful>(savedObjects.Keys);
        foreach (IStateful key in keys)
        {
            key.SetState(savedObjects[key]);
        }
        Debug.Log("Loaded state: " + savedObjects);
    }

}