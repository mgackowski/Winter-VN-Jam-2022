using Yarn.Unity;
using UnityEngine;

public class TravelerBack : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
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

}
