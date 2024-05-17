using UnityEngine;
using TMPro;

public class LogPanel : MonoBehaviour
{
    protected static LogPanel current;

    public TMP_Text LabelText;

    void Awake()
    {
        current = this;
    }

    public static void Write(string message)
    {
        current.LabelText.text = message;
    }
}