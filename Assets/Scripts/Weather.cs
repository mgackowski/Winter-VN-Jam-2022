using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Weather : MonoBehaviour, IStateful
{
    [SerializeField] GameObject sunlight;
    [SerializeField] GameObject lightSnow;
    [SerializeField] GameObject heavySnow;
    [SerializeField] GameObject dustStorm;
    [SerializeField] float heavyFogLevel = 0.12f;
    [SerializeField] float lightFogLevel = 0.005f;

    string currentWeather = "heavySnow";
    float currentTime = 23f;

    [YarnCommand("setWeather")]
    public void SetWeather(string weatherType)
    {
        switch (weatherType.ToUpper())
        {
            case "HEAVYSNOW":
                heavySnow.SetActive(true);
                dustStorm.SetActive(true);
                lightSnow.SetActive(false);
                RenderSettings.fogDensity = heavyFogLevel;
                break;
            case "LIGHTSNOW":
                heavySnow.SetActive(false);
                dustStorm.SetActive(false);
                lightSnow.SetActive(true);
                RenderSettings.fogDensity = lightFogLevel;
                break;
            case "CLEAR":
                heavySnow.SetActive(false);
                dustStorm.SetActive(false);
                lightSnow.SetActive(false);
                RenderSettings.fogDensity = lightFogLevel;
                break;
            default:
                Debug.LogError("Incorrect weather parameter provided.");
                break;
        }
        currentWeather = weatherType;

    }

    [YarnCommand("setTimeOfDay")]
    public void SetTime(float hourOfDay)
    {
        //TODO: Current solution uses a hardwired y component   
        
        sunlight.transform.rotation = Quaternion.Euler((hourOfDay - 6f) * 15f, -6.68f, 0f);

        //Vector3 currentRotation = sunlight.transform.eulerAngles;
        //currentRotation.x = (hourOfDay - 6f) * 15f;
        //sunlight.transform.eulerAngles = currentRotation;
        // 6am is 0 degrees
        // 12pm is 90 degrees

        currentTime = hourOfDay;
    }

    public Dictionary<string, string> GetState()
    {
        return new Dictionary<string, string>()
        {
            { "weather", currentWeather },
            { "time", currentTime.ToString() }
        };
    }

    public void SetState(Dictionary<string, string> keyValuePairs)
    {
        if (keyValuePairs.ContainsKey("weather")) SetWeather(keyValuePairs["weather"]);
        if (keyValuePairs.ContainsKey("time")) SetTime(float.Parse(keyValuePairs["time"]));
    }
}