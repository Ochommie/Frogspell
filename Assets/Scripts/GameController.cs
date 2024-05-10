using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum is an array that has different values

public enum GameState { FreeRoam, Dialogue, Battle}

public class GameController : MonoBehaviour
{
    //It exposes the player controller viarable on the inspector
    [SerializeField] PlayerMovement playerMovement;

    GameState state;

    private void Uptade()
    {
        if (state == GameState.FreeRoam)
        {
            //playerMovement.HandleUpdate();
           
        }

        else if (state == GameState.Dialogue)
        {

        }

        else if (state == GameState.Battle)
        {

        }
    }

    
}
