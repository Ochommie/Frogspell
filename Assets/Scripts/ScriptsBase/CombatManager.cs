using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum CharacterStatus
{
    Waiting_Action,
    Action_Completed,
    Victory_Status_Completed, //Estados de combate    
    Next_Turn
}

public class CombatManager : MonoBehaviour
{
    public Fighter[] fighters;
    public Fighter[] playerTeam;
    public Fighter[] enemyTeam;


    private int fighterIndex; //Se usa para saber el turno para realizar una accion

    private bool CombatActive;

    private CharacterStatus characStats; //Los estados se leeran con CharacterStatus

    private Skill currentFighterSkill; //Campo que espara a que termine la animacion del ataque


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
                    bool PlayerON = false;
                    foreach (var fighter in this.playerTeam)
                    {
                        PlayerON |= fighter.isAlive;
                    }

                    bool EnemyON = false;
                    foreach (var fighter in this.enemyTeam)
                    {
                        EnemyON |= fighter.isAlive;
                    }

                    bool victory = EnemyON == false;
                    bool lose = PlayerON == false;

                    if (victory)
                    {
                        LogPanel.Write("You win");
                        this.CombatActive = false;
                        new WaitForSeconds(1f);
                        SceneManager.LoadScene("SampleScene");
                    }
                    else if (lose)
                    {
                        this.CombatActive = false;
                        SceneManager.LoadScene("Game Over");

                    }

                    if (this.CombatActive)
                    {
                        this.characStats = CharacterStatus.Next_Turn;
                    }
                    yield return null;
                    break;

                                     

                case CharacterStatus.Next_Turn:
                    yield return new WaitForSeconds(.5f);
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
