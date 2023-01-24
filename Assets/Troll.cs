using UnityEngine;
using Yarn.Unity;

public class Troll : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    [YarnCommand("idle")]
    public void SetIdle()
    {
        anim.SetTrigger("Calm");
    }

    [YarnCommand("agitate")]
    public void SetAgitate()
    {
        anim.SetTrigger("Agitate");
    }

    [YarnCommand("sleep")]
    public void SetSleep()
    {
        anim.SetTrigger("Sleep");
    }
}
