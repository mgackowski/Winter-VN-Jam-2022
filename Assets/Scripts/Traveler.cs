using Yarn.Unity;
using UnityEngine;
using System.Collections.Generic;

public class Traveler : MonoBehaviour, IStateful
{
    private Animator anim;

    string lastAnimTrigger;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    [YarnCommand("walk")]
    public void Walk()
    {
        string triggerName = "Walk";
        anim.SetTrigger(triggerName);
        lastAnimTrigger = triggerName;
    }

    [YarnCommand("tremble")]
    public void Shiver()
    {
        string triggerName = "Shiver";
        anim.SetTrigger(triggerName);
        lastAnimTrigger = triggerName;
    }

    [YarnCommand("sitDown")]
    public void SitDown()
    {
        string triggerName = "SitDown";
        anim.SetTrigger(triggerName);
        lastAnimTrigger = triggerName;
    }

    [YarnCommand("stand")]
    public void Stand()
    {
        string triggerName = "Stand";
        anim.SetTrigger(triggerName);
        lastAnimTrigger = triggerName;
    }

    public Dictionary<string, string> GetState()
    {
        return new Dictionary<string, string>()
        {
            { "lastAnimTrigger", lastAnimTrigger }
        };
    }

    public void SetState(Dictionary<string, string> keyValuePairs)
    {
        if(keyValuePairs.ContainsKey("lastAnimTrigger"))
        {
            string savedTriggerName = keyValuePairs["lastAnimTrigger"];
            anim.SetTrigger(savedTriggerName);
            lastAnimTrigger = savedTriggerName;
        }

    }

    public string GetObjectName()
    {
        return gameObject.name;
    }
}
