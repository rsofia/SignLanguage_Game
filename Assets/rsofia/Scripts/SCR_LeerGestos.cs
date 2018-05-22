using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class SCR_LeerGestos : SCR_GestureDetection
{

    private Dictionary<string, JSONGesture> diccionarioGestos = new Dictionary<string, JSONGesture>();
    private JSONGesture gesture;

    private bool isDictonarySaved = false;

    public CATEGORIAS_GESTOS gestoABuscar;

    [Header("Interfaz")]
    public Text txtLog;

    private void Start()
    {
        thumbBonesR = new Transform[] { thumbRight.Find("bone1"), thumbRight.Find("bone2"), thumbRight.Find("bone3") };
        indexBonesR = new Transform[] { indexRight.Find("bone1"), indexRight.Find("bone2"), indexRight.Find("bone3") };
        middleBonesR = new Transform[] { middleRight.Find("bone1"), middleRight.Find("bone2"), middleRight.Find("bone3") };
        ringBonesR = new Transform[] { ringRight.Find("bone1"), ringRight.Find("bone2"), ringRight.Find("bone3") };
        pinkyBonesR = new Transform[] { pinkyRight.Find("bone1"), pinkyRight.Find("bone2"), pinkyRight.Find("bone3") };

        ReadGesturesFromFile();
    }

    public void ReadGesturesFromFile()
    {
        string[] lineas = File.ReadAllLines(SCR_GesturesData.path + SCR_GesturesData.fileName);
        foreach (string linea in lineas)
        {
            gesture = JsonUtility.FromJson<JSONGesture>(linea);
            diccionarioGestos.Add(gesture.category + "_" + gesture.meaning, gesture);
            gesture = null;
        }
        isDictonarySaved = true;
    }

    public void Comparar()
    {
        if(isDictonarySaved)
        {
            foreach(KeyValuePair<string, JSONGesture> keyValue in diccionarioGestos)
            {
                gesture = keyValue.Value;
                if(OperatorOR(
                        OperatorOR(Compare(thumbRight.localEulerAngles.x, gesture.thumbRPos[0]), Compare(thumbRight.localEulerAngles.y, gesture.thumbRPos[1])),
                        Compare(thumbRight.localEulerAngles.z, gesture.thumbRPos[1])) > 0.5f)
                {
                    if(indexRight.localEulerAngles == new Vector3(gesture.indexRPos[0], gesture.indexRPos[1], gesture.indexRPos[2]))
                    {
                        if (middleRight.localEulerAngles == new Vector3(gesture.middleRPos[0], gesture.middleRPos[1], gesture.middleRPos[2]))
                        {
                            if (ringRight.localEulerAngles == new Vector3(gesture.ringRPos[0], gesture.ringRPos[1], gesture.ringRPos[2]))
                            {
                                bool allThumbsMatch= true;
                                CheckBonesOf(thumbBonesR, gesture.thumbRPos, out allThumbsMatch);
                                bool allIndexMatch = true;
                                CheckBonesOf(indexBonesR, gesture.indexRPos, out allIndexMatch);
                                bool allRingMatch = true;
                                CheckBonesOf(ringBonesR, gesture.ringRPos, out allRingMatch);

                                if(allIndexMatch && allThumbsMatch && allRingMatch)
                                {
                                    StartCoroutine(SCR_GesturesData.PopUp(txtLog, keyValue.Value.meaning));
                                    break;
                                }
                                else
                                {
                                    StartCoroutine(SCR_GesturesData.PopUp(txtLog, "<b>thumb:</b> " + allThumbsMatch + " <b>index:</b> " + allIndexMatch + " <b>ring:</b> " + allRingMatch + " "+ gesture.meaning));
                                }


                            }
                            else
                            {
                                StartCoroutine(SCR_GesturesData.PopUp(txtLog, "Ring doesnt match"));
                            }
                        }
                        else
                        {
                            StartCoroutine(SCR_GesturesData.PopUp(txtLog, "Middle doesnt match"));
                        }
                    }
                    else
                    {
                        StartCoroutine(SCR_GesturesData.PopUp(txtLog, "Index doesnt match"));
                    }
                }
                else
                {
                    StartCoroutine(SCR_GesturesData.PopUp(txtLog, "Thumb doesnt match"));
                }
            }

            gesture = null;
        }
    }

    private void CheckBonesOf(Transform[] _bones, float[] _gesture, out bool _allMatch)
    {
        _allMatch = true;
        for (int i = 0; i < 3; i++)
        {
            if (_allMatch == false)
                break;

            for (int j = 3; j <= 11; j += 3)
            {
                float xthesame = Compare(_bones[i].localEulerAngles.x, _gesture[j]);
                float ythesame = Compare(_bones[i].localEulerAngles.y, _gesture[j + 1]);
                float ztheSame = Compare(_bones[i].localEulerAngles.z, _gesture[j + 2]);

                Debug.Log("Comparison: x: " + xthesame + " y: " + ythesame + " z: " + ztheSame);
                if (OperatorOR(OperatorOR(xthesame, ythesame), ztheSame) > 0.5f)
                    _allMatch = true;
                else
                    _allMatch = false;

                if (_allMatch == false)
                    break;
            }
        }
    }

   


    //* FUZZY LOGIC FUNC*\\
    #region FUZZY
    protected float OperatorAND(float _a, float _b)
    {
        return Mathf.Min(_a, _b);
    }
    protected float OperatorOR(float _a, float _b)
    {
        return Mathf.Max(_a, _b);
    }
    protected float OperatorNOT(float _a)
    {
        return 1.0f - _a;
    }
    protected float Trapezoid(float _x, float _x0, float _x1, float _x2, float _x3)
    {
        float memership = 0.0f;
        if (_x <= _x0 || _x > _x3)
            memership = 0.0f;
        else if (_x > _x0 && _x0 < _x1)
            memership = (_x / (_x1 - _x0)) - (_x0 / (_x1 - _x0));
        else if (_x > _x1 && _x < _x2)
            memership = -(_x / (_x3 - _x2)) + (_x3 / (_x3 - _x2));
        return memership;
    }
    public float Compare(float _value, float _savedValue)
    {
        return Trapezoid(_value, _savedValue - 50, _savedValue - 20, _savedValue + 20, _savedValue + 50);
    }

    #endregion
}
