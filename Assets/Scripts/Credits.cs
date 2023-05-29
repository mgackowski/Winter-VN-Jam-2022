using System.Collections;
using UnityEngine;
using TMPro;
using Yarn.Unity;

public class Credits : MonoBehaviour
{
    RectTransform rect;
    TextMeshProUGUI text;
    
    void Start()
    {
        rect = GetComponent<RectTransform>();
        text = GetComponent<TextMeshProUGUI>();
    }

    [YarnCommand("rollCredits")]
    public void RollCredits(float durationSeconds)
    {
        StartCoroutine(LerpCredits(durationSeconds));
    }

    IEnumerator LerpCredits(float duration)
    {
        float timeElapsed = 0;
        float textBoxHeight = text.textBounds.size.y;
        float canvasHeight = 0f; //TODO: Try not to hardwire
        Vector3 newPosition = rect.transform.position;


        while (timeElapsed < duration)
        {
            newPosition.y = Mathf.Lerp(0, textBoxHeight + canvasHeight, timeElapsed / duration);
            rect.transform.position = newPosition;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        newPosition.y = textBoxHeight + canvasHeight;
        rect.transform.position = newPosition;
    }

}
