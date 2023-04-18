using Yarn.Unity;
using UnityEngine;
using System.Collections.Generic;

public class Fireplace : MonoBehaviour, IStateful
{
    [SerializeField] GameObject fireWood;
    [SerializeField] ParticleSystem fireParticles;
    [SerializeField] Light fireLight;

    bool burningState;

    public Dictionary<string, string> GetState()
    {
        return new Dictionary<string, string>()
        {
            { "burning", burningState.ToString() }
        };
    }

    [YarnCommand("burning")]
    public void setFireBurning(bool value)
    {
        if(value)
        {
            fireWood.SetActive(true);
            fireLight.enabled = true;
            fireParticles.Play();            
        }
        else
        {
            fireWood.SetActive(false);
            fireLight.enabled = false;
            fireParticles.Stop();

        }
        burningState = value;
    }

    public void SetState(Dictionary<string, string> keyValuePairs)
    {
        setFireBurning(bool.Parse(keyValuePairs["burning"]));
    }
}
