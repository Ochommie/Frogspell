using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : Fighter
{

    private void Awake()
    {
        this.stats = new Stats(20, 80, 50, 45, 20); //Level, maxHealth, attack, deffense, spirit
    }
    public override void InitTurn()
    {

    }
}
