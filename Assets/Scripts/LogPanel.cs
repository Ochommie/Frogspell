using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogPanel : MonoBehaviour
{
   protected static LogPanel current; //Referencia estatica al panel actual
   public Text logLabel; //Referencia a la etiqueta de texto
   void Awake(){
    current = this;
   }

   public static void write(string message){ //Funcion estatica para escribir un mensaje
      current.ActionsPanel.text = message;
   }
}
