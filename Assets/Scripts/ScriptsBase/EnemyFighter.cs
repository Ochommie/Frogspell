using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : Fighter
{

    private void Awake()
    {
        this.stats = new Stats(20, 100, 50, 45, 20); //Level, maxHealth, attack, deffense, spirit
    }
    public override void InitTurn()
    {
        StartCoroutine(this.AI());
    }


    IEnumerator AI()
    {
        yield return new WaitForSeconds(1f);

        Skill skill = this.skills[Random.Range(0, this.skills.Length)];
        skill.SetEmiterAndReceiver(this, this.combatManager.EnemyFighter());

        this.combatManager.OnSkill(skill);
    }
}
