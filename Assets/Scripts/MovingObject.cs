using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class MovingObject : MonoBehaviour, IStateful
{
    string currentLocation;

    [YarnCommand("teleport")]
    public void Teleport(string location)
    {
        GameObject matchingAnchor = SceneInfo.anchors.Find(anchor => anchor.name.Equals(location, StringComparison.OrdinalIgnoreCase));
        if(matchingAnchor != null)
        {
            currentLocation = location;
            transform.parent = matchingAnchor.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
        else
        {
            Debug.LogErrorFormat("{0} was called to teleport to {1}, but the anchor was not found", gameObject.name, location);
        }
    }

    [YarnCommand("slide")]
    public void Slide(string location, float durationSeconds)
    {
        GameObject matchingAnchor = SceneInfo.anchors.Find(anchor => anchor.name.Equals(location, StringComparison.OrdinalIgnoreCase));
        if (matchingAnchor != null)
        {
            currentLocation = location;
            StartCoroutine(LerpToAnchor(matchingAnchor.transform, durationSeconds));
        }
        else
        {
            Debug.LogErrorFormat("{0} was called to slide to {1}, but the anchor was not found", gameObject.name, location);
        }
    }

    IEnumerator LerpToAnchor(Transform destination, float duration)
    {
        float timeElapsed = 0;
        Vector3 originalPosition = transform.position;
        Quaternion originalRotation = transform.rotation;

        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(originalPosition, destination.position, timeElapsed / duration);
            transform.rotation = Quaternion.Lerp(originalRotation, destination.rotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = destination.position;
        transform.rotation = destination.rotation;

        transform.parent = destination.transform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

    }

    public Dictionary<string, string> GetState()
    {
        return new Dictionary<string, string>()
        {
            { "location", currentLocation }
        };
    }

    public void SetState(Dictionary<string, string> keyValuePairs)
    {
        if(keyValuePairs.ContainsKey("location")) Teleport(keyValuePairs["location"]);
    }

    public string GetObjectName()
    {
        return gameObject.name;
    }
}
