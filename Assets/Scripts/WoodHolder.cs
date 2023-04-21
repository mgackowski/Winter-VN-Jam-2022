using Yarn.Unity;
using UnityEngine;
using System.Collections.Generic;

public class WoodHolder : MonoBehaviour, IStateful
{
    public GameObject woodMore;
    public GameObject woodLess;

    string currentAmount;

    public Dictionary<string, string> GetState()
    {
        return new Dictionary<string, string>()
        {
            { "amount", currentAmount }
        };
    }

    [YarnCommand("setAmount")]
    public void SetAmount(string woodAmount)
    {
        switch(woodAmount.ToLower())
        {
            case "full":
                woodMore.SetActive(true);
                woodLess.SetActive(true);
                break;
            case "half":
                woodMore.SetActive(false);
                woodLess.SetActive(true);
                break;
            case "none":
                woodMore.SetActive(false);
                woodLess.SetActive(false);
                break;
        }
        currentAmount = woodAmount;
    }

    public void SetState(Dictionary<string, string> keyValuePairs)
    {
        SetAmount(keyValuePairs["amount"]);
    }

    public string GetObjectName()
    {
        return gameObject.name;
    }
}
