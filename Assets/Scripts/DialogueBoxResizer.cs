using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBoxResizer : MonoBehaviour
{
    Image textBox;
    [SerializeField] TextMeshPro textToMatch;

    void Start()
    {
        textBox = GetComponent<Image>();
    }

    void Update()
    {
        
    }
}
