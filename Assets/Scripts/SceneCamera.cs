using Cinemachine;
using UnityEngine;

public class SceneCamera : MonoBehaviour
{
    void Awake()
    {
        SceneInfo.RegisterCamera(GetComponent<CinemachineVirtualCamera>());
    }

    private void OnDestroy()
    {
        SceneInfo.DeregisterCamera(GetComponent<CinemachineVirtualCamera>());
    }

}
