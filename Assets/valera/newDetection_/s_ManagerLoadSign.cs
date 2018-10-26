using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Leap.Unity;
//Agregar metodos para lectura de archivos



public class s_ManagerLoadSign : MonoBehaviour {
    //[System.Serializable]
    //public class HandRecord
    //{
    //    [SerializeField]
    //    public bool v_ManoActiva;
    //    [SerializeField]
    //    public string[] v_RotacionPalma;

    //    [SerializeField]
    //    public int v_NumeroDeTirajes;

    //    [SerializeField]
    //    public int[] v_EstadoThumb;
    //    [SerializeField]
    //    public int[] v_EstadoIndex;
    //    [SerializeField]
    //    public int[] v_EstadoMiddle;
    //    [SerializeField]
    //    public int[] v_EstadoPinky;
    //    [SerializeField]
    //    public int[] v_EstadoRing;

    //    [SerializeField]
    //    public int[] v_DedosExtendidos;



    //    //////////// Posiciones


    //    [SerializeField]
    //    public Vector3[] v_PosBonesThumb0;
    //    [SerializeField]
    //    public Vector3[] v_PosBonesIndex0;
    //    [SerializeField]
    //    public Vector3[] v_PosBonesMiddle0;
    //    [SerializeField]
    //    public Vector3[] v_PosBonesPinky0;
    //    [SerializeField]
    //    public Vector3[] v_PosBonesRing0;


    //    [SerializeField]
    //    public Vector3[] v_PosBonesThumb1;
    //    [SerializeField]
    //    public Vector3[] v_PosBonesIndex1;
    //    [SerializeField]
    //    public Vector3[] v_PosBonesMiddle1;
    //    [SerializeField]
    //    public Vector3[] v_PosBonesPinky1;
    //    [SerializeField]
    //    public Vector3[] v_PosBonesRing1;

    //    [SerializeField]
    //    public Vector3[] v_PosBonesThumb2;
    //    [SerializeField]
    //    public Vector3[] v_PosBonesIndex2;
    //    [SerializeField]
    //    public Vector3[] v_PosBonesMiddle2;
    //    [SerializeField]
    //    public Vector3[] v_PosBonesPinky2;
    //    [SerializeField]
    //    public Vector3[] v_PosBonesRing2;

    //    //////////// Rotaciones

    //    [SerializeField]
    //    public Vector3[] v_RotBonesThumb0;
    //    [SerializeField]
    //    public Vector3[] v_RotBonesIndex0;
    //    [SerializeField]
    //    public Vector3[] v_RotBonesMiddle0;
    //    [SerializeField]
    //    public Vector3[] v_RotBonesPinky0;
    //    [SerializeField]
    //    public Vector3[] v_RotBonesRing0;

    //    [SerializeField]
    //    public Vector3[] v_RotBonesThumb1;
    //    [SerializeField]
    //    public Vector3[] v_RotBonesIndex1;
    //    [SerializeField]
    //    public Vector3[] v_RotBonesMiddle1;
    //    [SerializeField]
    //    public Vector3[] v_RotBonesPinky1;
    //    [SerializeField]
    //    public Vector3[] v_RotBonesRing1;

    //    [SerializeField]
    //    public Vector3[] v_RotBonesThumb2;
    //    [SerializeField]
    //    public Vector3[] v_RotBonesIndex2;
    //    [SerializeField]
    //    public Vector3[] v_RotBonesMiddle2;
    //    [SerializeField]
    //    public Vector3[] v_RotBonesPinky2;
    //    [SerializeField]
    //    public Vector3[] v_RotBonesRing2;


    //    ///


    //    [SerializeField]
    //    public Vector3[] v_PosBrazo;
    //    [SerializeField]
    //    public Vector3[] v_RotBrazo;
    //    [SerializeField]
    //    public Vector3[] v_PosPalma;
    //    [SerializeField]
    //    public Vector3[] v_RotPalma;


    //    public HandRecord(int _numeroTiraje)
    //    {
    //        v_ManoActiva = false;


    //        v_NumeroDeTirajes = _numeroTiraje;


    //        v_EstadoThumb = new int[v_NumeroDeTirajes];
    //        v_EstadoIndex = new int[v_NumeroDeTirajes];
    //        v_EstadoMiddle = new int[v_NumeroDeTirajes];
    //        v_EstadoPinky = new int[v_NumeroDeTirajes];
    //        v_EstadoRing = new int[v_NumeroDeTirajes];
    //        v_DedosExtendidos = new int[v_NumeroDeTirajes];
    //        v_RotacionPalma = new string[v_NumeroDeTirajes];

