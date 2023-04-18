using UnityEngine;

[RequireComponent(typeof(IStateful))]
public class SaveableObject : MonoBehaviour
{
    void Awake()
    {
        SaveManager.RegisterStatefulObject(GetComponent<IStateful>());
    }

    private void OnDestroy()
    {
        SaveManager.DeregisterStatefulObject(GetComponent<IStateful>());
    }

}
