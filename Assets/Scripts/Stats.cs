using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float health; //Salud
    public float maxHealth; //Salud Maxima

    public int level; //Nivel
    public float attack; //Ataque
    public float deffense; //Defensa
    public float spirit; //Espiritu
    public Stats (int level, float maxHealth, float attack, float deffense, float spirit){ 
        this.level = level;
        this.maxHealth = maxHealth;
        this.attack = attack;
        this.deffense = deffense;
        this.spirit = spirit;
    }

    public Stats Clone(){
        return new Stats(this.level, this.maxHealth, this.attack, this.deffense, this.spirit);
    }




}
