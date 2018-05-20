using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JSONGesture {

    //public int gestureID;
    public int category;
    public string meaning = "";
    public float[] thumbRPos; 
    public float[] indexRPos;
    public float[] middleRPos;
    public float[] ringRPos;
    public float[] pinkyRPos;

    // 0 = ROOT X
    // 1 = ROOT Y
    // 2 = ROOT Z
    //
    // 3 = BONE 1 X
    // 4 = BONE 1 Y
    // 5 = BONE 1 Z
    //
    // 6 = BONE 2 X
    // 7 = BONE 2 Y
    // 8 = BONE 2 Z
    //
    // 9 = BONE 3 X
    // 10 = BONE 3 Y
    // 11 = BONE 3 Z

}
