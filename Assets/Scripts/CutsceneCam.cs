using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CutsceneCam : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    Animator anim;

    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        anim = GetComponent<Animator>();
    }

    [YarnCommand("playCutscene")]
    public void PlayCutscene(string name)
    {
        foreach (CinemachineVirtualCamera sceneCam in SceneInfo.cameras)
        {
            sceneCam.Priority = 0;
        }
        cam.Priority = 100;
        anim.StopPlayback();
        anim.ResetTrigger(name);
        anim.SetTrigger(name);
    }

    [YarnCommand("shake")]
    public void SetShake(bool enabled)
    {
        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().enabled = enabled;
    }

}
