using Yarn.Unity;
using UnityEngine;

public class Traveler : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    [YarnCommand("walk")]
    public void Walk()
    {
        anim.SetTrigger("Walk");
    }

    [YarnCommand("tremble")]
    public void Shiver()
    {
        anim.SetTrigger("Shiver");
    }

    [YarnCommand("sitDown")]
    public void SitDown()
    {
        anim.SetTrigger("SitDown");
    }

    [YarnCommand("stand")]
    public void Stand()
    {
        anim.SetTrigger("Stand");
    }
}
