using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TrollProfile : MonoBehaviour, IStateful
{
    Animator anim;
    bool sitting;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    [YarnCommand("sit")]
    public void SetIdle()
    {
        anim.SetTrigger("SitDown");
        sitting = true;
    }

    public void Talk(bool value)
    {
        anim.SetBool("Talking", value);
    }

    public Dictionary<string, string> GetState()
    {
        return new Dictionary<string, string>()
        {
            { "sitting", sitting.ToString() }
        };
    }

    public void SetState(Dictionary<string, string> keyValuePairs)
    {
        if(bool.Parse(keyValuePairs["sitting"]))
        {
            SetIdle();
        }
    }
}
