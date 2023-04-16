using Yarn.Unity;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    [SerializeField] GameObject fireWood;
    [SerializeField] ParticleSystem fireParticles;
    [SerializeField] Light fireLight;

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
    }

}
