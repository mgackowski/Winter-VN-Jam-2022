using System;
using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class MovingObject : MonoBehaviour
{
    public Anchors anchors;

    void Start()
    {
        if(anchors.anchors.Count == 0)
        {
            anchors.anchors.AddRange(GameObject.FindGameObjectsWithTag("Anchor"));
        }
    }

    [YarnCommand("teleport")]
    public void Teleport(string location)
    {
        GameObject matchingAnchor = anchors.anchors.Find(anchor => anchor.name.Equals(location, StringComparison.OrdinalIgnoreCase));
        if(matchingAnchor != null)
        { 
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
        GameObject matchingAnchor = anchors.anchors.Find(anchor => anchor.name.Equals(location, StringComparison.OrdinalIgnoreCase));
        if (matchingAnchor != null)
        {
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

}
