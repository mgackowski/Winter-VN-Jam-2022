using Yarn.Unity;
using UnityEngine;
using System.Collections.Generic;

public class TravelerBack : MonoBehaviour, IStateful
{
    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    [YarnCommand("shiver")]
    public void Shiver(bool value)
    {
        anim.SetBool("Shivering", value);
    }

    [YarnCommand("eyes")]
    public void ChangeEyelids(string state)
    {
        switch (state) {
            case "open":
                anim.SetBool("EyesClosed", false);
                anim.SetBool("EyesHalfClosed", false);
                break;
            case "halfClosed":
                anim.SetBool("EyesClosed", false);
                anim.SetBool("EyesHalfClosed", true);
                break;
            case "closed":
                anim.SetBool("EyesClosed", true);
                anim.SetBool("EyesHalfClosed", false);
                break;
        }
    }
    public void Talk(bool value)
    {
        anim.SetBool("Talking", value);
    }

    public Dictionary<string, string> GetState()
    {
        return new Dictionary<string, string>()
        {
            { "shivering", anim.GetBool("Shivering").ToString() },
            { "eyesClosed", anim.GetBool("EyesClosed").ToString() },
            { "eyesHalfClosed", anim.GetBool("EyesHalfClosed").ToString() },
        };
    }

    public void SetState(Dictionary<string, string> keyValuePairs)
    {
        anim.SetBool("Shivering", bool.Parse(keyValuePairs["shivering"]));
        anim.SetBool("EyesClosed", bool.Parse(keyValuePairs["eyesClosed"]));
        anim.SetBool("EyesHalfClosed", bool.Parse(keyValuePairs["eyesHalfClosed"]));
    }

    public string GetObjectName()
    {
        return gameObject.name;
    }
}
