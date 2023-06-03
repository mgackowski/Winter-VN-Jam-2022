using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Yarn.Unity;

public static class SceneInfo
{
    public static List<GameObject> anchors { get; } = new List<GameObject>();
    public static List<CinemachineVirtualCamera> cameras { get; } = new List<CinemachineVirtualCamera>();
    public static List<GameStateObserver> gameStateObservers { get; } = new List<GameStateObserver>();
    public static GameState gameState { get; private set; } = GameState.Menu;

    public enum QualityLevel
    {
        High, Balanced
    }

    public enum GameState
    {
        Menu, InGame
    }

    public static void RegisterAnchor(GameObject anchor)
    {
        anchors.Add(anchor);
    }
    public static void RegisterCamera(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
    }
    public static void RegisterGameStateObserver(GameStateObserver observer)
    {
        gameStateObservers.Add(observer);
    }

    public static void DeregisterAnchor(GameObject anchor)
    {
        anchors.Remove(anchor);
    }
    public static void DeregisterCamera(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
    }

    public static void DeregisterGameStateObserver(GameStateObserver observer)
    {
        gameStateObservers.Remove(observer);
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

    public static void ChangeGameState(GameState newGameState)
    {
        gameState = newGameState;
        foreach(GameStateObserver observer in gameStateObservers)
        {
            observer.gameObject.SetActive(true);
            observer.ReactToGameState(newGameState);
        }
    }

    [YarnCommand("changeGameState")]
    public static void ChangeGameState(string newGameState)
    {
        ChangeGameState((GameState)System.Enum.Parse(typeof(GameState), newGameState, true));

    }



}
