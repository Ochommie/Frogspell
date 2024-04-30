using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    private fighter[] fighters;
    private int fighterIndex; //Se usa para saber el turno para realizar una accion

    void Start(){
        LogPanel.write("Defeat him.");

        this.fighterIndex = 0;
    }

}
