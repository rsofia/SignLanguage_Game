using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_record : MonoBehaviour {


    public string PosicionManoIzquierda;


	void Start () {
		
	}
	
	void Update () {
        PosicionManoIzquierda = s_detecciones.PosicionManoIzquierda;
	}
}
