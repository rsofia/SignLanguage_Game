using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_GameType : MonoBehaviour {

    [Tooltip("Nombre de la escena que va a cargar")]
    public string levelName = "";

    public void Open()
    {
        if (!string.IsNullOrEmpty(levelName))
            FindObjectOfType<SCR_Loading>().LoadScene(levelName);
        else
            Debug.LogWarning("No se te olvide escribir el nombre de la escena!");
    }
}
