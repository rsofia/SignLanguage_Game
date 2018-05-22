using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_record : MonoBehaviour
{
    public string PosicionManoIzquierda;

    public GameObject GuiaThumb;
    public GameObject GuiaIndex;
    public GameObject GuiaMiddle;
    public GameObject GuiaPinky;
    public GameObject GuiaRing;

    public GameObject GuiaAngPalamPulgar;
    public GameObject GuiaAngPalam00;
    public GameObject GuiaAngPalam01;
    public GameObject GuiaAngPalam02;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        PosicionManoIzquierda = s_detecciones.PosicionManoIzquierda;
	}

}
