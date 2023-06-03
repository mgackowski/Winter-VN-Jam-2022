using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class ProgramExecution : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogue;
    [SerializeField] string dialogueStartNode;

    void OnCancel()
    {
        QuitGame();
    }

    void Start()
    {
        StartCoroutine(startDialogueNextFrame());
    }

    [YarnCommand("quitGame")]
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator startDialogueNextFrame()
    {
        yield return null;
        dialogue.StartDialogue(dialogueStartNode);
    }

}
