using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attributes;
using System.IO;
using UnityEngine.UI;

namespace Leap.Unity
{
    public enum TiemposDisponibles
    {
        _1Segundos,
        _2Segundos,
        _5Segundos,
        _10Segundos
    }
    public enum CiclosGravado
    {
        _1Times,
        _5Times,
        _10Times,
        _15Times,
        _20Times
    }

    [System.Serializable]
    public class HandRecord
    {
        [SerializeField]
        public bool v_ManoActiva;
        [SerializeField]
        public string [] v_RotacionPalma;

        [SerializeField]
        public int v_NumeroDeTirajes;

        [SerializeField]
        public int []v_EstadoThumb;
        [SerializeField]
        public int []v_EstadoIndex;
        [SerializeField]
        public int []v_EstadoMiddle;
        [SerializeField]
        public int []v_EstadoPinky;
        [SerializeField]
        public int []v_EstadoRing;

        [SerializeField]
        public int []v_DedosExtendidos;



        //////////// Posiciones


        [SerializeField]
        public Vector3[] v_PosBonesThumb0;
        [SerializeField]
        public Vector3[] v_PosBonesIndex0;
        [SerializeField]
        public Vector3[] v_PosBonesMiddle0;
        [SerializeField]
        public Vector3[] v_PosBonesPinky0;
        [SerializeField]
        public Vector3[] v_PosBonesRing0;


        [SerializeField]
        public Vector3[] v_PosBonesThumb1;
        [SerializeField]
        public Vector3[] v_PosBonesIndex1;
        [SerializeField]
        public Vector3[] v_PosBonesMiddle1;
        [SerializeField]
        public Vector3[] v_PosBonesPinky1;
        [SerializeField]
        public Vector3[] v_PosBonesRing1;

        [SerializeField]
        public Vector3[] v_PosBonesThumb2;
        [SerializeField]
        public Vector3[] v_PosBonesIndex2;
        [SerializeField]
        public Vector3[] v_PosBonesMiddle2;
        [SerializeField]
        public Vector3[] v_PosBonesPinky2;
        [SerializeField]
        public Vector3[] v_PosBonesRing2;

        //////////// Rotaciones

        [SerializeField]
        public Vector3[] v_RotBonesThumb0;
        [SerializeField]
        public Vector3[] v_RotBonesIndex0;
        [SerializeField]
        public Vector3[] v_RotBonesMiddle0;
        [SerializeField]
        public Vector3[] v_RotBonesPinky0;
        [SerializeField]
        public Vector3[] v_RotBonesRing0;

        [SerializeField]
        public Vector3[] v_RotBonesThumb1;
        [SerializeField]
        public Vector3[] v_RotBonesIndex1;
        [SerializeField]
        public Vector3[] v_RotBonesMiddle1;
        [SerializeField]
        public Vector3[] v_RotBonesPinky1;
        [SerializeField]
        public Vector3[] v_RotBonesRing1;

        [SerializeField]
        public Vector3[] v_RotBonesThumb2;
        [SerializeField]
        public Vector3[] v_RotBonesIndex2;
        [SerializeField]
        public Vector3[] v_RotBonesMiddle2;
        [SerializeField]
        public Vector3[] v_RotBonesPinky2;
        [SerializeField]
        public Vector3[] v_RotBonesRing2;


        ///


        [SerializeField]
        public Vector3[] v_PosBrazo;
        [SerializeField]
        public Vector3[] v_RotBrazo;
        [SerializeField]
        public Vector3[] v_PosPalma;
        [SerializeField]
        public Vector3[] v_RotPalma;


        public HandRecord(int _numeroTiraje)
        {
            v_ManoActiva = false;

            v_NumeroDeTirajes = _numeroTiraje;


            v_EstadoThumb = new int[v_NumeroDeTirajes];
            v_EstadoIndex = new int[v_NumeroDeTirajes];
            v_EstadoMiddle = new int[v_NumeroDeTirajes];
            v_EstadoPinky = new int[v_NumeroDeTirajes];
            v_EstadoRing = new int[v_NumeroDeTirajes];
            v_DedosExtendidos = new int[v_NumeroDeTirajes];

            v_RotacionPalma = new string[v_NumeroDeTirajes];

            for (int i = 0; i < v_NumeroDeTirajes; i++)
            {
                v_EstadoThumb[i] = 0;
                v_EstadoIndex[i] = 0;
                v_EstadoMiddle[i] = 0;
                v_EstadoPinky[i] = 0;
                v_EstadoRing[i] = 0;
                v_DedosExtendidos[i] = 0;
                v_RotacionPalma[i] = "";

            }

            v_PosBonesThumb0  = new Vector3[v_NumeroDeTirajes];
            v_PosBonesIndex0  = new Vector3[v_NumeroDeTirajes];
            v_PosBonesMiddle0 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesPinky0  = new Vector3[v_NumeroDeTirajes];
            v_PosBonesRing0   = new Vector3[v_NumeroDeTirajes];

            v_PosBonesThumb1 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesIndex1 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesMiddle1 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesPinky1 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesRing1 = new Vector3[v_NumeroDeTirajes];

            v_PosBonesThumb2 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesIndex2 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesMiddle2 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesPinky2 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesRing2 = new Vector3[v_NumeroDeTirajes];


            v_RotBonesThumb0  = new Vector3[v_NumeroDeTirajes];
            v_RotBonesIndex0  = new Vector3[v_NumeroDeTirajes];
            v_RotBonesMiddle0 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesPinky0  = new Vector3[v_NumeroDeTirajes];
            v_RotBonesRing0   = new Vector3[v_NumeroDeTirajes];

            v_RotBonesThumb1 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesIndex1 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesMiddle1 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesPinky1 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesRing1 = new Vector3[v_NumeroDeTirajes];

            v_RotBonesThumb2 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesIndex2 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesMiddle2 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesPinky2 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesRing2 = new Vector3[v_NumeroDeTirajes];

            v_PosBrazo = new Vector3[v_NumeroDeTirajes];
            v_RotBrazo = new Vector3[v_NumeroDeTirajes];

            v_PosPalma = new Vector3[v_NumeroDeTirajes];
            v_RotPalma = new Vector3[v_NumeroDeTirajes];



        }

