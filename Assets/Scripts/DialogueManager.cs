using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] GameObject DialogueBox;
    [SerializeField] Text DialogueText;

    [SerializeField] int lettersPersecond;

    public static DialogueManager Instance { get; private set; }

    //Exposing the dialogue manager to the world so that any class can use it
private void Awake()
{
        Instance = this;
}

    public void ShowDialogue(Dialogue dialogue)
    {
        DialogueBox.SetActive(true);
        StartCoroutine(TypeDialogue(dialogue.Lines[0]));
    }

    //This will help to show the sentences letter by letter
    public IEnumerator TypeDialogue(string line)
    {
        DialogueText.text = "";
        foreach(var letter in line.ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPersecond);
        }
    }
}