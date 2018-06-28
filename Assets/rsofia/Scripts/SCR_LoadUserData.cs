using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_LoadUserData : MonoBehaviour {

    private int userAvatar;
    public static int currentUserID;
    public static string currentUsername;


    public Text txtUsername;

    void Start()
    {
        txtUsername.text = currentUsername;
    }

}