        public void ClearClass(int _numeroTiraje)
        {
            v_ManoActiva = false;

            v_NumeroDeTirajes = _numeroTiraje;


            v_EstadoThumb = new int[v_NumeroDeTirajes];
            v_EstadoIndex = new int[v_NumeroDeTirajes];
            v_EstadoMiddle = new int[v_NumeroDeTirajes];
            v_EstadoPinky = new int[v_NumeroDeTirajes];
            v_EstadoRing = new int[v_NumeroDeTirajes];
            v_DedosExtendidos = new int[v_NumeroDeTirajes];

            for (int i = 0; i < v_NumeroDeTirajes; i++)
            {
                v_EstadoThumb[i] = 0;
                v_EstadoIndex[i] = 0;
                v_EstadoMiddle[i] = 0;
                v_EstadoPinky[i] = 0;
                v_EstadoRing[i] = 0;
                v_DedosExtendidos[i] = 0;
                v_RotacionPalma[i] = "";

            }

            v_PosBonesThumb0 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesIndex0 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesMiddle0 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesPinky0 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesRing0 = new Vector3[v_NumeroDeTirajes];

            v_PosBonesThumb1 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesIndex1 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesMiddle1 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesPinky1 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesRing1 = new Vector3[v_NumeroDeTirajes];

            v_PosBonesThumb2 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesIndex2 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesMiddle2 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesPinky2 = new Vector3[v_NumeroDeTirajes];
            v_PosBonesRing2 = new Vector3[v_NumeroDeTirajes];


            v_RotBonesThumb0 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesIndex0 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesMiddle0 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesPinky0 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesRing0 = new Vector3[v_NumeroDeTirajes];

            v_RotBonesThumb1 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesIndex1 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesMiddle1 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesPinky1 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesRing1 = new Vector3[v_NumeroDeTirajes];

            v_RotBonesThumb2 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesIndex2 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesMiddle2 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesPinky2 = new Vector3[v_NumeroDeTirajes];
            v_RotBonesRing2 = new Vector3[v_NumeroDeTirajes];

            v_PosBrazo = new Vector3[v_NumeroDeTirajes];
            v_RotBrazo = new Vector3[v_NumeroDeTirajes];

            v_PosPalma = new Vector3[v_NumeroDeTirajes];
            v_RotPalma = new Vector3[v_NumeroDeTirajes];
        }
    }

    public class s_ManagerExtend : Detector
    {

        [Header("Configuracion")]
        [MinValue(0.1f)]
        public float v_periodoActualizacion = 0.1f;
        public TiemposDisponibles v_TiempoDeGrabado;
        public CiclosGravado v_CiclosDeGravacion;
        public InputField v_NombreArchivo;

        [Header("Requerimientos")]
        [Tooltip("The hand model to watch. Set automatically if detector is on a hand.")]
        public HandModelBase v_HandModelDerecha = null;
        public HandModelBase v_HandModelIzquierda = null;


        [Header("Estados")]
        public bool v_ManoIzquierdaActiva;
        public bool v_ManoDerechaActiva;

        [Header("Datos a Guardar")]
        public HandRecord v_ManoIzquierda;
        public HandRecord v_ManoDerecha;

        [Header("Datos de Visualizacion")]
        public string v_PosicionManoIzquierda;
        public string v_PosicionManoDerecha;

        public int v_NumeroDeDedosActivosHDerecha;
        public int v_NumeroDeDedosActivosHIzquierda;

        public int v_EstadoThumbIzquierdo;
        public int v_EstadoIndexIzquierdo;
        public int v_EstadoMiddleIzquierdo;
        public int v_EstadoPinkyIzquierdo;
        public int v_EstadoRingIzquierdo;

        public int v_EstadoThumbDerecho;
        public int v_EstadoIndexDerecho;
        public int v_EstadoMiddleDerecho;
        public int v_EstadoPinkyDerecho;
        public int v_EstadoRingDerecho;

        [Header("Objetos de ref Mano izquierda")]
        public GameObject[] ThumbI;
        public GameObject[] IndexI;
        public GameObject[] MiddleI;
        public GameObject[] PinkyI;
        public GameObject[] RingI;
        public GameObject PalmI;
        public GameObject ForI;


        [Header("Objetos de ref Mano Derecha")]
        public GameObject[] ThumbD;
        public GameObject[] IndexD;
        public GameObject[] MiddleD;
        public GameObject[] PinkyD;
        public GameObject[] RingD;
        public GameObject PalmD;
        public GameObject ForD;

        [Header("Interfaz")]
        public GameObject panelGuardar;
        public GameObject matchFound;

        private IEnumerator watcherCoroutine;
                       
        void Awake()
        {
            watcherCoroutine = extendedFingerWatcher();
        }
        void OnEnable()
        {
            StartCoroutine(watcherCoroutine);
        }

        public void GuardarTiraje()
        {

            int _tirajes = 0;
            int _tiempoEnTiraje = 0;

            switch(v_TiempoDeGrabado)
            {
                case TiemposDisponibles._1Segundos:
                    _tiempoEnTiraje = 1;
                    break;
                case TiemposDisponibles._2Segundos:
                    _tiempoEnTiraje = 2;
                    break;
                case TiemposDisponibles._5Segundos:
                    _tiempoEnTiraje = 5;
                    break;
                case TiemposDisponibles._10Segundos:
                    _tiempoEnTiraje = 10;
                    break;
            }

            switch(v_CiclosDeGravacion)
            {
                case CiclosGravado._1Times:
                    _tirajes = 1;
                    break;
                case CiclosGravado._5Times:
                    _tirajes = 5;
                    break;
                case CiclosGravado._10Times:
                    _tirajes = 10;
                    break;
                case CiclosGravado._15Times:
                    _tirajes = 15;
                    break;
                case CiclosGravado._20Times:
                    _tirajes = 20;
                    break;
            }

            v_ManoIzquierda = new HandRecord(_tirajes);
            v_ManoDerecha = new HandRecord(_tirajes);

            Debug.Log("Se activo corutina de guardado");
            StartCoroutine(fn_GuardarDatos(_tirajes, _tiempoEnTiraje));
        }

