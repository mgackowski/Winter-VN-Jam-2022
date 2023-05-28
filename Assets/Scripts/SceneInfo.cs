using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Yarn.Unity;

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

    [YarnCommand("setQuality")]
    public static void SetQuality(string quality)
    {
        int balancedPreset = 0;
        int highPreset = 1;
        
        string[] names = QualitySettings.names;
        for(int i = 0; i < names.Length; i++)
        {
            if(names[i].Equals("Balanced"))
            {
                balancedPreset = i;
            }
            else if(names[i].Equals("High"))
            {
                highPreset = i;
            }
        }

        switch (quality.ToLower())
        {
            case "balanced":
                QualitySettings.SetQualityLevel(balancedPreset);
                break;
            case "high":
                QualitySettings.SetQualityLevel(highPreset);
                break;
            default:
                Debug.LogErrorFormat("Couldn't find quality preset {0}, check if the Yarn script calls the right parameter?", quality);
                break;
        }
    }

    public enum QualityLevel
    {
        High, Balanced
    }

}
