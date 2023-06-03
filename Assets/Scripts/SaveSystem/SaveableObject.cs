using UnityEngine;

[RequireComponent(typeof(IStateful))]
public class SaveableObject : MonoBehaviour
{
    //Consider searching for SaveManager or making it static
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
