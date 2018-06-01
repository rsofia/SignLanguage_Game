using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class s_SaveSingHandR_ : MonoBehaviour {

    public GameObject v_pivPalm;
    public GameObject v_pivFoream;

    public GameObject v_pivMarcadorThumb;
    public GameObject v_pivMarcadorIndex;
    public GameObject v_pivMarcadorMiddle;
    public GameObject v_pivMarcadorPinky;
    public GameObject v_pivMarcadorRing;

    public InputField v_nombreArchivo;

    public Leap.Unity.s_HandDetector v_lector;


    void Start () {
		
	}
	
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            fn_ActivarGuardado();
        }	
	}

    public void fn_ActivarGuardado()
    {
        if(v_nombreArchivo.text != "")
        {
            fn_GuardarArchivo();
        }
    }

    void fn_GuardarArchivo()
    {
        if (!Directory.Exists("Gestos1Hand"))
            Directory.CreateDirectory("Gestos1Hand");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("Gestos1Hand/" + v_nombreArchivo.text + ".txt");


        bf.Serialize(file, v_lector.v_diestro);

        bf.Serialize(file, v_lector.v_EstadoThumb);
        bf.Serialize(file, v_lector.v_EstadoIndex);
        bf.Serialize(file, v_lector.v_EstadoMiddle);
        bf.Serialize(file, v_lector.v_EstadoPinky);
        bf.Serialize(file, v_lector.v_EstadoRing);

        bf.Serialize(file, v_lector.v_extendedCount);

        bf.Serialize(file, v_lector.v_PosicionManoDerecha);

        List<GameObject> tmp = new List<GameObject>();
        tmp.Add(v_pivPalm);
        tmp.Add(v_pivFoream);

        tmp.Add(v_pivMarcadorThumb);
        tmp.Add(v_pivMarcadorIndex);
        tmp.Add(v_pivMarcadorMiddle);
        tmp.Add(v_pivMarcadorPinky);
        tmp.Add(v_pivMarcadorRing);


        for (int i = 0; i < 7; i++)
        {

            bf.Serialize(file, tmp[i].transform.position.x);
            bf.Serialize(file, tmp[i].transform.position.y);
            bf.Serialize(file, tmp[i].transform.position.z);

            bf.Serialize(file, tmp[i].transform.rotation.eulerAngles.x);
            bf.Serialize(file, tmp[i].transform.rotation.eulerAngles.y);
            bf.Serialize(file, tmp[i].transform.rotation.eulerAngles.z);

        }
        file.Close();

        Debug.Log("Archivo guardado");
    }   
}
