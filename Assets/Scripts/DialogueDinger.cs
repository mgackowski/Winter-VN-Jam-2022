using UnityEngine;
using Yarn.Unity;

public class DialogueDinger : MonoBehaviour
{
    [SerializeField] float narratorPitch = 1f;
    [SerializeField] float travellerPitch = 1.5f;
    [SerializeField] float trollPitch = 0.8f;

    [SerializeField] CustomLineView lineView;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayDing()
    {
        playCharacterDing(lineView.currentSpeaker);
    }

    void playCharacterDing(Character character)
    {
        switch(character)
        {
            case Character.Narrator:
                source.pitch = narratorPitch;
                break;
            case Character.Troll:
                source.pitch = trollPitch;
                break;
            case Character.Traveller:
                source.pitch = travellerPitch;
                break;
            default:
                source.pitch = 1f;
                break;
        }
        source.Play();
    }
}
