using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class s_LoadSingHandR_ : MonoBehaviour {

    [Header("Nombre para bucar el archivo")]
    public string v_NombreDeGesto;

    [Header("Datos Cargados")]
    public bool vC_diestro;

    public int vC_EstadoThumb;
    public int vC_EstadoIndex;
    public int vC_EstadoMiddle;
    public int vC_EstadoPinky;
    public int vC_EstadoRing;
    public int vC_extendedCount;
    public string vC_PosicionManoDerecha;

    public Vector3 vc_TrsPivPalm;
    public Vector3 vc_RotPivPalm;

    public Vector3 vc_TrsPivFoream;
    public Vector3 vc_RotPivFoream;

    public Vector3 vc_TrsPivThumb;
    public Vector3 vc_RotPivThumb;

    public Vector3 vc_TrsPivIndex;
    public Vector3 vc_RotPivIndex;

    public Vector3 vc_TrsPivMiddle;
    public Vector3 vc_RotPivMiddle;

    public Vector3 vc_TrsPivPinky;
    public Vector3 vc_RotPivPinky;

    public Vector3 vc_TrsPivRing;
    public Vector3 vc_RotPivRing;


    public void CargarArchivo()
    {
        if (File.Exists("Gestos1Hand/" + v_NombreDeGesto + ".txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open("Gestos1Hand/" + v_NombreDeGesto + ".txt", FileMode.Open);

            vC_diestro = (bool)bf.Deserialize(file);

            vC_EstadoThumb = (int)bf.Deserialize(file);
            vC_EstadoIndex = (int)bf.Deserialize(file);
            vC_EstadoMiddle = (int)bf.Deserialize(file);
            vC_EstadoPinky = (int)bf.Deserialize(file);
            vC_EstadoRing = (int)bf.Deserialize(file);

            vC_extendedCount = (int)bf.Deserialize(file);

            vC_PosicionManoDerecha = (string)bf.Deserialize(file);

            vc_TrsPivPalm = new Vector3((float)bf.Deserialize(file),(float)bf.Deserialize(file),(float)bf.Deserialize(file));
            vc_RotPivPalm = new Vector3((float)bf.Deserialize(file), (float)bf.Deserialize(file), (float)bf.Deserialize(file));

            vc_TrsPivFoream = new Vector3((float)bf.Deserialize(file), (float)bf.Deserialize(file), (float)bf.Deserialize(file));
            vc_RotPivFoream = new Vector3((float)bf.Deserialize(file), (float)bf.Deserialize(file), (float)bf.Deserialize(file));

            vc_TrsPivThumb = new Vector3((float)bf.Deserialize(file), (float)bf.Deserialize(file), (float)bf.Deserialize(file));
            vc_RotPivThumb = new Vector3((float)bf.Deserialize(file), (float)bf.Deserialize(file), (float)bf.Deserialize(file));

            vc_TrsPivIndex = new Vector3((float)bf.Deserialize(file), (float)bf.Deserialize(file), (float)bf.Deserialize(file));
            vc_RotPivIndex = new Vector3((float)bf.Deserialize(file), (float)bf.Deserialize(file), (float)bf.Deserialize(file));

            vc_TrsPivMiddle = new Vector3((float)bf.Deserialize(file), (float)bf.Deserialize(file), (float)bf.Deserialize(file));
            vc_RotPivMiddle = new Vector3((float)bf.Deserialize(file), (float)bf.Deserialize(file), (float)bf.Deserialize(file));

            vc_TrsPivPinky = new Vector3((float)bf.Deserialize(file), (float)bf.Deserialize(file), (float)bf.Deserialize(file));
            vc_RotPivPinky = new Vector3((float)bf.Deserialize(file), (float)bf.Deserialize(file), (float)bf.Deserialize(file));

            vc_TrsPivRing = new Vector3((float)bf.Deserialize(file), (float)bf.Deserialize(file), (float)bf.Deserialize(file));
            vc_RotPivRing = new Vector3((float)bf.Deserialize(file), (float)bf.Deserialize(file), (float)bf.Deserialize(file));

            file.Close();
        }
        else
            Debug.LogWarning("Archivo no encontrado");
    }

}
