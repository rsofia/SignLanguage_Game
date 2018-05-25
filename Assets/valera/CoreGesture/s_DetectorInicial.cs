using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_DetectorInicial : MonoBehaviour {
    /*
     * Codigo que se coloca dentro de la palma del modelo de mano de leap motion con un collider
     * El cual funciona con un trigger cualquiera en el centro de las manos o donde se requiera para empezar la lectura de gestos
     */
    [Header("Referencia a S_manager")]
    public s_manager manager;

    [Header("Palmas de los modelos")]
    public GameObject RPalm;
    public GameObject LPalm;

    //Bool para organizar que mano es la activa, true = derecha , false = izquierda
    [Header("Direccion de la mano")]
    public bool DirectionHand;

    void OnTriggerExit(Collider other)
    {
        if(DirectionHand)
        {
            manager.v_Salida = RPalm.transform.position;
            manager.Checar = true;
        }
        else
        {
            manager.v_Salida = LPalm.transform.position;
            manager.Checar = true;
        }
    }
  
    void OnTriggerStay(Collider other)
    {
        if (DirectionHand)
            manager.v_Inicial = RPalm.transform.position;
        else
            manager.v_Inicial = LPalm.transform.position;

    }
}
