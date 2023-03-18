using UnityEngine;
using Yarn.Unity;

public class TrollProfile : MonoBehaviour
{

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    [YarnCommand("sit")]
    public void SetIdle()
    {
        anim.SetTrigger("SitDown");
    }

    public void StartTalking()
    {
        anim.SetBool("Talking", true);
    }

    public void FinishTalking()
    {
        anim.SetBool("Talking", false);
    }

}