        #region
        public void fn_GuardarDatosJSonFormat(string _nombreGesto , int _tirajes)
        {

            string jsonManoIzquierda = JsonUtility.ToJson(v_ManoIzquierda);
            string jsonManoDerecha = JsonUtility.ToJson(v_ManoDerecha);

            if (!Directory.Exists("GestosJson"))
                Directory.CreateDirectory("GestosJson");

            string path = Application.dataPath + "/Archivos/GestosJson/" + _nombreGesto + "-"+_tirajes+".json";
            

            StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine(jsonManoIzquierda);
            writer.WriteLine(jsonManoDerecha);

            writer.Close();
        }
        
        
        #endregion

        #region ///Corutinas

        IEnumerator fn_GuardarDatos(int _numeroTirajes, float _tiempoEntreTirajes)
        {
            float tiempoTMp = _tiempoEntreTirajes / _numeroTirajes;

            for (int i = 0; i < _numeroTirajes; i++)
            {
                Debug.Log("> Tiraje"+i);
                if(v_ManoIzquierdaActiva)
                {
                    v_ManoIzquierda.v_ManoActiva = true;

                    v_ManoIzquierda.v_RotacionPalma[i] = v_PosicionManoIzquierda;
                    Debug.Log(v_ManoIzquierda.v_RotacionPalma);
                    Debug.Log(v_PosicionManoIzquierda);
                    v_ManoIzquierda.v_EstadoThumb[i] = v_EstadoThumbIzquierdo;
                    v_ManoIzquierda.v_EstadoIndex[i] = v_EstadoIndexIzquierdo;
                    v_ManoIzquierda.v_EstadoMiddle[i] = v_EstadoMiddleIzquierdo;
                    v_ManoIzquierda.v_EstadoPinky[i] = v_EstadoPinkyIzquierdo;
                    v_ManoIzquierda.v_EstadoRing[i] = v_EstadoRingIzquierdo;

                    v_ManoIzquierda.v_DedosExtendidos[i] = v_NumeroDeDedosActivosHIzquierda;


                    //Posiciones

                    v_ManoIzquierda.v_PosBonesIndex0[i] = IndexI[0].transform.position;
                    v_ManoIzquierda.v_PosBonesIndex1[i] = IndexI[1].transform.position;
                    v_ManoIzquierda.v_PosBonesIndex2[i] = IndexI[2].transform.position;

                    v_ManoIzquierda.v_PosBonesMiddle0[i] = MiddleI[0].transform.position;
                    v_ManoIzquierda.v_PosBonesMiddle1[i] = MiddleI[1].transform.position;
                    v_ManoIzquierda.v_PosBonesMiddle2[i] = MiddleI[2].transform.position;

                    v_ManoIzquierda.v_PosBonesPinky0[i] = PinkyI[0].transform.position;
                    v_ManoIzquierda.v_PosBonesPinky1[i] = PinkyI[1].transform.position;
                    v_ManoIzquierda.v_PosBonesPinky2[i] = PinkyI[2].transform.position;

                    v_ManoIzquierda.v_PosBonesRing0[i] = RingI[0].transform.position;
                    v_ManoIzquierda.v_PosBonesRing1[i] = RingI[1].transform.position;
                    v_ManoIzquierda.v_PosBonesRing2[i] = RingI[2].transform.position;

                    v_ManoIzquierda.v_PosBonesThumb0[i] = ThumbI[0].transform.position;
                    v_ManoIzquierda.v_PosBonesThumb1[i] = ThumbI[1].transform.position;
                    v_ManoIzquierda.v_PosBonesThumb2[i] = ThumbI[2].transform.position;

                    //Rotaciones

                    v_ManoIzquierda.v_RotBonesIndex0[i] = IndexI[0].transform.rotation.eulerAngles;
                    v_ManoIzquierda.v_RotBonesIndex1[i] = IndexI[1].transform.rotation.eulerAngles;
                    v_ManoIzquierda.v_RotBonesIndex2[i] = IndexI[2].transform.rotation.eulerAngles;

                    v_ManoIzquierda.v_RotBonesMiddle0[i] = MiddleI[0].transform.rotation.eulerAngles;
                    v_ManoIzquierda.v_RotBonesMiddle1[i] = MiddleI[1].transform.rotation.eulerAngles;
                    v_ManoIzquierda.v_RotBonesMiddle2[i] = MiddleI[2].transform.rotation.eulerAngles;

                    v_ManoIzquierda.v_RotBonesPinky0[i] = PinkyI[0].transform.rotation.eulerAngles;
                    v_ManoIzquierda.v_RotBonesPinky1[i] = PinkyI[1].transform.rotation.eulerAngles;
                    v_ManoIzquierda.v_RotBonesPinky2[i] = PinkyI[2].transform.rotation.eulerAngles;

                    v_ManoIzquierda.v_RotBonesRing0[i] = RingI[0].transform.rotation.eulerAngles;
                    v_ManoIzquierda.v_RotBonesRing1[i] = RingI[1].transform.rotation.eulerAngles;
                    v_ManoIzquierda.v_RotBonesRing2[i] = RingI[2].transform.rotation.eulerAngles;

                    v_ManoIzquierda.v_RotBonesThumb0[i] = ThumbI[0].transform.rotation.eulerAngles;
                    v_ManoIzquierda.v_RotBonesThumb1[i] = ThumbI[1].transform.rotation.eulerAngles;
                    v_ManoIzquierda.v_RotBonesThumb2[i] = ThumbI[2].transform.rotation.eulerAngles;

                    v_ManoIzquierda.v_PosBrazo[i] = ForI.transform.position;
                    v_ManoIzquierda.v_RotBrazo[i] = ForI.transform.rotation.eulerAngles;

                    v_ManoIzquierda.v_PosPalma[i]= PalmI.transform.position;
                    v_ManoIzquierda.v_RotPalma[i]= PalmI.transform.rotation.eulerAngles;





                }
                else
                {
                    v_ManoIzquierda.v_ManoActiva = false;
                    Debug.Log("Mano izquierda perdida");

                }

                if (v_ManoDerechaActiva)
                {
                    v_ManoDerecha.v_ManoActiva = true;

                    v_ManoDerecha.v_RotacionPalma[i] = v_PosicionManoDerecha;
                
                    v_ManoDerecha.v_EstadoThumb[i] = v_EstadoThumbDerecho;
                    v_ManoDerecha.v_EstadoIndex[i] = v_EstadoIndexDerecho;
                    v_ManoDerecha.v_EstadoMiddle[i] = v_EstadoMiddleDerecho;
                    v_ManoDerecha.v_EstadoPinky[i] = v_EstadoPinkyDerecho;
                    v_ManoDerecha.v_EstadoRing[i] = v_EstadoRingDerecho;

                    v_ManoDerecha.v_DedosExtendidos[i] = v_NumeroDeDedosActivosHDerecha;

                    //Posiciones

                    v_ManoDerecha.v_PosBonesIndex0[i] = IndexD[0].transform.position;
                    v_ManoDerecha.v_PosBonesIndex1[i] = IndexD[1].transform.position;
                    v_ManoDerecha.v_PosBonesIndex2[i] = IndexD[2].transform.position;

                    v_ManoDerecha.v_PosBonesMiddle0[i] = MiddleD[0].transform.position;
                    v_ManoDerecha.v_PosBonesMiddle1[i] = MiddleD[1].transform.position;
                    v_ManoDerecha.v_PosBonesMiddle2[i] = MiddleD[2].transform.position;

                    v_ManoDerecha.v_PosBonesPinky0[i] = PinkyD[0].transform.position;
                    v_ManoDerecha.v_PosBonesPinky1[i] = PinkyD[1].transform.position;
                    v_ManoDerecha.v_PosBonesPinky2[i] = PinkyD[2].transform.position;

                    v_ManoDerecha.v_PosBonesRing0[i] = RingD[0].transform.position;
                    v_ManoDerecha.v_PosBonesRing1[i] = RingD[1].transform.position;
                    v_ManoDerecha.v_PosBonesRing2[i] = RingD[2].transform.position;

                    v_ManoDerecha.v_PosBonesThumb0[i] = ThumbD[0].transform.position;
                    v_ManoDerecha.v_PosBonesThumb1[i] = ThumbD[1].transform.position;
                    v_ManoDerecha.v_PosBonesThumb2[i] = ThumbD[2].transform.position;

                    //Rotaciones

                    v_ManoDerecha.v_RotBonesIndex0[i] = IndexD[0].transform.rotation.eulerAngles;
                    v_ManoDerecha.v_RotBonesIndex1[i] = IndexD[1].transform.rotation.eulerAngles;
                    v_ManoDerecha.v_RotBonesIndex2[i] = IndexD[2].transform.rotation.eulerAngles;

                    v_ManoDerecha.v_RotBonesMiddle0[i] = MiddleD[0].transform.rotation.eulerAngles;
                    v_ManoDerecha.v_RotBonesMiddle1[i] = MiddleD[1].transform.rotation.eulerAngles;
                    v_ManoDerecha.v_RotBonesMiddle2[i] = MiddleD[2].transform.rotation.eulerAngles;

                    v_ManoDerecha.v_RotBonesPinky0[i] = PinkyD[0].transform.rotation.eulerAngles;
                    v_ManoDerecha.v_RotBonesPinky1[i] = PinkyD[1].transform.rotation.eulerAngles;
                    v_ManoDerecha.v_RotBonesPinky2[i] = PinkyD[2].transform.rotation.eulerAngles;

                    v_ManoDerecha.v_RotBonesRing0[i] = RingD[0].transform.rotation.eulerAngles;
                    v_ManoDerecha.v_RotBonesRing1[i] = RingD[1].transform.rotation.eulerAngles;
                    v_ManoDerecha.v_RotBonesRing2[i] = RingD[2].transform.rotation.eulerAngles;

                    v_ManoDerecha.v_RotBonesThumb0[i] = ThumbD[0].transform.rotation.eulerAngles;
                    v_ManoDerecha.v_RotBonesThumb1[i] = ThumbD[1].transform.rotation.eulerAngles;
                    v_ManoDerecha.v_RotBonesThumb2[i] = ThumbD[2].transform.rotation.eulerAngles;

                    v_ManoDerecha.v_PosBrazo[i] = ForD.transform.position;
                    v_ManoDerecha.v_RotBrazo[i] = ForD.transform.rotation.eulerAngles;

                    v_ManoDerecha.v_PosPalma[i] = PalmD.transform.position;
                    v_ManoDerecha.v_RotPalma[i] = PalmD.transform.rotation.eulerAngles;

                }
                else
                {
                    v_ManoDerecha.v_ManoActiva = false;
                    Debug.Log("Mano Derecha perdida");

                }

                Debug.Log(">Termino el Tiraje " + i);

                yield return new WaitForSeconds(tiempoTMp);
            }

            Debug.Log("Se acciona el guardado en json");
            fn_GuardarDatosJSonFormat(v_NombreArchivo.text, _numeroTirajes);
            Debug.Log("Termino de GuardarInformacion");

            StartCoroutine(WaitToTurnPanelOff(panelGuardar));

            v_ManoDerecha.ClearClass(_numeroTirajes);
            v_ManoIzquierda.ClearClass(_numeroTirajes);

        }

