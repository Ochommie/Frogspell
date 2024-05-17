using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum is an array that has different values

public enum GameState {FreeRoam, Dialog, Battle}

public class GameController : MonoBehaviour
{
    //It exposes the player controller viarable on the inspector
    [SerializeField] PlayerMovement playerMovement;

    GameState state;

    private void Start()
    {
        //Switches dialogue instances in the game
        DialogueManager.Instance.OnShowDialogue += () =>
        {
            state = GameState.Dialog;
        };
        DialogueManager.Instance.OnHideDialogue += () =>
        {
            if(state == GameState.Dialog)
            state = GameState.FreeRoam;
        };
    }
    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerMovement.HandleUpdate();
           
        }else if (state == GameState.Dialog)
        {
            DialogueManager.Instance.HandleUpdate();
        }else if (state == GameState.Battle)
        {

        }
    }

    
}
