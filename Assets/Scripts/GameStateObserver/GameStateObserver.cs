using UnityEngine;

public abstract class GameStateObserver : MonoBehaviour
{
    protected virtual void Awake()
    {
        SceneInfo.RegisterGameStateObserver(this);
    }

    public abstract void ReactToGameState(SceneInfo.GameState newState);
}