        IEnumerator WaitToTurnPanelOff(GameObject panel)
        {
            panel.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            panel.SetActive(false);
        }

        public IEnumerator CompararDatos(HandRecord _leftHand, HandRecord _rightHand, float _tiempoEntreTirajes)
        {
            float tiempoTMp = _tiempoEntreTirajes / _leftHand.v_NumeroDeTirajes;
            bool[] isLeft = new bool[_leftHand.v_NumeroDeTirajes];
            bool[] isRight = new bool[_leftHand.v_NumeroDeTirajes];
            for (int i = 0; i < _leftHand.v_NumeroDeTirajes; i++)
            {
                //Debug.Log("> Tiraje" + i);
                if (v_ManoIzquierdaActiva && _leftHand.v_ManoActiva)
                {
                    bool rot_Palma = _leftHand.v_RotacionPalma[i] == v_PosicionManoIzquierda;
                    bool estadoThumb = _leftHand.v_EstadoThumb[i] == v_EstadoThumbIzquierdo;
                    bool estadoIndex = _leftHand.v_EstadoIndex[i] == v_EstadoIndexIzquierdo;
                    bool estadoMiddle = _leftHand.v_EstadoMiddle[i] == v_EstadoMiddleIzquierdo;
                    bool estadoRing = _leftHand.v_EstadoRing[i] == v_EstadoRingIzquierdo;
                    bool estadoPinky = _leftHand.v_EstadoPinky[i] == v_EstadoPinkyIzquierdo;

                    bool dedosExtendidos = _leftHand.v_DedosExtendidos[i] == v_NumeroDeDedosActivosHIzquierda;
                   

                    //Posiciones

                    bool[] posBonesIndex = new bool[3];
                    posBonesIndex[0] = Fuzzy.CompareVector(_leftHand.v_PosBonesIndex0[i] , IndexI[0].transform.position);
                    posBonesIndex[1] = Fuzzy.CompareVector(_leftHand.v_PosBonesIndex1[i] , IndexI[1].transform.position);
                    posBonesIndex[2] = Fuzzy.CompareVector(_leftHand.v_PosBonesIndex2[i] , IndexI[2].transform.position);

                    bool[] posBonesMiddle = new bool[3];
                    posBonesMiddle[0] = Fuzzy.CompareVector(_leftHand.v_PosBonesMiddle0[i] , MiddleI[0].transform.position);
                    posBonesMiddle[1] = Fuzzy.CompareVector(_leftHand.v_PosBonesMiddle1[i] , MiddleI[1].transform.position);
                    posBonesMiddle[2] = Fuzzy.CompareVector(_leftHand.v_PosBonesMiddle2[i] , MiddleI[2].transform.position);

                    bool[] posBonesRing = new bool[3];
                    posBonesRing[0] = Fuzzy.CompareVector(_leftHand.v_PosBonesRing0[i] ,RingI[0].transform.position);
                    posBonesRing[1] = Fuzzy.CompareVector(_leftHand.v_PosBonesRing1[i] ,RingI[1].transform.position);
                    posBonesRing[2] = Fuzzy.CompareVector(_leftHand.v_PosBonesRing2[i] ,RingI[2].transform.position);

                    bool[] posBonesPinky = new bool[3];
                    posBonesPinky[0] = Fuzzy.CompareVector(_leftHand.v_PosBonesPinky0[i] , PinkyI[0].transform.position);
                    posBonesPinky[1] = Fuzzy.CompareVector(_leftHand.v_PosBonesPinky1[i] , PinkyI[1].transform.position);
                    posBonesPinky[2] = Fuzzy.CompareVector(_leftHand.v_PosBonesPinky2[i] , PinkyI[2].transform.position);

                    bool[] posBonesThumb = new bool[3];
                    posBonesThumb[0] = Fuzzy.CompareVector(_leftHand.v_PosBonesThumb0[i] , ThumbI[0].transform.position);
                    posBonesThumb[1] = Fuzzy.CompareVector(_leftHand.v_PosBonesThumb1[i] , ThumbI[1].transform.position);
                    posBonesThumb[2] = Fuzzy.CompareVector(_leftHand.v_PosBonesThumb2[i] , ThumbI[2].transform.position);

                    //Rotaciones

                    bool[] rotBonesIndex = new bool[3];
                    rotBonesIndex[0] = Fuzzy.CompareVector(_leftHand.v_RotBonesIndex0[i] , IndexI[0].transform.rotation.eulerAngles);
                    rotBonesIndex[1] = Fuzzy.CompareVector(_leftHand.v_RotBonesIndex1[i] , IndexI[1].transform.rotation.eulerAngles);
                    rotBonesIndex[2] = Fuzzy.CompareVector(_leftHand.v_RotBonesIndex2[i] , IndexI[2].transform.rotation.eulerAngles);

                    bool[] rotBonesMiddle = new bool[3];
                    rotBonesMiddle[0] = Fuzzy.CompareVector(_leftHand.v_RotBonesMiddle0[i] , MiddleI[0].transform.rotation.eulerAngles);
                    rotBonesMiddle[1] = Fuzzy.CompareVector(_leftHand.v_RotBonesMiddle1[i] , MiddleI[1].transform.rotation.eulerAngles);
                    rotBonesMiddle[2] = Fuzzy.CompareVector(_leftHand.v_RotBonesMiddle2[i] , MiddleI[2].transform.rotation.eulerAngles);

                    bool[] rotBonesRing = new bool[3];
                    rotBonesRing[0] = Fuzzy.CompareVector(_leftHand.v_RotBonesRing0[i] , RingI[0].transform.rotation.eulerAngles);
                    rotBonesRing[1] = Fuzzy.CompareVector(_leftHand.v_RotBonesRing1[i] , RingI[1].transform.rotation.eulerAngles);
                    rotBonesRing[2] = Fuzzy.CompareVector(_leftHand.v_RotBonesRing2[i] , RingI[2].transform.rotation.eulerAngles);

                    bool[] rotBonesPinky = new bool[3];
                    rotBonesPinky[0] = Fuzzy.CompareVector(_leftHand.v_RotBonesPinky0[i] , PinkyI[0].transform.rotation.eulerAngles);
                    rotBonesPinky[1] = Fuzzy.CompareVector(_leftHand.v_RotBonesPinky1[i] , PinkyI[1].transform.rotation.eulerAngles);
                    rotBonesPinky[2] = Fuzzy.CompareVector(_leftHand.v_RotBonesPinky2[i] , PinkyI[2].transform.rotation.eulerAngles);

                    bool[] rotBonesThumb = new bool[3];
                    rotBonesThumb[0] = Fuzzy.CompareVector(_leftHand.v_RotBonesThumb0[i] ,ThumbI[0].transform.rotation.eulerAngles);
                    rotBonesThumb[1] = Fuzzy.CompareVector(_leftHand.v_RotBonesThumb1[i] ,ThumbI[1].transform.rotation.eulerAngles);
                    rotBonesThumb[2] = Fuzzy.CompareVector(_leftHand.v_RotBonesThumb2[i] ,ThumbI[2].transform.rotation.eulerAngles);

                    bool posBrazo = Fuzzy.CompareVector(_leftHand.v_PosBrazo[i] , ForI.transform.position);
                    bool rotBrazo = Fuzzy.CompareVector(_leftHand.v_RotBrazo[i] , ForI.transform.rotation.eulerAngles);
                                                                                
                    bool posPalma = Fuzzy.CompareVector(_leftHand.v_PosPalma[i] , PalmI.transform.position);
                    bool rotPalma = Fuzzy.CompareVector(_leftHand.v_RotPalma[i] , PalmI.transform.rotation.eulerAngles);

                    if (rot_Palma && estadoThumb && estadoIndex && estadoMiddle && estadoRing && estadoPinky)
                    {
                        if (posBonesIndex[0] && posBonesIndex[1] && posBonesIndex[2] &&
                            posBonesMiddle[0] && posBonesMiddle[1] && posBonesMiddle[2] &&
                            posBonesRing[0] && posBonesRing[1] && posBonesRing[2] &&
                            posBonesPinky[0] && posBonesPinky[1] && posBonesPinky[2] &&
                            posBonesThumb[0] && posBonesThumb[1] && posBonesThumb[2] &&
                            rotBonesIndex[0] && rotBonesIndex[1] && rotBonesIndex[2] &&
                            rotBonesMiddle[0] && rotBonesMiddle[1] && rotBonesMiddle[2] &&
                            rotBonesRing[0] && rotBonesRing[1] && rotBonesRing[2] &&
                            rotBonesPinky[0] && rotBonesPinky[1] && rotBonesPinky[2] &&
                            rotBonesThumb[0] && rotBonesThumb[1] && rotBonesThumb[2])
                        {
                            if(posBrazo && rotBrazo && posPalma && rotPalma)
                            {
                                isLeft[i] = true;
                            }
                        }

                    }
                }

                Debug.Log("Mano Derecha: " + v_ManoDerechaActiva + _rightHand.v_ManoActiva);
                if (v_ManoDerechaActiva && _rightHand.v_ManoActiva)
                {
                    bool rot_Palma = _rightHand.v_RotacionPalma[i] == v_PosicionManoDerecha;
                    bool estadoThumb = _rightHand.v_EstadoThumb[i] == v_EstadoThumbDerecho;
                    bool estadoIndex = _rightHand.v_EstadoIndex[i] == v_EstadoIndexDerecho;
                    bool estadoMiddle = _rightHand.v_EstadoMiddle[i] == v_EstadoMiddleDerecho;
                    bool estadoRing = _rightHand.v_EstadoRing[i] == v_EstadoRingDerecho;
                    bool estadoPinky = _rightHand.v_EstadoPinky[i] == v_EstadoPinkyDerecho;

                    Debug.Log("Rot palma: " + _rightHand.v_RotacionPalma[i] + " - " + v_PosicionManoDerecha + "\n"+
                        "Estado Thumb: " + _rightHand.v_EstadoThumb[i] + " - " + v_EstadoThumbDerecho + "\n"+
                        "Estado Index: " + _rightHand.v_EstadoIndex[i] + " - " + v_EstadoIndexDerecho + "\n" +
                        "Estado Middle: " + _rightHand.v_EstadoMiddle[i] + " - " + v_EstadoMiddleDerecho + "\n" +
                        "Estado Ring: " + _rightHand.v_EstadoRing[i] + " - " + v_EstadoPinkyDerecho + "\n" +
                        "Estado Pinky: " + _rightHand.v_EstadoPinky[i] + " - " + v_EstadoPinkyDerecho + "\n");

                    bool dedosExtendidos = Fuzzy.CompareInt(_rightHand.v_DedosExtendidos[i], v_NumeroDeDedosActivosHDerecha);


                    //Posiciones
                    #region POSICIONES
                    bool[] posBonesIndex = new bool[3];
                    posBonesIndex[0] = Fuzzy.CompareVector(_rightHand.v_PosBonesIndex0[i] , IndexD[0].transform.position);
                    posBonesIndex[1] = Fuzzy.CompareVector(_rightHand.v_PosBonesIndex1[i] , IndexD[1].transform.position);
                    posBonesIndex[2] = Fuzzy.CompareVector(_rightHand.v_PosBonesIndex2[i] , IndexD[2].transform.position);

                    bool[] posBonesMiddle = new bool[3];
                    posBonesMiddle[0] = Fuzzy.CompareVector(_rightHand.v_PosBonesMiddle0[i] , MiddleD[0].transform.position);
                    posBonesMiddle[1] = Fuzzy.CompareVector(_rightHand.v_PosBonesMiddle1[i] , MiddleD[1].transform.position);
                    posBonesMiddle[2] = Fuzzy.CompareVector(_rightHand.v_PosBonesMiddle2[i] , MiddleD[2].transform.position);
                                                                                                                           
                    bool[] posBonesRing = new bool[3];
                    posBonesRing[0] = Fuzzy.CompareVector(_rightHand.v_PosBonesRing0[i] , RingD[0].transform.position);
                    posBonesRing[1] = Fuzzy.CompareVector(_rightHand.v_PosBonesRing1[i] , RingD[1].transform.position);
                    posBonesRing[2] = Fuzzy.CompareVector(_rightHand.v_PosBonesRing2[i] , RingD[2].transform.position);

                    bool[] posBonesPinky = new bool[3];
                    posBonesPinky[0] = Fuzzy.CompareVector(_rightHand.v_PosBonesPinky0[i] , PinkyD[0].transform.position);
                    posBonesPinky[1] = Fuzzy.CompareVector(_rightHand.v_PosBonesPinky1[i] , PinkyD[1].transform.position);
                    posBonesPinky[2] = Fuzzy.CompareVector(_rightHand.v_PosBonesPinky2[i] , PinkyD[2].transform.position);

                    bool[] posBonesThumb = new bool[3];
                    posBonesThumb[0] =  Fuzzy.CompareVector(_rightHand.v_PosBonesThumb0[i]  ,   ThumbD[0].transform.position);
                    posBonesThumb[1] =  Fuzzy.CompareVector(_rightHand.v_PosBonesThumb1[i]  ,   ThumbD[1].transform.position);
                    posBonesThumb[2] =  Fuzzy.CompareVector(_rightHand.v_PosBonesThumb2[i]  ,   ThumbD[2].transform.position);
                    #endregion

                    //Rotaciones
                    #region ROTACIONES
                    bool[] rotBonesIndex = new bool[3];
                    rotBonesIndex[0] = Fuzzy.CompareVector(_rightHand.v_RotBonesIndex0[i] , IndexD[0].transform.rotation.eulerAngles);
                    rotBonesIndex[1] = Fuzzy.CompareVector(_rightHand.v_RotBonesIndex1[i] , IndexD[1].transform.rotation.eulerAngles);
                    rotBonesIndex[2] = Fuzzy.CompareVector(_rightHand.v_RotBonesIndex2[i] , IndexD[2].transform.rotation.eulerAngles);

                    bool[] rotBonesMiddle = new bool[3];
                    rotBonesMiddle[0] = Fuzzy.CompareVector(_rightHand.v_RotBonesMiddle0[i] , MiddleD[0].transform.rotation.eulerAngles);
                    rotBonesMiddle[1] = Fuzzy.CompareVector(_rightHand.v_RotBonesMiddle1[i] , MiddleD[1].transform.rotation.eulerAngles);
                    rotBonesMiddle[2] = Fuzzy.CompareVector(_rightHand.v_RotBonesMiddle2[i] , MiddleD[2].transform.rotation.eulerAngles);

                    bool[] rotBonesRing = new bool[3];
                    rotBonesRing[0] = Fuzzy.CompareVector(_rightHand.v_RotBonesRing0[i] , RingD[0].transform.rotation.eulerAngles);
                    rotBonesRing[1] = Fuzzy.CompareVector(_rightHand.v_RotBonesRing1[i] , RingD[1].transform.rotation.eulerAngles);
                    rotBonesRing[2] = Fuzzy.CompareVector(_rightHand.v_RotBonesRing2[i] , RingD[2].transform.rotation.eulerAngles);

                    bool[] rotBonesPinky = new bool[3];
                    rotBonesPinky[0] = Fuzzy.CompareVector(_rightHand.v_RotBonesPinky0[i] , PinkyD[0].transform.rotation.eulerAngles);
                    rotBonesPinky[1] = Fuzzy.CompareVector(_rightHand.v_RotBonesPinky1[i] , PinkyD[1].transform.rotation.eulerAngles);
                    rotBonesPinky[2] = Fuzzy.CompareVector(_rightHand.v_RotBonesPinky2[i] , PinkyD[2].transform.rotation.eulerAngles);

                    bool[] rotBonesThumb = new bool[3];
                    rotBonesThumb[0] = Fuzzy.CompareVector(_rightHand.v_RotBonesThumb0[i] , ThumbD[0].transform.rotation.eulerAngles);
                    rotBonesThumb[1] = Fuzzy.CompareVector(_rightHand.v_RotBonesThumb1[i] , ThumbD[1].transform.rotation.eulerAngles);
                    rotBonesThumb[2] = Fuzzy.CompareVector(_rightHand.v_RotBonesThumb2[i] , ThumbD[2].transform.rotation.eulerAngles);
                    #endregion

                    bool posBrazo = Fuzzy.CompareVector(_rightHand.v_PosBrazo[i] ,ForD.transform.position);
                    bool rotBrazo = Fuzzy.CompareVector(_rightHand.v_RotBrazo[i] ,ForD.transform.rotation.eulerAngles);

                    bool posPalma = Fuzzy.CompareVector(_rightHand.v_PosPalma[i] , PalmD.transform.position);
                    bool rotPalma = Fuzzy.CompareVector(_rightHand.v_RotPalma[i] , PalmD.transform.rotation.eulerAngles);

                    Debug.Log("Palma: " + rot_Palma);
                    if (rot_Palma && estadoThumb && estadoIndex && estadoMiddle && estadoRing && estadoPinky)
                    {
                        isRight[i] = true;
                        //Debug.Log("Well, so far so good");
                        //if (posBonesIndex[0] && posBonesIndex[1] && posBonesIndex[2] &&
                        //    posBonesMiddle[0] && posBonesMiddle[1] && posBonesMiddle[2] &&
                        //    posBonesRing[0] && posBonesRing[1] && posBonesRing[2] &&
                        //    posBonesPinky[0] && posBonesPinky[1] && posBonesPinky[2] &&
                        //    posBonesThumb[0] && posBonesThumb[1] && posBonesThumb[2] &&
                        //    rotBonesIndex[0] && rotBonesIndex[1] && rotBonesIndex[2] &&
                        //    rotBonesMiddle[0] && rotBonesMiddle[1] && rotBonesMiddle[2] &&
                        //    rotBonesRing[0] && rotBonesRing[1] && rotBonesRing[2] &&
                        //    rotBonesPinky[0] && rotBonesPinky[1] && rotBonesPinky[2] &&
                        //    rotBonesThumb[0] && rotBonesThumb[1] && rotBonesThumb[2])
                        //{
                        //    Debug.Log("I got all pos and rot right!");
                        //    if (posBrazo && rotBrazo && posPalma && rotPalma)
                        //    {
                        //        Debug.Log("This part is tricku");
                        //        isRight[i] = true;
                        //    }
                        //}

                    }

                }


                Debug.Log("Is right? i = " + i + " "+ isRight[i]);
                //Debug.Log(">Termino el Tiraje " + i);

                yield return new WaitForSeconds(tiempoTMp);
            }

            //Do whatever to mark as done
            if((_leftHand.v_ManoActiva && isLeft[0]) || (_rightHand.v_ManoActiva && isRight[0]))
            {
                StartCoroutine(WaitToTurnPanelOff(matchFound));
            }

        }

