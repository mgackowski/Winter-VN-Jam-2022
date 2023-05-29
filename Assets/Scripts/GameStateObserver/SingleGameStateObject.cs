using UnityEngine;

public class SingleGameStateObject : GameStateObserver
{
    [SerializeField] SceneInfo.GameState enableOnState;

    protected override void Awake()
    {
        base.Awake();
        //Start objects off in an enabled state, otherwise they will never register
        if(SceneInfo.gameState != enableOnState)
        {
            gameObject.SetActive(false);
        }
    }

    public override void ReactToGameState(SceneInfo.GameState newState)
    {
        if(newState == enableOnState)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
