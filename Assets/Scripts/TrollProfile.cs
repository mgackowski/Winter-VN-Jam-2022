using UnityEngine;
using Yarn.Unity;

public class TrollProfile : MonoBehaviour
{

    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    [YarnCommand("sit")]
    public void SetIdle()
    {
        anim.SetTrigger("SitDown");
    }

    public void Talk(bool value)
    {
        anim.SetBool("Talking", value);
    }

}
