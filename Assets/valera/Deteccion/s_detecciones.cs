using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_detecciones : MonoBehaviour {

	public static string PosicionManoIzquierda;

    void Start()
    {
        PosicionManoIzquierda = "";    
    }

    public void CambiarRotacionPalmaMano(string _posicion)
    {
        PosicionManoIzquierda = _posicion;
    }

}
