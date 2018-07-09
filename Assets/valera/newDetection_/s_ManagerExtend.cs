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
        public string v_RotacionPalma;

        [SerializeField]
        public int v_NumeroDeTirajes;

        [SerializeField]
        public int v_EstadoThumb;
        [SerializeField]
        public int v_EstadoIndex;
        [SerializeField]
        public int v_EstadoMiddle;
        [SerializeField]
        public int v_EstadoPinky;
        [SerializeField]
        public int v_EstadoRing;

        [SerializeField]
        public int v_DedosExtendidos;

        [SerializeField]
        public Vector3[,] v_PosBonesThumb;
        [SerializeField]
        public Vector3[,] v_PosBonesIndex;
        [SerializeField]
        public Vector3[,] v_PosBonesMiddle;
        [SerializeField]
        public Vector3[,] v_PosBonesPinky;
        [SerializeField]
        public Vector3[,] v_PosBonesRing;

        [SerializeField]
        public Vector3[,] v_RotBonesThumb;
        [SerializeField]
        public Vector3[,] v_RotBonesIndex;
        [SerializeField]
        public Vector3[,] v_RotBonesMiddle;
        [SerializeField]
        public Vector3[,] v_RotBonesPinky;
        [SerializeField]
        public Vector3[,] v_RotBonesRing;

        [SerializeField]
        public Vector3[,] v_PosRotBrazo;
        [SerializeField]
        public Vector3[,] v_PosRotPalma;


        public HandRecord(int _numeroTiraje)
        {
            v_ManoActiva = false;

            v_RotacionPalma = "";

            v_NumeroDeTirajes = _numeroTiraje;

            v_EstadoThumb     = 0;
            v_EstadoIndex     = 0;
            v_EstadoMiddle    = 0;
            v_EstadoPinky     = 0;
            v_EstadoRing      = 0;
            v_DedosExtendidos = 0;

            v_PosBonesThumb  = new Vector3[3, v_NumeroDeTirajes];
            v_PosBonesIndex  = new Vector3[3, v_NumeroDeTirajes];
            v_PosBonesMiddle = new Vector3[3, v_NumeroDeTirajes];
            v_PosBonesPinky  = new Vector3[3, v_NumeroDeTirajes];
            v_PosBonesRing   = new Vector3[3, v_NumeroDeTirajes];

            v_RotBonesThumb  = new Vector3[3, v_NumeroDeTirajes];
            v_RotBonesIndex  = new Vector3[3, v_NumeroDeTirajes];
            v_RotBonesMiddle = new Vector3[3, v_NumeroDeTirajes];
            v_RotBonesPinky  = new Vector3[3, v_NumeroDeTirajes];
            v_RotBonesRing   = new Vector3[3, v_NumeroDeTirajes];

            v_PosRotPalma    = new Vector3[2, v_NumeroDeTirajes];
            v_PosRotBrazo    = new Vector3[2, v_NumeroDeTirajes];

         


            Debug.Log(v_NumeroDeTirajes);
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

        [Header("Objetos de ref Mano Derecha")]
        public GameObject[] ThumbD;
        public GameObject[] IndexD;
        public GameObject[] MiddleD;
        public GameObject[] PinkyD;
        public GameObject[] RingD;


        private IEnumerator watcherCoroutine;

        void Start()
        {
            int _tirajes = 0;
            switch (v_CiclosDeGravacion)
            {
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
        }
        void Awake()
        {
            watcherCoroutine = extendedFingerWatcher();
        }
        void OnEnable()
        {
            StartCoroutine(watcherCoroutine);
        }
        void Update()
        {

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
            Debug.Log("Se activo corutina de guardado");
            StartCoroutine(fn_GuardarDatos(_tirajes, _tiempoEnTiraje));
        }

        #region
        public void fn_GuardarDatosJSonFormat(string _nombreGesto)
        {

            string jsonManoIzquierda = JsonUtility.ToJson(v_ManoIzquierda);
            string jsonManoDerecha = JsonUtility.ToJson(v_ManoDerecha);

            if (!Directory.Exists("GestosJson"))
                Directory.CreateDirectory("GestosJson");

            string path = "GestosJson/" + _nombreGesto + ".json";

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
            Debug.Log(tiempoTMp);


            for (int i = 0; i < _numeroTirajes; i++)
            {
                Debug.Log("Tiraje"+i);
                if(v_ManoIzquierdaActiva)
                {
                    //Agregar tirajes de estados de cada dedo y cantidades de dedos.
                    v_ManoIzquierda.v_ManoActiva = true;

                    v_ManoIzquierda.v_RotacionPalma = v_PosicionManoIzquierda;

                    v_ManoIzquierda.v_EstadoThumb = v_EstadoThumbIzquierdo;
                    v_ManoIzquierda.v_EstadoIndex = v_EstadoIndexIzquierdo;
                    v_ManoIzquierda.v_EstadoMiddle = v_EstadoMiddleIzquierdo;
                    v_ManoIzquierda.v_EstadoPinky = v_EstadoPinkyIzquierdo;
                    v_ManoIzquierda.v_EstadoRing = v_EstadoRingIzquierdo;

                    v_ManoIzquierda.v_DedosExtendidos = v_NumeroDeDedosActivosHIzquierda;


                    //cambiar sistema de clase para poder enviar transform y rotation
                    //cambio de sistema [,] error al guardar informacion 

                    v_ManoIzquierda.v_PosBonesThumb[0, i] = ThumbI[0].transform.position; 
                    v_ManoIzquierda.v_PosBonesThumb[1, i] = ThumbI[1].transform.position; 
                    v_ManoIzquierda.v_PosBonesThumb[2, i] = ThumbI[2].transform.position;

                    
                }
                else
                {
                    v_ManoIzquierda.v_ManoActiva = false;
                    Debug.Log("Mano izquierda perdida");

                }

                if (v_ManoDerechaActiva)
                {
                    //Agregar tirajes de estados de cada dedo y cantidades de dedos.

                    v_ManoDerecha.v_ManoActiva = true;

                    v_ManoDerecha.v_RotacionPalma = v_PosicionManoDerecha;

                    v_ManoDerecha.v_EstadoThumb = v_EstadoThumbDerecho;
                    v_ManoDerecha.v_EstadoIndex = v_EstadoIndexDerecho;
                    v_ManoDerecha.v_EstadoMiddle = v_EstadoMiddleDerecho;
                    v_ManoDerecha.v_EstadoPinky = v_EstadoPinkyDerecho;
                    v_ManoDerecha.v_EstadoRing = v_EstadoRingDerecho;

                    v_ManoDerecha.v_DedosExtendidos = v_NumeroDeDedosActivosHDerecha;

                    //cambiar sistema de clase para poder enviar transform y rotation
                    //cambio de sistema [,] error al guardar informacion 

                }
                else
                {
                    v_ManoDerecha.v_ManoActiva = false;
                    Debug.Log("Mano Derecha perdida");

                }


                yield return new WaitForSeconds(tiempoTMp);
            }


            //agregar metodo para guardar de forma local los datos de las clases
            //json / binary format
            Debug.Log("Se acciona el guardado en json");
            fn_GuardarDatosJSonFormat(v_NombreArchivo.text);
            Debug.Log("Termino de GuardarInformacion");
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