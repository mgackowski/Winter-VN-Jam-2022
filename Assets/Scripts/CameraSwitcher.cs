using Cinemachine;
using UnityEngine;
using Yarn.Unity;

public class CameraSwitcher : MonoBehaviour
{
    CinemachineBrain brain;
    CinemachineBlendDefinition cut = new CinemachineBlendDefinition(CinemachineBlendDefinition.Style.Cut, 0f);
    CinemachineBlendDefinition easeInOut = new CinemachineBlendDefinition(CinemachineBlendDefinition.Style.EaseInOut, 3f);

    private void Start()
    {
        brain = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineBrain>();
    }


    [YarnCommand("cut")]
    public void Cut(CinemachineVirtualCamera target)
    {
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
        brain.m_DefaultBlend = easeInOut;

        //Yarn Spinner should be able to search by GameObject name
        foreach (CinemachineVirtualCamera cam in SceneInfo.cameras)
        {
            cam.Priority = 0;
        }
        target.Priority = 100;

    }
}