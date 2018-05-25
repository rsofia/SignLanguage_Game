using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_LeapHandGestureC : MonoBehaviour {

    [Header("Settings")]
    [Tooltip("Unidad en segundos para actualizacion")]
    public float v_frecuencia = 0.1f;
    [Tooltip("Unidad para checar la tolerancia entre manos para checar movimiento")]
    public float v_Tolerancia = 0.03f;
    [Tooltip("Multiplica el valor de zoom")]
    public float multiplicadorZoom = 10.0f;
    //[Header("Direcciones de rotacion de manos")]
    string v_DirectionRight;
    string v_DirectionLeft;
    //[Header("Manos Activas en escena")]
    [HideInInspector]
    public bool v_HandRightActiva;
    [HideInInspector]
    public bool v_HandLeftActiva;
    [Header("Hands models")]
    public GameObject RHand;
    public GameObject LHand;
    public GameObject RPalma;
    public GameObject LPalma;

    //[Header("Parametros para checar gestos")]
    [HideInInspector]
    public Vector3 v_Inicial = new Vector3();
    [HideInInspector]
    public Vector3 v_Salida = new Vector3();
    [HideInInspector]
    public bool Checar = false;
    bool fistRight = false;
    bool fistLeft = false;
    float DistanciaPalms = 0.0f;
    bool Dete2Hands = false;
    Vector3 v_InicialLPalm = new Vector3();
    Vector3 v_InicialRPalm = new Vector3();
    int v_DirectionRHand = 0;
    int v_DirectionLHand = 0;

    /// <summary>
    /// Funcion para detectar swipe con 1 mano activa en 4 axis funciona con mano derecha e izquierda. 
    /// </summary>
    /// <param name="_PosInicial"> vector inicial de la mano</param>
    /// <param name="_PosSalida"> vector final/next de la mano</param>
    /// <param name="_DirePalma"> direccion en string de la rotacion de la mano</param>
    /// <param name="_direccion"> direcion de la deteccion true = derecha , false = izquierda</param>
    private void fn_DetectorSwipe4axis(Vector3 _PosInicial, Vector3 _PosSalida, string _DirePalma , bool _direccion)
    {
        Checar = false;
        if (_direccion)
        {
            switch (_DirePalma)
            {
                case "left":
                    {
                        if (_PosInicial.x > _PosSalida.x)
                            fn_swipeRHleft();
                    }
                    break;
                case "right":
                    {
                        if (_PosInicial.x < _PosSalida.x)
                            fn_swipeRHright();
                    }
                    break;
                case "down":
                    {
                        if (_PosInicial.y > _PosSalida.y)
                            fn_swipeRHdown();
                    }
                    break;
                case "up":
                    {
                        if (_PosInicial.y < _PosSalida.y)
                            fn_swipeRHup();
                    }
                    break;

                default:
                    break;
            }
        }
        else
        {
            switch (_DirePalma)
            {
                case "left":
                    {
                        if (_PosInicial.x > _PosSalida.x)
                            fn_swipeLHleft();
                    }
                    break;
                case "right":
                    {
                        if (_PosInicial.x < _PosSalida.x)
                            fn_swipeLHright();
                }
                    break;
                case "down":
                    {
                        if (_PosInicial.y > _PosSalida.y)
                            fn_swipeLHdown();
                    }
                    break;
                case "up":
                    {
                        if (_PosInicial.y < _PosSalida.y)
                            fn_swipeLHup();
                    }
                    break;

                default:
                    break;
            }
        }
    }
    /// <summary>
    /// Funcion para detectar gestos de 2 manos activas
    /// </summary>
    private void fn_DetectorDobleHanGesture()
    {
        float tmpDistancia = Vector3.Distance(RPalma.transform.position, LPalma.transform.position);
        DistanciaPalms = tmpDistancia;

        fn_MovDirectionHands();

        if (v_DirectionRHand > 0 && v_DirectionLHand < 0)
        {
            fn_ZoomPositive(DistanciaPalms,multiplicadorZoom);
        }
        if (v_DirectionRHand < 0 && v_DirectionLHand > 0)
        {
            fn_ZoomNegative(DistanciaPalms,multiplicadorZoom);
        }
    }

    /// <summary>
    /// Detecta la direccion de movimiento de las manos para gestos de doble mano
    /// </summary>
    private void fn_MovDirectionHands()
    {
        //Checa el movimiento de cada mano para saber hacia que lado se estan moviendo
        if (v_InicialLPalm.x - v_Tolerancia > LPalma.transform.position.x)
            v_DirectionLHand = -1;
        else if (v_InicialLPalm.x + v_Tolerancia < LPalma.transform.position.x)
            v_DirectionLHand = 1;
        else
            v_DirectionLHand = 0;


        if (v_InicialRPalm.x - v_Tolerancia > RPalma.transform.position.x)
            v_DirectionRHand = -1;
        else if (v_InicialRPalm.x + v_Tolerancia < RPalma.transform.position.x)
            v_DirectionRHand = 1;
        else
            v_DirectionRHand = 0;
    }
    /// <summary>
    /// Detecta cuando estan las 2 manos o no activas
    /// </summary>
    private void fn_DetectorHandsActive()
    {
        if(v_HandRightActiva == false && v_HandLeftActiva == false)
        {
            v_DirectionRight = "";
            v_DirectionLeft = "";
            DistanciaPalms = 0;
            v_DirectionRHand = 0;
            v_DirectionLHand = 0;

        }
    }

   
    /// <summary>
    /// Funcion para inicializar y correr el detector de gestos custom
    /// </summary>
    public void fn_initDetector()
    {
        StartCoroutine(fn_DetectorLoop());
    }
    
    /// <summary>
    /// Funcion encargada de detectar por periodos de tiempo los gestos realizados
    /// </summary>
    /// <returns></returns>
    IEnumerator fn_DetectorLoop()
    {
        while (true)
        {
            v_HandRightActiva = RHand.activeInHierarchy;
            v_HandLeftActiva = LHand.activeInHierarchy;

            if (v_HandRightActiva == true && v_HandLeftActiva == true) //Dos manos activas
            {
                Checar = false;
                if(Dete2Hands)
                    fn_DetectorDobleHanGesture();
            }
            else // 1 de las 2 manos activas
            {
                Dete2Hands = false;
                if (v_HandRightActiva && Checar == true)
                    fn_DetectorSwipe4axis(v_Inicial, v_Salida, v_DirectionRight, true);
                if (v_HandLeftActiva && Checar == true)
                    fn_DetectorSwipe4axis(v_Inicial, v_Salida, v_DirectionLeft, false);
            }


            fn_DetectorHandsActive();

            yield return new WaitForSeconds(v_frecuencia);
        }
    }

    //Funciones para los detectores de leapmotion nativos
    public void fn_LHandfist(bool _state)
    {
        fistRight = _state;
    }
    public void fn_RHandFist(bool _state)
    {
        fistLeft = _state;
    }

    public void fn_GateTrueHandsFist()
    {
        //Debug.Log("true");
        Dete2Hands = true;
        v_InicialRPalm = RPalma.transform.position;
        v_InicialLPalm = LPalma.transform.position;

    }
    public void fn_GateFalseHandsFist()
    {
        //Debug.Log("false");
        Dete2Hands = false;
    }

    public void fn_DetectorDirectionPalmRight(string _direction)
    {
        v_DirectionRight = _direction;
    }
    public void fn_DetectorDirectionPalmLeft(string _direction)
    {
        v_DirectionLeft = _direction;
    }
    //////////

    /// <summary>
    /// Funcion de mano izquierda swipe left
    /// </summary>
    public virtual void fn_swipeLHleft()
    {
        Debug.Log("Mano izquierda swipe left");
    }
    /// <summary>
    /// Funcion de mano izquierda swipe right
    /// </summary>
    public virtual void fn_swipeLHright()
    {
        Debug.Log("Mano izquierda swipe right");
    }
    /// <summary>
    /// Funcion de mano izquierda swipe down
    /// </summary>
    public virtual void fn_swipeLHdown()
    {
        Debug.Log("Mano izquierda swipe down");
    }
    /// <summary>
    /// Funcion de mano izquierda swipe up
    /// </summary>
    public virtual void fn_swipeLHup()
    {
        Debug.Log("Mano izquierda swipe up");
    }



    /// <summary>
    /// Funcion de mano derecha swipe left
    /// </summary>
    public virtual void fn_swipeRHleft()
    {
        Debug.Log("Mano derecha swipe left");
    }
    /// <summary>
    /// Funcion de mano derecha swipe right
    /// </summary>
    public virtual void fn_swipeRHright()
    {
        Debug.Log("Mano derecha swipe right");
    }
    /// <summary>
    /// Funcion de mano derecha swipe down
    /// </summary>
    public virtual void fn_swipeRHdown()
    {
        Debug.Log("Mano derecha swipe down");
    }
    /// <summary>
    /// Funcion de mano derecha swipe up
    /// </summary>
    public virtual void fn_swipeRHup()
    {
        Debug.Log("Mano derecha swipe up");
    }
    /// <summary>
    /// Funcion a doble mano para detectar zoom +
    /// </summary>
    /// <param name="_distance">distancia entre las palmas</param>
    /// <param name="_multiply">float para multiplicar el zoom (sugerencia * 10)</param>
    public virtual void fn_ZoomPositive(float _distance , float _multiply)
    {
        Debug.Log("Zoom+ Cambio zoom" + _distance*multiplicadorZoom);
    }
    /// <summary>
    /// Funcion a doble mano para detectar zoom -
    /// </summary>
    /// <param name="_distance">distancia entre las palmas</param>
    /// <param name="_multiply">float para multiplicar el zoom (sugerencia * 10)</param>
    public virtual void fn_ZoomNegative(float _distance, float _multiply)
    {
        Debug.Log("Zoom- Cambio zoom" + _distance * multiplicadorZoom);
    }
}
