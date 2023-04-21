using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CameraSwitcher : MonoBehaviour, IStateful
{
    CinemachineBrain brain;
    CinemachineBlendDefinition cut = new CinemachineBlendDefinition(CinemachineBlendDefinition.Style.Cut, 0f);
    CinemachineBlendDefinition easeInOut = new CinemachineBlendDefinition(CinemachineBlendDefinition.Style.EaseInOut, 3f);

    CinemachineVirtualCamera currentCam = null;

    private void Start()
    {
        brain = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineBrain>();
    }


    [YarnCommand("cut")]
    public void Cut(CinemachineVirtualCamera target)
    {
        currentCam = target;
        brain.m_DefaultBlend = cut;
        

        //Yarn Spinner should be able to search by GameObject name
        foreach (CinemachineVirtualCamera cam in SceneInfo.cameras)
        {
            cam.Priority = 0;
        }
        target.Priority = 100;

    }

    [YarnCommand("dolly")]
    public void Dolly(CinemachineVirtualCamera target)
    {
        currentCam = target;
        brain.m_DefaultBlend = easeInOut;

        //Yarn Spinner should be able to search by GameObject name
        foreach (CinemachineVirtualCamera cam in SceneInfo.cameras)
        {
            cam.Priority = 0;
        }
        target.Priority = 100;

    }

    public Dictionary<string, string> GetState()
    {
        Dictionary<string, string> result = new Dictionary<string, string>();
        if (currentCam != null) result.Add("currentCam", currentCam.name);
        return result;
    }

    public void SetState(Dictionary<string, string> keyValuePairs)
    {
        Cut(SceneInfo.cameras.Find(cam => cam.name.Equals(keyValuePairs["currentCam"])));
    }
}