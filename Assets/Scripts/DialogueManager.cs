using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour

{

    [SerializeField] GameObject DialogueBox;
    [SerializeField] Text DialogueText;

    [SerializeField] int lettersPersecond;

    public AudioSource audioSOURCE;
    public AudioClip talk;
    public event Action OnShowDialogue;
    public event Action OnHideDialogue;

    public static DialogueManager Instance { get; private set; }

    //Exposing the dialogue manager to the world so that any class can use it
private void Awake()
{
        Instance = this;
}
    Dialogue dialogue;
    int currentLine = 0;
    bool isTyping;
    
    public IEnumerator ShowDialogue(Dialogue dialogue)
    {
        yield return new WaitForEndOfFrame();
        OnShowDialogue?.Invoke();

        this.dialogue = dialogue;
        DialogueBox.SetActive(true);
        StartCoroutine(TypeDialogue(dialogue.Lines[0]));
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isTyping)
        {
            ++currentLine;
            if(currentLine < dialogue.Lines.Count)
            {
                StartCoroutine(TypeDialogue(dialogue.Lines[currentLine]));

            }
            else
            {
                DialogueBox.SetActive(false);
                currentLine = 0;
                OnHideDialogue?.Invoke();
            }
        }
    }
    //This will help to show the sentences letter by letter
    public IEnumerator TypeDialogue(string line)
    {
        isTyping = true;
        DialogueText.text = "";
        foreach(var letter in line.ToCharArray())
        {
            audioSOURCE.PlayOneShot(talk);

            DialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPersecond);
        }
        isTyping = false;
    }
}