using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    public void LoseGame()
    {
        SceneManager.LoadScene("Combat Scene"); 
    }
}
