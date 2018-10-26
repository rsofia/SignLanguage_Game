using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class Fuzzy : SCR_GestureDetection
{   


    //* FUZZY LOGIC FUNC*\\
    #region FUZZY
    public static float OperatorAND(float _a, float _b)
    {
        return Mathf.Min(_a, _b);
    }
    public static float OperatorOR(float _a, float _b)
    {
        return Mathf.Max(_a, _b);
    }
    public static float OperatorNOT(float _a)
    {
        return 1.0f - _a;
    }
    public static float Trapezoid(float _x, float _x0, float _x1, float _x2, float _x3)
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
    public static float Compare(float _value, float _savedValue)
    {
        return Trapezoid(_value, _savedValue - 50, _savedValue - 20, _savedValue + 20, _savedValue + 50);
    }

    public static bool CompareVector(Vector3 a, Vector3 b)
    {
        bool result = false;
        result = Vector3.SqrMagnitude(a - b) < 0.005;
        //Debug.Log("Saved: " + b + " Current " + b + " " + result + "Vector comparison: " + Vector3.SqrMagnitude(a - b));
        return result;
    }

    public static bool CompareInt(int a, int b)
    {
        bool result = false;
        result = (a + 1) <= b && (a - 1) >= b;
        return result;
    }

    #endregion
}
