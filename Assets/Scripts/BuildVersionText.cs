using UnityEngine;
using TMPro;

public class BuildVersionText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    void Start()
    {
        text.text = "Build version: " + Application.version;
    }

}
