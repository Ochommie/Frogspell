using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : fighter
{
    void Awake(){
        this.stats = new stats (20, 60, 50, 45, 20);
    }

    public override void InitTurn(){
        
    }
}
