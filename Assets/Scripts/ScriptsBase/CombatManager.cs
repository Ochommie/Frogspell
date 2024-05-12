using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CombatManager : MonoBehaviour
{
    public Fighter[] fighters;
    private int fighterIndex; //Se usa para saber el turno para realizar una accion

    private bool CombatActive; 

    void Start()
    {
        LogPanel.Write("Attack!");
        this.fighterIndex = 0;
        this.CombatActive = true;
        StartCoroutine(this.CombatLoop());
    }

    IEnumerator CombatLoop()
    {
        while (this.CombatActive) 
        {
            yield return new WaitForSeconds(2f);

            Fighter currentTurn = this.fighters[this.fighterIndex];



            LogPanel.Write($"{currentTurn.idName} has the turn");
            currentTurn.InitTurn();

            this.fighterIndex = (this.fighterIndex + 1) % this.fighters.Length; 
        }
    }
}
