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

        public string EstadoPulgar;
        public int extendedCount = 0;

        private IEnumerator watcherCoroutine;

        void Start()
        {
            EstadoPulgar = "";
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
                    }
                }
                else
                {
                    extendedCount = 0;
                }
                yield return new WaitForSeconds(Period);
            }
        }

        private bool matchFingerState(Finger finger, PointingState requiredState)
        {
            return (requiredState == PointingState.Either) ||
                   (requiredState == PointingState.Extended && finger.IsExtended) ||
                   (requiredState == PointingState.NotExtended && !finger.IsExtended);
        }
    }
}