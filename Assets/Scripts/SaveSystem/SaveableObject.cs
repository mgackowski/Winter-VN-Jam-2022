using UnityEngine;

[RequireComponent(typeof(IStateful))]
public class SaveableObject : MonoBehaviour
{
    [SerializeField] SaveManager saveManagerSO;

    void Start()
    {
        IStateful[] statefulObjects = GetComponents<IStateful>();
        foreach (IStateful statefulObject in statefulObjects)
        {
            saveManagerSO.RegisterStatefulObject(statefulObject);
        }
    }

    private void OnDestroy()
    {
        IStateful[] statefulObjects = GetComponents<IStateful>();
        foreach (IStateful statefulObject in statefulObjects)
        {
            saveManagerSO.DeregisterStatefulObject(statefulObject);
        }
    }

}
