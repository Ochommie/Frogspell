using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    public string idName;
    public StatusPanel statusPanel;

    public CombatManager combatManager;

    public Stats stats;

    protected Skill[] skills;

    public bool isAlive
    {
        get => this.stats.health > 0;// Para saber si el personaje sigue vivo


    }

    protected virtual void Start()
    {
        this.statusPanel.SetStats(this.idName, this.stats);
        this.skills = this.GetComponentsInChildren<Skill>();
    }

    public void ModifyHealth(float amount)
    {
        this.stats.health = Mathf.Clamp(this.stats.health + amount, 0f, this.stats.maxHealth);
        this.statusPanel.SetHealth(this.stats.health, this.stats.maxHealth);
    }

    public Stats GetCurrentStats()
    {
        return this.stats;
    }

    public abstract void InitTurn();
}
