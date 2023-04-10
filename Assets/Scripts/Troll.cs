using UnityEngine;
using Yarn.Unity;
using System.Linq;

public class Troll : MonoBehaviour
{
    public Material trollMaterial;
    public Material trollEyeMaterial;
    public Material scaryTrollMaterial;
    public Material scaryTrollEyeMaterial;

    private Animator anim;
    private Renderer[] bodyRends;
    private Renderer[] pupilRends;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        bodyRends = GetComponentsInChildren<SpriteRenderer>();
        pupilRends = GetComponentsInChildren<SpriteRenderer>().Where(rend => rend.gameObject.CompareTag("Emissive")).ToArray();

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
    }
}
