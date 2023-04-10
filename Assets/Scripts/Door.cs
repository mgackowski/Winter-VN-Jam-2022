using Yarn.Unity;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    [YarnCommand("open")]
    public void Open()
    {
        anim.SetTrigger("Open");
    }

    [YarnCommand("close")]
    public void Close()
    {
        anim.SetTrigger("Close");
    }

    [YarnCommand("forced")]
    public void SetForced(bool value)
    {
        anim.SetBool("Forced", value);
    }
}
