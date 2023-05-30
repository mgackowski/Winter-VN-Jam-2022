using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

[RequireComponent(typeof(AudioSource))]
public class AudioSelector : MonoBehaviour, IStateful
{
    [SerializeField] AudioClip nullClip;
    [SerializeField] List<AudioClip> clips;

    AudioSource source;
    AudioLowPassFilter lowPassFilter;

    float preferredVolume;
    float currentLowPassValue = 1f;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        if (source.clip == null)
        {
            source.clip = nullClip;
            Debug.LogWarningFormat("Audio clip not found for object {}, replacing with empty sound clip.", gameObject.name);
        }
        preferredVolume = source.volume;
        lowPassFilter = GetComponent<AudioLowPassFilter>();
        if (lowPassFilter != null)
        {
            currentLowPassValue = lowPassFilter.cutoffFrequency;
        }
    }

    public void Play(string clipName)
    {
        foreach (AudioClip clip in clips) {
            if (clip.name.Equals(clipName)) {
                source.clip = clip;
                source.Play();
                return;
            }
        }
        source.clip = nullClip;
        source.Play();
    }

    [YarnCommand("fadeInAudio")]
    public void FadeIn(float durationSeconds)
    {
        StartCoroutine(fade(0f, preferredVolume, durationSeconds, false));
    }

    [YarnCommand("fadeOutAudio")]
    public void FadeOut(float durationSeconds, bool pauseWhenVolumeZero)
    {
        StartCoroutine(fade(source.volume, 0f, durationSeconds, pauseWhenVolumeZero));
    }

    [YarnCommand("setLowPass")]
    public void SetLowPass(float lowPassTarget, float transitionDuration)
    {
        StartCoroutine(setLowPass(lowPassTarget, transitionDuration));
    }

    IEnumerator setLowPass(float lowPassTarget, float transitionDuration)
    {
        if (lowPassFilter == null)
        {
            Debug.LogError("Tried to change low pass effect on audio clip, but no low pass filter component found.");
            yield break;
        }
        currentLowPassValue = lowPassTarget;
        float currentLowPass = lowPassFilter.cutoffFrequency;
        float timeElapsed = 0f;

        while(timeElapsed < transitionDuration)
        {
            lowPassFilter.cutoffFrequency = Mathf.Lerp(currentLowPass, lowPassTarget, timeElapsed / transitionDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        lowPassFilter.cutoffFrequency = lowPassTarget;
    }

    IEnumerator fade(float startValue, float targetValue, float duration, bool pause)
    {
        source.UnPause();
        float timeElapsed = 0f;
        while(timeElapsed < duration)
        {
            source.volume = Mathf.Lerp(startValue, targetValue, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        source.volume = targetValue;
        if(pause & targetValue == 0)
        {
            source.Pause();
        }
    }

    public string GetObjectName()
    {
        return gameObject.name;
    }

    public Dictionary<string, string> GetState()
    {
        return new Dictionary<string, string>()
        {
            { "currentClip", source.clip.ToString() },
            { "clipPlaying", source.isPlaying.ToString() },
            { "currentVolume", source.volume.ToString() },
            { "currentLowPass", currentLowPassValue.ToString() }
        };
    }

    public void SetState(Dictionary<string, string> keyValuePairs)
    {
        //TODO: no safety checks whatsoever
        if(bool.Parse(keyValuePairs["clipPlaying"])) {
            Play(keyValuePairs["clipPlaying"]);
        }
        source.volume = float.Parse(keyValuePairs["currentVolume"]);
        SetLowPass(float.Parse(keyValuePairs["currentLowPass"]), 0f);
    }


}
