using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] Image rect;

    [YarnCommand("fade")]
    public void Fade(string inOrOut, string blackOrWhite, float duration)
    {
        StopAllCoroutines();

        Color black = Color.black;
        Color white = Color.white;
        Color clearBlack = Color.clear;
        Color clearWhite = new Color(1, 1, 1, 0);
        Color from, to;

        if(blackOrWhite.ToLower().Equals("white"))
        {
            from = white;
            to = clearWhite;
        }
        else if (blackOrWhite.ToLower().Equals("black"))
        {
            from = black;
            to = clearBlack;
        }
        else
        {
            Debug.LogError("ScreenFader received incorrect colour parameter " + blackOrWhite);
            return;
        }

        switch (inOrOut.ToLower())
        {
            case "in":
                break;
            case "out":
                Color temp = from;
                from = to;
                to = temp;
                break;
            default:
                Debug.LogError("ScreenFader received incorrect in/out parameter " + blackOrWhite);
                return;
        }

        StartCoroutine(LerpToColour(from, to, duration));

    }

    IEnumerator LerpToColour(Color from, Color to, float duration)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            rect.color = Color.Lerp(from, to, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        rect.color = to;
    }


}
