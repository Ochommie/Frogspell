using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardController : MonoBehaviour, INteractable
{
    int dialogIndex = 0;
    public bool hasPassed = false;
    [SerializeField] Dialogue[] dialog;

    public void Interact()

    {
        Debug.Log("Funciona");
        RoutineWraper();
        if (dialogIndex < dialog.Length-1)
        {
            dialogIndex++;
        }

    }
    
    private void RoutineWraper()
    {
        Debug.Log("Guardia");
        StartCoroutine(DialogueManager.Instance.ShowDialogue(dialog[dialogIndex]));
        if (!hasPassed)
        {
            SceneManager.LoadScene("Scenes/Quiz", LoadSceneMode.Additive);
        }
    }
}
