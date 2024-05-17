using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusPanel : MonoBehaviour
{
    public TMP_Text nameLabel;  //Etiqueta del nombre
    public TMP_Text levelLabel; //Etiqueta del nivel

    public Slider healthSlider; //La vida
    public Image healthSliderBar; //Imagen donde se dibuja la parte llena del SLIDER
    public TMP_Text healthLabel; //Muestra la vida en modo numerico

    public void SetStats(string name, Stats stats) //Funcion que recibe el nombre y las estadisticas
    {
        this.nameLabel.text = name;
        this.levelLabel.text = $"N. {stats.level}";
        this.SetHealth(stats.health, stats.maxHealth);
    }

    public void SetHealth(float health, float maxHealth)
    {
        this.healthLabel.text = $"{Mathf.RoundToInt(health)} / {Mathf.RoundToInt(maxHealth)}"; //Mathf convierte los flotantes en un entero
        float percentage = health / maxHealth; //Llamamos al porcentage de vida que tenemos

        this.healthSlider.value = percentage; //Evalua el porcentaje de vida, colocandoselo al Slider

        if (percentage < 0.40f)
        {
            this.healthSliderBar.color = Color.Lerp(Color.red, Color.green, healthSlider.value / 100); //Si el porcentaje en menor al 40% entonces de pinta de color rojo
        }
        else if (percentage > 0.40f)
        {
            this.healthSliderBar.color = Color.Lerp(Color.green, Color.red, healthSlider.value / 100);
        }
    }
}
