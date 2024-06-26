using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFighter : Fighter
{

    [Header("TMP")]
    public PlayPanel skillPanel; 

    void Awake()
    {
        this.stats = new Stats(20, 100, 50, 60,20); //Level, maxHealth, attack, deffense, spirit
    }

    public override void InitTurn()
    {
        this.skillPanel.Show();

        for(int i = 0; i < this.skills.Length; i++)
        {
            this.skillPanel.ConfigureButtons(i, this.skills[i].skillName);
        }
    }



    public void ActionSkill(int index)
    {
        this.skillPanel.Hide();

        Skill skill = this.skills[index];

        skill.SetEmiterAndReceiver(this, this.combatManager.EnemyFighter());

       this.combatManager.OnSkill(skill);
    }
}
