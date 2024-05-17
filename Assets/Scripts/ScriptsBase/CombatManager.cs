using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum CharacterStatus
{
    Waiting_Action,
    Action_Completed,
    Victory_Status_Completed,
    Next_Turn,
    DeadPlayer
}

public class CombatManager : MonoBehaviour
{
    public Fighter[] fighters;
    private int fighterIndex; //Se usa para saber el turno para realizar una accion

    private bool CombatActive;

    private CharacterStatus characStats;

    private Skill currentFighterSkill; 

    void Start()
    {
        LogPanel.Write("Match Started");

        foreach (var fighter in fighters)
        {
            fighter.combatManager = this;
        }

        this.characStats = CharacterStatus.Next_Turn;

        this.fighterIndex = -1;
        this.CombatActive = true;
        StartCoroutine(this.CombatLoop());
    }

    IEnumerator CombatLoop()
    {
        while (this.CombatActive) 
        {
            switch (this.characStats)
            {
                case CharacterStatus.Waiting_Action: 
                    yield return null;
                    break;

                case CharacterStatus.Action_Completed:
                    LogPanel.Write($"{this.fighters[this.fighterIndex].idName} uses {currentFighterSkill.skillName}");

                    yield return null;

                    currentFighterSkill.Run();

                    yield return new WaitForSeconds(currentFighterSkill.animationDuration);
                    this.characStats = CharacterStatus.Victory_Status_Completed;

                    currentFighterSkill = null;
                    break;

                case CharacterStatus.Victory_Status_Completed:
                    foreach (var fighter in fighters)
                    {
                        if (fighter.isAlive == false)
                        {
                            this.CombatActive = false;

                            LogPanel.Write("Victory");
                        }
                        else
                        {
                            this.characStats = CharacterStatus.Next_Turn; 
                        }                       
                    }
                    yield return null;
                    break;


                case CharacterStatus.Next_Turn:
                    yield return new WaitForSeconds(1f);
                    this.fighterIndex = (this.fighterIndex +1 ) % this.fighters.Length;

                    var currentTurn = this.fighters[this.fighterIndex];

                    LogPanel.Write($"{currentTurn.idName} has the turn");
                    currentTurn.InitTurn();

                    this.characStats = CharacterStatus.Waiting_Action;
                    break;
            }
        }
    }

    public Fighter EnemyFighter()
    {
        if (this.fighterIndex == 0)
        {
            return this.fighters[1];
        }
        else
        {
            return this.fighters[0];
        }
    }

    public void OnSkill(Skill skill)
    {
        this.currentFighterSkill = skill;
        this.characStats = CharacterStatus.Action_Completed;
    }
}