        IEnumerator extendedFingerWatcher()
        {
            Hand ManoDerecha = new Hand();
            Hand ManoIzquierda=new Hand();

            while (true)
            {
                if (v_HandModelDerecha != null && v_HandModelDerecha.IsTracked)
                {
                    v_ManoDerechaActiva = true;

                    if (v_HandModelDerecha.GetLeapHand().IsRight)
                        ManoDerecha = v_HandModelDerecha.GetLeapHand();

                    if (v_HandModelDerecha.IsTracked)
                    {
                        v_NumeroDeDedosActivosHDerecha = 0;
                        for (int f = 0; f < 5; f++)
                        {
                            if (ManoDerecha.Fingers[f].IsExtended)
                            {
                                v_NumeroDeDedosActivosHDerecha++;
                            }
                        }

                        v_EstadoThumbDerecho = fn_fingerState(ManoDerecha.Fingers[0]);
                        v_EstadoIndexDerecho = fn_fingerState(ManoDerecha.Fingers[1]);
                        v_EstadoMiddleDerecho = fn_fingerState(ManoDerecha.Fingers[2]);
                        v_EstadoPinkyDerecho = fn_fingerState(ManoDerecha.Fingers[4]);
                        v_EstadoRingDerecho = fn_fingerState(ManoDerecha.Fingers[3]);
                    }
                }
                else
                {
                    v_EstadoIndexDerecho = v_EstadoMiddleDerecho = v_EstadoPinkyDerecho = v_EstadoRingDerecho = v_EstadoThumbDerecho = 0;
                    v_NumeroDeDedosActivosHDerecha = 0;
                    v_ManoDerechaActiva = false;
                    v_PosicionManoDerecha = "";
                }
                if (v_HandModelIzquierda != null && v_HandModelIzquierda.IsTracked)
                {
                    v_ManoIzquierdaActiva = true;
                    if (v_HandModelIzquierda.GetLeapHand().IsLeft)
                        ManoIzquierda = v_HandModelIzquierda.GetLeapHand();

                    if (v_HandModelIzquierda.IsTracked)
                    {
                        v_NumeroDeDedosActivosHIzquierda = 0;
                        for (int f = 0; f < 5; f++)
                        {
                            if (ManoIzquierda.Fingers[f].IsExtended)
                            {
                                v_NumeroDeDedosActivosHIzquierda++;
                            }
                        }
                        v_EstadoThumbIzquierdo = fn_fingerState(ManoIzquierda.Fingers[0]);
                        v_EstadoIndexIzquierdo = fn_fingerState(ManoIzquierda.Fingers[1]);
                        v_EstadoMiddleIzquierdo = fn_fingerState(ManoIzquierda.Fingers[2]);
                        v_EstadoPinkyIzquierdo = fn_fingerState(ManoIzquierda.Fingers[4]);
                        v_EstadoRingIzquierdo = fn_fingerState(ManoIzquierda.Fingers[3]);
                    }
                }
                else
                {
                    v_EstadoPinkyIzquierdo = v_EstadoMiddleIzquierdo = v_EstadoIndexIzquierdo = v_EstadoRingIzquierdo = v_EstadoThumbIzquierdo = 0;
                    v_NumeroDeDedosActivosHIzquierda = 0;
                    v_ManoIzquierdaActiva = false;
                    v_PosicionManoIzquierda = "";

                }
                yield return new WaitForSeconds(v_periodoActualizacion);
            }
        }

        #endregion

        #region ///Detector de dedos

        public int fn_fingerState(Finger _finger)
            {
                int state = 0;

                if (_finger.IsExtended)
                    state = 1;
                else
                    state = -1;

                return state;
            }

            private bool matchFingerState(Finger finger, PointingState requiredState)
            {
                return (requiredState == PointingState.Either) ||
                       (requiredState == PointingState.Extended && finger.IsExtended) ||
                       (requiredState == PointingState.NotExtended && !finger.IsExtended);
            }

        #endregion


        #region ///Detectores de posiciones de palmas

            public void fn_RotacionPalmaIzquierda(string _posicion)
            {
                v_PosicionManoIzquierda = _posicion;
            }
            public void fn_RotacionPalmaDerecha(string _posicion)
            {
                v_PosicionManoDerecha = _posicion;
            }

        #endregion
    }
}