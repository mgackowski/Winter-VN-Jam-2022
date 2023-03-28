using Yarn.Unity;
using UnityEngine;

public class WoodHolder : MonoBehaviour
{
    public GameObject woodMore;
    public GameObject woodLess;

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
    }


}
