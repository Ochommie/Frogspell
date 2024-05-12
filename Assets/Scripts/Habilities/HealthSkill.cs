using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public enum HealthMode //El ENUM es una clase que representa constantes (variables inmutarbles / solo de lectura)
{
    Statbase, Fixed, Percentage
}

public class HealthSkill : Skill
{
    [Header("Health Mode")]
    public float amount;

    public HealthMode mode;

    protected override void OnRun()
    {
        float amount = this.GetModification();
        this.receiver.ModifyHealth(amount);
    }

    public float GetModification()
    {
        switch (this.mode)
        {
            case HealthMode.Statbase:
                Stats emiterStats = this.emiter.GetCurrentStats();
                Stats receiverStats = this.receiver.GetCurrentStats();

                float rawDamage = (((2 * emiterStats.level) / 5) + 2) * this.amount * (emiterStats.attack / receiverStats.deffense);
                return (rawDamage / 50) + 2;

            case HealthMode.Fixed:
                return this.amount;

            case HealthMode.Percentage:
                Stats rstats = this.receiver.GetCurrentStats();

                return rstats.maxHealth * this.amount;
        }
        
        throw new System.InvalidOperationException("HealtSkill. Unreachable!"); //Sirve para que el llenar todas las rutas del programa,
                                                                                //si llegara a esta linea, se le ordenara al compilador que crashee
    }
}