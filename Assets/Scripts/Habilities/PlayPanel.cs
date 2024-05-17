using UnityEngine;
using TMPro;

public class PlayPanel : MonoBehaviour
{
    public GameObject[] skillButton;
    public TMP_Text[] skillButtonLabel;


    private void Awake()
    {
        this.Hide();

        foreach (var btn in this.skillButton)
        {
            btn.SetActive(false);
        }
    }

    public void ConfigureButtons(int index, string skillName)
    {
        this.skillButton[index].SetActive(true);
        this.skillButtonLabel[index].text = skillName;
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
