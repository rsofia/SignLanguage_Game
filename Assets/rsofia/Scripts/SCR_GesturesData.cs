using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_GesturesData : MonoBehaviour {
    
    public static string path;
    public static string fileName = "Gestures.txt";

    void Start()
    {
        path = Application.persistentDataPath + "/Datos/Gestos/";
        Debug.Log("File path " + path);
    }

    public static IEnumerator PopUp(Text text, string _text)
    {
        text.gameObject.SetActive(true);
        text.text = _text;
        yield return new WaitForSeconds(2.0f);
        text.text = "";
        text.gameObject.SetActive(false);

    }
}
