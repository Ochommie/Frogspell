using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class fighter : MonoBehaviour
{
    public string idName;
    public StatsPanel statsPanel;
    public CombatManager combatManager;

    protected Stats stats; //Estadisticas

    protected virtual void Start(){
    this.statsPanel.SetStats(this.idName, this.stats); //Estadisticas puestas en el panel
  }

    public void ModifyHealth(float amount){ //Ayuda modificar la salud, sumando o restando la salud, dependera de los numeros que vengan, ya sea negativos o positivos

        this.stats.health = Mathf.Clamp(this.stats.health + amount, 0f, this.stats.maxHealth); //Clamp se encarga de que los vlaores no sean menores a cero(0f) o mayores a la maxHealth
        this.statsPanel.SetHealth(this.stats.health, this.stats.maxHealth); 
    }

    public abstract void InitTurn();
}
