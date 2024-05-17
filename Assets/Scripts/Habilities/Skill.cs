using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [Header("Base skill")]
    public string skillName;
    public float animationDuration;

    public bool selfInFlicted;

    public GameObject effectPrfb;

    protected Fighter emiter;
    protected Fighter receiver; 

    public void Animate()
    {
        var go = Instantiate(this.effectPrfb, this.receiver.transform.position, Quaternion.identity);
        Destroy(go, this.animationDuration);
    }

    public void Run()
    {
        if (this.selfInFlicted)
        {
            this.receiver = this.emiter;
        }

        this.Animate();
        this.OnRun();
    }

    public void SetEmiterAndReceiver(Fighter _emiter, Fighter _receiver)
    {
        this.emiter = _emiter;
        this.receiver = _receiver;
    }
    protected abstract void OnRun();
}
