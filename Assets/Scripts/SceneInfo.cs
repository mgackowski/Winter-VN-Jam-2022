using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class SceneInfo
{
    public static List<GameObject> anchors { get; } = new List<GameObject>();
    public static List<CinemachineVirtualCamera> cameras { get; } = new List<CinemachineVirtualCamera>();

    public static void RegisterAnchor(GameObject anchor)
    {
        anchors.Add(anchor);
    }
    public static void RegisterCamera(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
    }

    public static void DeregisterAnchor(GameObject anchor)
    {
        anchors.Remove(anchor);
    }
    public static void DeregisterCamera(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
    }

}
