using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attributes;

namespace Leap.Unity
{
    public class s_fingerDetectorCustom : Detector
    {
        [Units("seconds")]
        [MinValue(0)]
        public float Period = 0.1f; //seconds
        [Tooltip("The hand model to watch. Set automatically if detector is on a hand.")]
        public HandModelBase HandModel = null;

        public int EstadoThumb;
        public int EstadoIndex;
        public int EstadoMiddle;
        public int EstadoPinky;
        public int EstadoRing;

        public int extendedCount = 0;

        private IEnumerator watcherCoroutine;

        void Start()
        {
            EstadoThumb = EstadoIndex = EstadoMiddle = EstadoPinky = EstadoRing = 0;
        }
        void Update()
        {
        }
        void Awake()
        {
            watcherCoroutine = extendedFingerWatcher();
        }
        void OnEnable()
        {
            StartCoroutine(watcherCoroutine);
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
                        extendedCount = 0;
                        for (int f = 0; f < 5; f++)
                        {
                            
                            if (hand.Fingers[f].IsExtended)
                            {
                                extendedCount++;
                            }
                        }

                        EstadoThumb = fn_fingerState(hand.Fingers[0]);
                        EstadoIndex = fn_fingerState(hand.Fingers[1]);
                        EstadoMiddle = fn_fingerState(hand.Fingers[2]);
                        EstadoPinky = fn_fingerState(hand.Fingers[4]);
                        EstadoRing = fn_fingerState(hand.Fingers[3]);
                    
                    }
                }
                else
                {
                    EstadoThumb = EstadoIndex = EstadoMiddle = EstadoPinky = EstadoRing = 0;

                    extendedCount = 0;
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
    }
}