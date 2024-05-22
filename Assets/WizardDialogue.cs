using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WizardDialogue : MonoBehaviour, INteractable
{
    int dialogIndex = 0;
    [SerializeField] Dialogue[] dialog;

    public void Interact()

    {
        Debug.Log("Funciona");
        RoutineWraper();
        if (dialogIndex <= dialog.Length)
        {
            dialogIndex++;
        }

    }
    private void RoutineWraper()
    {
        Debug.Log("Mago");
        StartCoroutine(DialogueManager.Instance.ShowDialogue(dialog[dialogIndex]));
        if (dialogIndex == 0)
        {
            SceneManager.LoadScene("Scenes/CombatScene", LoadSceneMode.Single);
        }
    }
}