    //        for (int i = 0; i < v_NumeroDeTirajes; i++)
    //        {
    //            v_EstadoThumb[i] = 0;
    //            v_EstadoIndex[i] = 0;
    //            v_EstadoMiddle[i] = 0;
    //            v_EstadoPinky[i] = 0;
    //            v_EstadoRing[i] = 0;
    //            v_DedosExtendidos[i] = 0;
    //            v_RotacionPalma[i] = "";
    //        }

    //        v_PosBonesThumb0 = new Vector3[v_NumeroDeTirajes];
    //        v_PosBonesIndex0 = new Vector3[v_NumeroDeTirajes];
    //        v_PosBonesMiddle0 = new Vector3[v_NumeroDeTirajes];
    //        v_PosBonesPinky0 = new Vector3[v_NumeroDeTirajes];
    //        v_PosBonesRing0 = new Vector3[v_NumeroDeTirajes];

    //        v_PosBonesThumb1 = new Vector3[v_NumeroDeTirajes];
    //        v_PosBonesIndex1 = new Vector3[v_NumeroDeTirajes];
    //        v_PosBonesMiddle1 = new Vector3[v_NumeroDeTirajes];
    //        v_PosBonesPinky1 = new Vector3[v_NumeroDeTirajes];
    //        v_PosBonesRing1 = new Vector3[v_NumeroDeTirajes];

    //        v_PosBonesThumb2 = new Vector3[v_NumeroDeTirajes];
    //        v_PosBonesIndex2 = new Vector3[v_NumeroDeTirajes];
    //        v_PosBonesMiddle2 = new Vector3[v_NumeroDeTirajes];
    //        v_PosBonesPinky2 = new Vector3[v_NumeroDeTirajes];
    //        v_PosBonesRing2 = new Vector3[v_NumeroDeTirajes];


    //        v_RotBonesThumb0 = new Vector3[v_NumeroDeTirajes];
    //        v_RotBonesIndex0 = new Vector3[v_NumeroDeTirajes];
    //        v_RotBonesMiddle0 = new Vector3[v_NumeroDeTirajes];
    //        v_RotBonesPinky0 = new Vector3[v_NumeroDeTirajes];
    //        v_RotBonesRing0 = new Vector3[v_NumeroDeTirajes];

    //        v_RotBonesThumb1 = new Vector3[v_NumeroDeTirajes];
    //        v_RotBonesIndex1 = new Vector3[v_NumeroDeTirajes];
    //        v_RotBonesMiddle1 = new Vector3[v_NumeroDeTirajes];
    //        v_RotBonesPinky1 = new Vector3[v_NumeroDeTirajes];
    //        v_RotBonesRing1 = new Vector3[v_NumeroDeTirajes];

    //        v_RotBonesThumb2 = new Vector3[v_NumeroDeTirajes];
    //        v_RotBonesIndex2 = new Vector3[v_NumeroDeTirajes];
    //        v_RotBonesMiddle2 = new Vector3[v_NumeroDeTirajes];
    //        v_RotBonesPinky2 = new Vector3[v_NumeroDeTirajes];
    //        v_RotBonesRing2 = new Vector3[v_NumeroDeTirajes];

    //        v_PosBrazo = new Vector3[v_NumeroDeTirajes];
    //        v_RotBrazo = new Vector3[v_NumeroDeTirajes];

    //        v_PosPalma = new Vector3[v_NumeroDeTirajes];
    //        v_RotPalma = new Vector3[v_NumeroDeTirajes];



    //        Debug.Log(v_NumeroDeTirajes);
    //    }

    //}

    public HandRecord der;
    public HandRecord izq;

    public string NombreDeArchivo;

    bool matchFound = false;
    public s_ManagerExtend managerExtend;
    string path;
    public void ReadFile () {

        path = Application.dataPath + "/Archivos/GestosJson/" + NombreDeArchivo+".json";

        string tmp = NombreDeArchivo.Split('-')[1];
        print(tmp);

        der = new HandRecord(int.Parse(tmp));
        izq = new HandRecord(int.Parse(tmp));


        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        izq = JsonUtility.FromJson<HandRecord>(reader.ReadLine());
        der = JsonUtility.FromJson<HandRecord>(reader.ReadLine());
        reader.Close();
    }

    private void Update()
    {
        if(!matchFound && izq != null && der != null)
        {
            StartCoroutine(managerExtend.CompararDatos(izq, der, 1));
        }
    }


}
