using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attributes;


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

    [SerializeField]
    public class HandRecord
    {
        public bool v_ManoActiva;

        public string v_RotacionPalma;

        public int v_NumeroDeTirajes;

        public int EstadoThumb = 0;
        public int EstadoIndex = 0;
        public int EstadoMiddle = 0;
        public int EstadoPinky = 0;
        public int EstadoRing = 0;

        public int extendedCount = 0;

        public Vector3[,] BonesThumb;
        public Vector3[,] BonesIndex;
        public Vector3[,] BonesMiddle;
        public Vector3[,] BonesPinky;
        public Vector3[,] BonesRing;

        public GameObject[] brazo;
        public GameObject[] palma;

        public GameObject[] GuiaThumb;
        public GameObject[] GuiaIndex;
        public GameObject[] GuiaMiddle;
        public GameObject[] GuiaPinky;
        public GameObject[] GuiaRing;

        public void inicializar(int _numeroTiraje)
        {
            BonesThumb = new Vector3[3,_numeroTiraje];
            BonesIndex = new Vector3[3,_numeroTiraje];
            BonesMiddle = new Vector3[3,_numeroTiraje];
            BonesPinky = new Vector3[3,_numeroTiraje];
            BonesRing = new Vector3[3,_numeroTiraje];

            brazo = new GameObject[_numeroTiraje];
            palma = new GameObject[_numeroTiraje];

            GuiaThumb = new GameObject[_numeroTiraje];
            GuiaIndex = new GameObject[_numeroTiraje];
            GuiaMiddle = new GameObject[_numeroTiraje];
            GuiaPinky = new GameObject[_numeroTiraje];
            GuiaRing = new GameObject[_numeroTiraje];
        }


    }

    public class s_ManagerExtend : Detector
    {

        [Header("Configuracion")]
        [MinValue(0.1f)]
        public float v_periodoActualizacion = 0.1f;
        public TiemposDisponibles v_TiempoDeGrabado;
        public CiclosGravado v_CiclosDeGravacion;


        [Header("Requerimientos")]
        [Tooltip("The hand model to watch. Set automatically if detector is on a hand.")]
        public HandModelBase HandModel = null;


        [Header("Estados")]
        public bool v_ManoIzquierdaActiva;
        public bool v_ManoDerechaActiva;

        [Header("Datos a Guardar")]
        public HandRecord v_ManoIzquierda;
        public HandRecord v_ManoDerecha;

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


        private IEnumerator watcherCoroutine;

        void Start() {

        }
        void Awake()
        {
            watcherCoroutine = extendedFingerWatcher();
        }
        void OnEnable()
        {
            StartCoroutine(watcherCoroutine);
        }
        void Update() {

        }


        public void GuardarTiraje()
        {

            int _tirajes = 0;
            int _tiempoEnTiraje = 0;

            //Agregar Metodo para convertir los Enums a datos validos para ser procesados

            StartCoroutine(fn_GuardarDatos(_tirajes, _tiempoEnTiraje));
        }

        #region
            public void fn_GuardarDatosJSonFormat()
            {
                //funcion para guardar toda la clase de forma de json 
                //formato standart para poder hacer una lectura de forma nativa
            }
        
            public void fn_GuardarDatosBinaryFormat()
            {
                //funcion de respaldo para guardar datos de forma binaria
                //de ser necesario agregarla
            }    
        #endregion

        #region ///Corutinas

        IEnumerator fn_GuardarDatos(int _numeroTirajes, float _tiempoEntreTirajes)
        {

            ///agregar condicionales para llenar ambas manos o solo 1 mano siendo el caso
            ///Guardar datos individuales de cada parametro en la clase correspondiente

            for(int i = 0; i < _numeroTirajes; i++)
            {

                yield return new WaitForSeconds(_numeroTirajes);
            }


            //agregar metodo para guardar de forma local los datos de las clases
            //json / binary format


            Debug.Log("Termino de GuardarInformacion");
        }


        IEnumerator extendedFingerWatcher()
        {
            Hand ManoDerecha = new Hand();
            Hand ManoIzquierda=new Hand();

            while (true)
            {
                if (HandModel != null && HandModel.IsTracked)
                {
                    if(HandModel.GetLeapHand().IsLeft)
                        ManoIzquierda = HandModel.GetLeapHand();
                    if(HandModel.GetLeapHand().IsRight)
                        ManoDerecha = HandModel.GetLeapHand();

                    if (HandModel.IsTracked)
                    {
                        v_NumeroDeDedosActivosHIzquierda = 0;
                        v_NumeroDeDedosActivosHDerecha = 0;
                        for (int f = 0; f < 5; f++)
                        {

                            if (ManoIzquierda.Fingers[f].IsExtended)
                            {
                                v_NumeroDeDedosActivosHIzquierda++;
                            }
                            if (ManoDerecha.Fingers[f].IsExtended)
                            {
                                v_NumeroDeDedosActivosHDerecha++;
                            }
                        }
                    }
                }
                else
                {
                    v_EstadoIndexDerecho = v_EstadoMiddleDerecho = v_EstadoPinkyDerecho = v_EstadoRingDerecho = v_EstadoThumbDerecho = 0;
                    v_EstadoPinkyIzquierdo = v_EstadoMiddleIzquierdo = v_EstadoPinkyIzquierdo = v_EstadoRingIzquierdo = v_EstadoThumbIzquierdo = 0;

                    v_NumeroDeDedosActivosHIzquierda = v_NumeroDeDedosActivosHDerecha = 0;
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