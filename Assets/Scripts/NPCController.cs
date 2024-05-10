using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, INteractable
{

    [SerializeField] Dialogue dialogue;


    public void Interact()

    {
        DialogueManager.Instance.ShowDialogue(dialogue);
    }
}
