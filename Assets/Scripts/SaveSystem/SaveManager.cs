using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Yarn.Unity;

[CreateAssetMenu(menuName = "SOs/SaveManager")]
public class SaveManager : ScriptableObject
{
    [SerializeField] DialogueRunner dialogueRunner;

    [SerializeField] bool autosaveEnabled;
    [SerializeField] Dictionary<IStateful, Dictionary<string, string>> inMemorySave = new Dictionary<IStateful, Dictionary<string, string>>();

    [SerializeField] Save currentPersistentSave;
    [SerializeField] List<Save> allPersistentSaves;

    public void RegisterStatefulObject(IStateful caller)
    {
        inMemorySave.Add(caller, new Dictionary<string, string>());
    }

    public void DeregisterStatefulObject(IStateful caller)
    {
        inMemorySave.Remove(caller);
    }

    public void Autosave()
    {
        if (!autosaveEnabled) return;
        UpdateAllStates();
    }

    public void UpdateAllStates()
    {
        List<IStateful> keys = new List<IStateful>(inMemorySave.Keys);
        foreach (IStateful key in keys)
        {
            key.GetState().ToList().ForEach(x => inMemorySave[key][x.Key] = x.Value);
        }
        Debug.Log("Saved state: " + inMemorySave);

        saveIntoCurrentPersistentSave();
    }

    public void LoadFromSaved()
    {
        loadFromCurrentPersistentSave();

        List<IStateful> keys = new List<IStateful>(inMemorySave.Keys);
        foreach (IStateful key in keys)
        {
            key.SetState(inMemorySave[key]);
        }
        Debug.Log("Loaded state: " + inMemorySave);
    }

    void loadFromCurrentPersistentSave()
    {
        inMemorySave.Clear();

        List<Save.ObjectPropertiesPair> opps = new List<Save.ObjectPropertiesPair>(currentPersistentSave.savedObjects);
        foreach (Save.ObjectPropertiesPair opp in opps)
        {
            foreach(IStateful component in 
                GameObject.Find(opp.statefulObjectName)
                .GetComponents<IStateful>()
                .Where(x => x.GetType().Name
                .Equals(opp.statefulComponentName)))
            {

                Dictionary<string, string> properties = new Dictionary<string, string>();
                foreach(Save.ObjectPropertiesPair.SerializableTuple tuple in opp.properties)
                {
                    properties.Add(tuple.key, tuple.value);
                }
                inMemorySave.TryAdd(component, properties);
            }
        }

        DialogueRunner dialogue = GameObject.FindGameObjectWithTag("DialogueSystem").GetComponent<DialogueRunner>();
        dialogue.Stop();
        dialogue.StartDialogue(currentPersistentSave.yarnNodeName);
    }

    void saveIntoCurrentPersistentSave()
    {
        currentPersistentSave.yarnNodeName = GameObject.FindGameObjectWithTag("DialogueSystem").GetComponent<DialogueRunner>().CurrentNodeName;

        currentPersistentSave.savedObjects.Clear();
        foreach(IStateful statefulObject in inMemorySave.Keys)
        {
            Save.ObjectPropertiesPair opp = new Save.ObjectPropertiesPair();
            opp.statefulObjectName = statefulObject.GetObjectName();
            opp.statefulComponentName = statefulObject.GetType().Name;
            opp.properties = new List<Save.ObjectPropertiesPair.SerializableTuple>();

            foreach (var stringPair in inMemorySave[statefulObject])
            {
                Save.ObjectPropertiesPair.SerializableTuple tuple = new Save.ObjectPropertiesPair.SerializableTuple();
                tuple.key = stringPair.Key;
                tuple.value = stringPair.Value;
                opp.properties.Add(tuple);
            }
            currentPersistentSave.savedObjects.Add(opp);
        }

    }

}