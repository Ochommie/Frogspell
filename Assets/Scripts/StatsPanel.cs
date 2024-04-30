using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{
   public Text nameLabel; //Etiqueta del nombre
   public Text levelLabel; //Etiqueta del nivel

   public Slider healthSlider; //La vida
   public Image healthSliderBar; //Imagen donde se dibuja la parte llena del SLIDER
   public Text healthLabel; //Muestra la vida en modo numerico


   public void SetStats(string name, Stats stats){ //Funcion que recibe el nombre y las estadisticas
    this.nameLabel.text = name;
    this.levelLabel.text = $"N. {stats.level}";
    this.SetHealth(stats.health, stats.maxHealth);
   }



    public void SetHealth(float health, float maxHealth){
        this.healthLabel.text = $"{Mathf.RoundToInt(health)} / {Mathf.RoundToInt(maxHealth)}"; //Mathf convierte los flotantes en un entero
        float percentage = health / maxHealth; //Llamamos al porcentage de vida que tenemos

        this.healthSlider.value = percentage; //Evalua el porcentaje de vida, colocandoselo al Slider
        
        if(percentage<0.33f){ //Si el porcentaje en menor al 33% entonces de pinta de color rojo
            this.healthSliderBar.color = color.red;
        }
    }


}
