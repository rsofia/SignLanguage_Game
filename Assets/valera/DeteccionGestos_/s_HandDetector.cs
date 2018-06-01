using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attributes;


namespace Leap.Unity
{
    public class s_HandDetector : Detector
    {
        [Units("seconds")]
        [MinValue(0)]
        public float Period = 0.1f; //seconds
        [Tooltip("The hand model to watch. Set automatically if detector is on a hand.")]
        public HandModelBase HandModel = null;

        public bool v_diestro;

        public int v_EstadoThumb;
        public int v_EstadoIndex;
        public int v_EstadoMiddle;
        public int v_EstadoPinky;
        public int v_EstadoRing;
        public int v_extendedCount = 0;
        public  string v_PosicionManoDerecha;

        private IEnumerator watcherCoroutine;

        void Awake()
        {
            watcherCoroutine = extendedFingerWatcher();
        }
        void OnEnable()
        {
            StartCoroutine(watcherCoroutine);
        }
        void Start()
        {
            v_EstadoThumb = v_EstadoIndex = v_EstadoMiddle = v_EstadoPinky = v_EstadoRing = 0;
            v_PosicionManoDerecha = "";

        }

        void Update()
        {

        }

        IEnumerator extendedFingerWatcher()
        {
            Hand hand;
            while (true)
            {
                if (HandModel != null && HandModel.IsTracked)
                {
                    hand = HandModel.GetLeapHand();
                    if (HandModel.IsTracked)
                    {
                        v_extendedCount = 0;
                        for (int f = 0; f < 5; f++)
                        {

                            if (hand.Fingers[f].IsExtended)
                            {
                                v_extendedCount++;
                            }
                        }

                        v_EstadoThumb = fn_fingerState(hand.Fingers[0]);
                        v_EstadoIndex = fn_fingerState(hand.Fingers[1]);
                        v_EstadoMiddle = fn_fingerState(hand.Fingers[2]);
                        v_EstadoPinky = fn_fingerState(hand.Fingers[4]);
                        v_EstadoRing = fn_fingerState(hand.Fingers[3]);

                    }
                }
                else
                {
                    v_EstadoThumb = v_EstadoIndex = v_EstadoMiddle = v_EstadoPinky = v_EstadoRing = 0;

                    v_extendedCount = 0;
                }
                yield return new WaitForSeconds(Period);
            }
        }
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

        public void CambiarRotacionPalmaManoDerecha(string _posicion)
        {
            v_PosicionManoDerecha = _posicion;
        }

    }
}
