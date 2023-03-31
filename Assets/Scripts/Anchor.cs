using UnityEngine;

public class Anchor : MonoBehaviour
{
    void Awake()
    {
        SceneInfo.RegisterAnchor(gameObject);
    }

    private void OnDestroy()
    {
        SceneInfo.DeregisterAnchor(gameObject);
    }


}
