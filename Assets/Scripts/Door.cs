using Yarn.Unity;
using UnityEngine;
using System.Collections.Generic;

public class Door : MonoBehaviour, IStateful
{
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    [YarnCommand("open")]
    public void Open()
    {
        anim.SetBool("Open", true);
    }

    [YarnCommand("close")]
    public void Close()
    {
        anim.SetBool("Open", false);
    }

    [YarnCommand("forced")]
    public void SetForced(bool value)
    {
        anim.SetBool("Forced", value);
    }

    public Dictionary<string, string> GetState()
    {
        return new Dictionary<string, string>()
        {
            { "open", anim.GetBool("Open").ToString() },
            { "forced", anim.GetBool("Forced").ToString() }
        };
    }

    public void SetState(Dictionary<string, string> keyValuePairs)
    {
        if(keyValuePairs["open"].Equals("True")) {
            Open();
        }
        else
        {
            Close();
        }
        SetForced(bool.Parse(keyValuePairs["forced"]));

    }

    public string GetObjectName()
    {
        return gameObject.name;
    }
}
