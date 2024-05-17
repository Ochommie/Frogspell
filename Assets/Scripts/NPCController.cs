using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, INteractable
{
   
    private int dialogIndex = 0;
    [SerializeField] Dialogue[] dialog;

    public void Interact()

    {

        StartCoroutine(DialogueManager.Instance.ShowDialogue(dialog[dialogIndex]));
        if (dialogIndex<=dialog.Length)
        dialogIndex++;
    }
}
