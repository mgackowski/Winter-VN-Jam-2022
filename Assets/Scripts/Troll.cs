using UnityEngine;
using Yarn.Unity;
using System.Linq;
using System.Collections.Generic;

public class Troll : MonoBehaviour, IStateful
{
    public Material trollMaterial;
    public Material trollEyeMaterial;
    public Material scaryTrollMaterial;
    public Material scaryTrollEyeMaterial;

    private Animator anim;
    private Renderer[] bodyRends;
    private Renderer[] pupilRends;

    string lastAnimTrigger;
    bool darkened;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        bodyRends = GetComponentsInChildren<SpriteRenderer>();
        pupilRends = GetComponentsInChildren<SpriteRenderer>().Where(rend => rend.gameObject.CompareTag("Emissive")).ToArray();

    }

    [YarnCommand("idle")]
    public void SetIdle()
    {
        string triggerName = "Calm";
        anim.SetTrigger("triggerName");
        lastAnimTrigger = triggerName;
    }

    [YarnCommand("agitate")]
    public void SetAgitate()
    {
        string triggerName = "Agitate";
        anim.SetTrigger("triggerName");
        lastAnimTrigger = triggerName;
    }

    [YarnCommand("sleep")]
    public void SetSleep()
    {
        string triggerName = "Sleep";
        anim.SetTrigger("triggerName");
        lastAnimTrigger = triggerName;
    }

    [YarnCommand("darken")]
    public void Darken()
    {
        foreach (SpriteRenderer rend in bodyRends)
        {
            rend.material = scaryTrollMaterial;
        }
        foreach (SpriteRenderer rend in pupilRends)
        {
            rend.material = scaryTrollEyeMaterial;
        }
        darkened = true;
    }

    [YarnCommand("brighten")]
    public void Brighten()
    {
        foreach (SpriteRenderer rend in bodyRends)
        {
            rend.material = trollMaterial;
        }
        foreach (SpriteRenderer rend in pupilRends)
        {
            rend.material = trollEyeMaterial;
        }
        darkened = false;
    }

    public Dictionary<string, string> GetState()
    {
        return new Dictionary<string, string>()
        {
            { "lastAnimTrigger", lastAnimTrigger},
            { "darkened", darkened.ToString() },
        };
    }

    public void SetState(Dictionary<string, string> keyValuePairs)
    {
        if(keyValuePairs.ContainsKey("lastAnimTrigger"))
        {
            string lastTrigger = keyValuePairs["lastAnimTrigger"];
            anim.SetTrigger(lastTrigger);
            lastAnimTrigger = lastTrigger;
        }
        if (bool.Parse(keyValuePairs["darkened"]))
        {
            Darken();
        }
        else
        {
            Brighten();
        }
    }

    public string GetObjectName()
    {
        return gameObject.name;
    }
}
