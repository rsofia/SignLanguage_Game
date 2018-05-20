using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public enum CATEGORIAS_GESTOS
{
    ABECEDARIO = 0,
    ADJETIVOS,
    ALIMENTOS,
    ANIMALES,
    ANTONIMOS,
    CALENDARIO,
    CASA,
    COLORES,
    CUERPO_HUMANO,
    ESCUELA,
    FAMILIA,
    FRUTAS_VERDURAS,
    NUMEROS,
    REPUBLICA,
    OTROS = 14
}

public class SCR_AlmacenarGestos : SCR_GestureDetection
{

    private JSONGesture gestureToSave;

    [Header("Interfaz")]
    public Dropdown dd_cat;
    public InputField inptFld_Significado;
    public Text txtError;
    public Text txtExito;   


    private void Start()
    {

        thumbBonesR = new Transform[] { thumbRight.Find("bone1"), thumbRight.Find("bone2"), thumbRight.Find("bone3") };
        indexBonesR = new Transform[] { indexRight.Find("bone1"), indexRight.Find("bone2"), indexRight.Find("bone3") };
        middleBonesR = new Transform[] { middleRight.Find("bone1"), middleRight.Find("bone2"), middleRight.Find("bone3") };
        ringBonesR = new Transform[] { ringRight.Find("bone1"), ringRight.Find("bone2"), ringRight.Find("bone3") };
        pinkyBonesR = new Transform[] { pinkyRight.Find("bone1"), pinkyRight.Find("bone2"), pinkyRight.Find("bone3") };

        txtError.text = "";
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && gameObject.activeSelf)
        {
            AlmacenarGesto();
        }
    }


    public void AlmacenarGesto()
    {
        if (!string.IsNullOrEmpty(inptFld_Significado.text))
        {
            gestureToSave = new JSONGesture
            {
                category = dd_cat.value,
                meaning = inptFld_Significado.text,
                thumbRPos = new float[] { thumbRight.localEulerAngles.x, thumbRight.localEulerAngles.y, thumbRight.localEulerAngles.z,
                                                 thumbBonesR[0].localEulerAngles.x, thumbBonesR[0].localEulerAngles.y, thumbBonesR[0].localEulerAngles.z,
                                                 thumbBonesR[1].localEulerAngles.x, thumbBonesR[1].localEulerAngles.y, thumbBonesR[1].localEulerAngles.z,
                                                 thumbBonesR[2].localEulerAngles.x, thumbBonesR[2].localEulerAngles.y, thumbBonesR[2].localEulerAngles.z },
                indexRPos = new float[] { indexRight.localEulerAngles.x, indexRight.localEulerAngles.y, indexRight.localEulerAngles.z,
                                                 indexBonesR[0].localEulerAngles.x, indexBonesR[0].localEulerAngles.y, indexBonesR[0].localEulerAngles.z,
                                                 indexBonesR[1].localEulerAngles.x, indexBonesR[1].localEulerAngles.y, indexBonesR[1].localEulerAngles.z,
                                                 indexBonesR[2].localEulerAngles.x, indexBonesR[2].localEulerAngles.y, indexBonesR[2].localEulerAngles.z },
                middleRPos = new float[] {middleRight.localEulerAngles.x, middleRight.localEulerAngles.y, middleRight.localEulerAngles.z,
                                                 middleBonesR[0].localEulerAngles.x, middleBonesR[0].localEulerAngles.y, middleBonesR[0].localEulerAngles.z,
                                                 middleBonesR[1].localEulerAngles.x, middleBonesR[1].localEulerAngles.y, middleBonesR[1].localEulerAngles.z,
                                                 middleBonesR[2].localEulerAngles.x, middleBonesR[2].localEulerAngles.y, middleBonesR[2].localEulerAngles.z },
                ringRPos = new float[] {  ringRight.localEulerAngles.x, ringRight.localEulerAngles.y, ringRight.localEulerAngles.z,
                                                 ringBonesR[0].localEulerAngles.x, ringBonesR[0].localEulerAngles.y, ringBonesR[0].localEulerAngles.z,
                                                 ringBonesR[1].localEulerAngles.x, ringBonesR[1].localEulerAngles.y, ringBonesR[1].localEulerAngles.z,
                                                 ringBonesR[2].localEulerAngles.x, ringBonesR[2].localEulerAngles.y, ringBonesR[2].localEulerAngles.z },
                pinkyRPos = new float[] { pinkyRight.localEulerAngles.x, pinkyRight.localEulerAngles.y, pinkyRight.localEulerAngles.z,
                                                 pinkyBonesR[0].localEulerAngles.x, pinkyBonesR[0].localEulerAngles.y, pinkyBonesR[0].localEulerAngles.z,
                                                 pinkyBonesR[1].localEulerAngles.x, pinkyBonesR[1].localEulerAngles.y, pinkyBonesR[1].localEulerAngles.z,
                                                 pinkyBonesR[2].localEulerAngles.x, pinkyBonesR[2].localEulerAngles.y, pinkyBonesR[2].localEulerAngles.z }

            };

            WriteAtPath(SCR_GesturesData.path, SCR_GesturesData.fileName, JsonUtility.ToJson(gestureToSave));
            StartCoroutine(SCR_GesturesData.PopUp(txtExito, "Guardado exitosamente!"));
        }
        else
        {
            StartCoroutine(SCR_GesturesData.PopUp(txtError, "Por favor inserte el significado del gesto"));
        }
       
    }

   

    public static void WriteAtPath(string _path, string _filename, string _text)
    {
        if (!File.Exists(_path))
            Directory.CreateDirectory(_path);
        TextWriter textWriter = new StreamWriter(_path + _filename, true);
        textWriter.WriteLine(_text);
        textWriter.Close();
    }
	
}
